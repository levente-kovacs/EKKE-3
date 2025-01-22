import pandas as pd
from sklearn.metrics import mean_squared_error, mean_absolute_error, r2_score
import xgboost as xgb
import matplotlib.pyplot as plt
import numpy as np

"""
A Python kód célja, hogy a minimumhőmérséklet előrejelzésére gépi tanulási modellt, konkrétan egy XGBoost regresszort hozzon létre és értékeljen. Az alábbi fő lépésekből áll:

1. Adatok előkészítése

    CSV-fájl betöltése, amely a meteorológiai és célváltozóra vonatkozó adatokat tartalmazza.
    A dátum formátumának átalakítása.
    A célváltozó (minimumhőmérséklet) és az előrejelző változók szétválasztása.

2. Időszakok meghatározása

    Az adatok különválasztása tanulási (2014-ig), validációs (2015–2019), és tesztkészletre (2020 után).
    Kevésbé fontos prediktorok eltávolítása az elemzésből.

3. Hyperparaméter optimalizáció

    Manuális Grid Search-t használ az XGBoost modell optimális paramétereinek meghatározására.
    Különböző paraméterkombinációkat tesztel (pl. tanulási ráta, maximális mélység, stb.), a validációs adatokon elért RMSE alapján.

4. Modell betanítása

    A legjobb hyperparaméterekkel rendelkező XGBoost modell betanítása a tanulókészleten.

5. Modell értékelése

    Tesztkészleten végzett előrejelzés.
    Értékelési metrikák számítása: RMSE, MAE, és R².

6. Eredmények mentése

    Előrejelzések és valós értékek exportálása CSV fájlba.
    Modell mentése JSON formátumban.
    Fontossági mutatók mentése, amelyek megmutatják az egyes prediktorok súlyát a modellben.

7. Vizualizáció és jelentés

    A kód tartalmazza a matplotlib használatát, de jelenleg nem tartalmaz grafikonokat. Ezek később kiegészíthetők.
 """

# 1. Adatok betöltése
data_file_path = "input_data/szeged_data.csv"
data = pd.read_csv(data_file_path)

# 2. Dátum oszlop datetime formátumra alakítása
data["date"] = pd.to_datetime(data["date"])

# 3. Célváltozó és prediktorok szétválasztása
# X = data.drop(columns=["date", "Minimum_temperature"])
# Y = data["Minimum_temperature"]

# 4. Tanulási, validációs és teszt időszak meghatározása
train_data = data[data["date"].dt.year <= 2014]
validation_data = data[(data["date"].dt.year > 2014) & (data["date"].dt.year <= 2019)]
test_data = data[data["date"].dt.year > 2019]

X_train = train_data.drop(columns=["date", "Minimum_temperature"])
Y_train = train_data["Minimum_temperature"]
X_validation = validation_data.drop(columns=["date", "Minimum_temperature"])
Y_validation = validation_data["Minimum_temperature"]
X_test = test_data.drop(columns=["date", "Minimum_temperature"])
Y_test = test_data["Minimum_temperature"]

# 4/a. Kevésbé fontos prediktorok eltávolítása
low_importance_features = [
    "low_cloud_cover_06", "soil_temp_0_7cm_18_bef_day",
    "temperature_2m_12_bef_day", "snow_depth_18_bef_day",
    "snow_depth_12_bef_day"
]
X_train = X_train.drop(columns=low_importance_features, errors="ignore")
X_validation = X_validation.drop(columns=low_importance_features, errors="ignore")
X_test = X_test.drop(columns=low_importance_features, errors="ignore")

# 5. Hyperparaméterek keresése manuális Grid Search-sel (gyorsított)
param_grid = {
    "learning_rate": [0.05, 0.1],
    "max_depth": [4, 6],
    "n_estimators": [100, 500],
    "subsample": [0.8, 1.0],
    "colsample_bytree": [0.8, 1.0]
}

best_params = None
best_rmse = float("inf")

for lr in param_grid["learning_rate"]:
    for md in param_grid["max_depth"]:
        for ne in param_grid["n_estimators"]:
            for ss in param_grid["subsample"]:
                for cs in param_grid["colsample_bytree"]:
                    model = xgb.XGBRegressor(
                        learning_rate=lr,
                        max_depth=md,
                        n_estimators=ne,
                        subsample=ss,
                        colsample_bytree=cs,
                        objective="reg:squarederror",
                        random_state=42
                    )
                    model.fit(X_train, Y_train, eval_set=[(X_validation, Y_validation)], verbose=False)
                    preds = model.predict(X_validation)
                    rmse = mean_squared_error(Y_validation, preds)
                    if rmse < best_rmse:
                        best_rmse = rmse
                        best_params = {
                            "learning_rate": lr,
                            "max_depth": md,
                            "n_estimators": ne,
                            "subsample": ss,
                            "colsample_bytree": cs
                        }

print("Best parameters:", best_params)

# 6. Legjobb modell betanítása és értékelése
best_model = xgb.XGBRegressor(
    **best_params,
    objective="reg:squarederror",
    random_state=42
)
best_model.fit(X_train, Y_train)

# 7. Tesztkészleten való előrejelzés
Y_pred = best_model.predict(X_test)

# 8. Modell értékelése
rmse = mean_squared_error(Y_test, Y_pred)
mae = mean_absolute_error(Y_test, Y_pred)
r2 = r2_score(Y_test, Y_pred)

print(f"RMSE: {rmse:.2f}")
print(f"MAE: {mae:.2f}")
print(f"R²: {r2:.2f}")

# 9. Előrejelzések és valós értékek mentése
output_predictions = pd.DataFrame({
    "date": test_data["date"].values,
    "actual_min_temperature": Y_test.values,
    "predicted_min_temperature": Y_pred
})
output_file_path_predictions = "output_data/valid_predicted_min_temperatures_szeged.csv"
output_predictions.to_csv(output_file_path_predictions, index=False)
print(f"Predictions saved to {output_file_path_predictions}")

# 10. Modell mentése (opcionális)
model_file_path = "output_data/valid_xgboost_minimum_temperature_szeged_model.json"
best_model.save_model(model_file_path)
print(f"Model saved to {model_file_path}")

# 11. Feature importance mentése
feature_importance = best_model.get_booster().get_score(importance_type="weight")
importance_df = pd.DataFrame(
    list(feature_importance.items()),
    columns=["Feature", "Importance"]
)
importance_df = importance_df.sort_values(by="Importance", ascending=False)
output_file_path_importance = "output_data/valid_feature_importance_szeged.csv"
importance_df.to_csv(output_file_path_importance, index=False)
print(f"Feature importance saved to {output_file_path_importance}")
