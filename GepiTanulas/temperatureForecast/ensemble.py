import pandas as pd
from sklearn.ensemble import RandomForestRegressor
from sklearn.metrics import mean_squared_error, mean_absolute_error, r2_score
import xgboost as xgb
import lightgbm as lgb
import numpy as np

"""
a meglévő XGBoost modell mellé létrehoz egy Random Forest és egy LightGBM modellt,
és az előrejelzéseiket összehasonlítja, illetve kombinálja.

számottevő javulást nem hoz ez a kombinált módszer
"""

# 1. Adatok betöltése
# (Helyettesítsd a megfelelő elérési úttal)
data_file_path = "input_data/kiskunmajsa_data.csv"
data = pd.read_csv(data_file_path)

# 2. Dátum oszlop datetime formátumra alakítása
data["date"] = pd.to_datetime(data["date"])

# 3. Célváltozó és prediktorok szétválasztása
X = data.drop(columns=["date", "Minimum_temperature"])
Y = data["Minimum_temperature"]

# 4. Tanulási, validációs és teszt időszak meghatározása
train_data = data[data["date"].dt.year <= 2019]
# validation_data = data[(data["date"].dt.year > 2014) & (data["date"].dt.year <= 2019)]
test_data = data[data["date"].dt.year > 2019]

X_train = train_data.drop(columns=["date", "Minimum_temperature"])
Y_train = train_data["Minimum_temperature"]
# X_validation = validation_data.drop(columns=["date", "Minimum_temperature"])
# Y_validation = validation_data["Minimum_temperature"]
X_test = test_data.drop(columns=["date", "Minimum_temperature"])
Y_test = test_data["Minimum_temperature"]

# 5. Random Forest modell
rf_model = RandomForestRegressor(n_estimators=100, random_state=42)
rf_model.fit(X_train, Y_train)
rf_preds = rf_model.predict(X_test)

# 6. LightGBM modell
lgb_model = lgb.LGBMRegressor(random_state=42)
lgb_model.fit(X_train, Y_train)
lgb_preds = lgb_model.predict(X_test)

# 7. XGBoost modell (a korábban optimalizált paraméterekkel)
xgb_model = xgb.XGBRegressor(
    learning_rate=0.1,
    max_depth=6,
    n_estimators=500,
    subsample=0.8,
    colsample_bytree=0.8,
    objective="reg:squarederror",
    random_state=42
)
xgb_model.fit(X_train, Y_train)
xgb_preds = xgb_model.predict(X_test)

# 8. Modellek összehasonlítása és kombinációja
ensemble_preds = (rf_preds + lgb_preds + xgb_preds) / 3

# 9. Értékelés
def evaluate_model(name, y_true, y_pred):
    rmse = mean_squared_error(y_true, y_pred)
    mae = mean_absolute_error(y_true, y_pred)
    r2 = r2_score(y_true, y_pred)
    print(f"{name} - RMSE: {rmse:.2f}, MAE: {mae:.2f}, R²: {r2:.2f}")

evaluate_model("Random Forest", Y_test, rf_preds)
evaluate_model("LightGBM", Y_test, lgb_preds)
evaluate_model("XGBoost", Y_test, xgb_preds)
evaluate_model("Ensemble", Y_test, ensemble_preds)

# 10. Eredmények mentése
output_predictions = pd.DataFrame({
    "date": test_data["date"].values,
    "actual_min_temperature": Y_test.values,
    "rf_preds": rf_preds,
    "lgb_preds": lgb_preds,
    "xgb_preds": xgb_preds,
    "ensemble_preds": ensemble_preds
})
output_file_path_predictions = "output_data/predicted_min_temperatures_ensemble.csv"
output_predictions.to_csv(output_file_path_predictions, index=False)
print(f"Predictions saved to {output_file_path_predictions}")
