import pandas as pd
from sklearn.metrics import mean_squared_error, mean_absolute_error, r2_score
import xgboost as xgb
import matplotlib.pyplot as plt

# 1. Adatok betöltése
data_file_path = "input_data/szeged_data.csv"  # Helyettesítsd a fájl elérési útvonalával
data = pd.read_csv(data_file_path)

# 2. Dátum oszlop datetime formátumra alakítása
data["date"] = pd.to_datetime(data["date"])

# 3. Célváltozó és prediktorok szétválasztása
X = data.drop(columns=["date", "Minimum_temperature"])  # 'date' és célváltozó eltávolítása
y = data["Minimum_temperature"]

# 4. Tanulási és teszt időszak meghatározása
train_data = data[data["date"].dt.year <= 2019]  # 1990-2019
test_data = data[data["date"].dt.year > 2019]    # 2020-2024

# Prediktorok és célváltozó különválasztása
X_train = train_data.drop(columns=["date", "Minimum_temperature"])
y_train = train_data["Minimum_temperature"]
X_test = test_data.drop(columns=["date", "Minimum_temperature"])
y_test = test_data["Minimum_temperature"]

# 5. XGBoost modell inicializálása
xgb_model = xgb.XGBRegressor(
    objective="reg:squarederror",  # Négyzetes hiba minimalizálása
    n_estimators=1000,            # Iterációk száma
    learning_rate=0.01,           # Lassú tanulási ráta
    max_depth=6,                  # A fák maximális mélysége
    subsample=0.3,                # Véletlenszerű mintavétel az adatokból
    colsample_bytree=0.8,         # Véletlenszerű mintavétel a jellemzőkből
    random_state=42,              # Reprodukálhatóság érdekében
    eval_metric="rmse",           # Értékelési metrika
    early_stopping_rounds=50      # Korai megállítás iterációkra
)

# 6. Modell betanítása (folyamatkövetéssel)
xgb_model.fit(
    X_train,
    y_train,
    eval_set=[(X_train, y_train), (X_test, y_test)],  # Tanító- és tesztkészlet értékelése
    verbose=True                                      # Iterációs kiírás bekapcsolása
)

# 7. Előrejelzés a tesztkészleten
y_pred = xgb_model.predict(X_test)

# 8. Modell értékelése
rmse = mean_squared_error(y_test, y_pred)
#, squared=False)
mae = mean_absolute_error(y_test, y_pred)
r2 = r2_score(y_test, y_pred)

print(f"RMSE: {rmse:.2f}")
print(f"MAE: {mae:.2f}")
print(f"R²: {r2:.2f}")

# 9. Előrejelzések és valós értékek mentése
output_predictions = pd.DataFrame({
    "date": test_data["date"].values,          # Teszt időszak dátumai
    "actual_min_temperature": y_test.values,  # Valós minimum hőmérsékletek
    "predicted_min_temperature": y_pred       # Modell által előrejelzett értékek
})
output_file_path_predictions = "output_data/predicted_min_temperatures_szeged.csv"
output_predictions.to_csv(output_file_path_predictions, index=False)
print(f"Predictions saved to {output_file_path_predictions}")

# 10. Modell mentése (opcionális)
model_file_path = "output_data/xgboost_minimum_temperature_szeged_model.json"
xgb_model.save_model(model_file_path)
print(f"Model saved to {model_file_path}")

# Feature importance megjelenítése
#xgb.plot_importance(xgb_model, max_num_features=10, importance_type="weight")
#plt.show()

# 11. Kivesszük a fontossági sorrendet a modellből
feature_importance = xgb_model.get_booster().get_score(importance_type="weight")

# Átalakítjuk DataFrame-be
importance_df = pd.DataFrame(
    list(feature_importance.items()),
    columns=["Feature", "Importance"]
)

# Rendezés fontosság szerint (csökkenő sorrendben)
importance_df = importance_df.sort_values(by="Importance", ascending=False)

# Fontossági sorrend mentése CSV fájlba
output_file_path_importance = "output_data/feature_importance_szeged.csv"
importance_df.to_csv(output_file_path_importance, index=False)

print(f"Feature importance saved to {output_file_path_importance}")
