import pandas as pd
from sklearn.ensemble import RandomForestRegressor
from sklearn.metrics import mean_squared_error, mean_absolute_error, r2_score
from sklearn.model_selection import GridSearchCV
import xgboost as xgb
import lightgbm as lgb
import numpy as np
import tensorflow as tf
from tensorflow import keras
from keras import Sequential

#from keras.layers import Dense, Dropout
#from tensorflow.keras.layers import Dense, Dropout


"""
a meglévő XGBoost, Random Forest, LightGBM Gradient Boosting Machines (GBM)
modellek mellé létrehoz egy neurális hálózat modellt is
és az előrejelzéseiket összehasonlítja, illetve kombinálja

??? javulást hoz ez a kombinált módszer ???
"""

# 1. Adatok betöltése
# (Helyettesítsd a megfelelő elérési úttal)
data_file_path = "input_data/szeged_eliminated_5deg_diff_data.csv"
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
#X_validation = validation_data.drop(columns=["date", "Minimum_temperature"])
#Y_validation = validation_data["Minimum_temperature"]
X_test = test_data.drop(columns=["date", "Minimum_temperature"])
Y_test = test_data["Minimum_temperature"]

# 4/a. Kevésbé fontos prediktorok eltávolítása
low_importance_features = [#"day",
                           "temperature_2m_00","temperature_2m_06",
                           #"dew_point_00","dew_point_06",
                           "925_wind_speed_12_bef_12",
                           "high_cloud_cover_12_bef_day",
                           "low_cloud_cover_12_bef_day",
                           "mid_cloud_cover_12_bef_day",
                           "snow_depth_12_bef_day", "snow_depth_18_bef_day",
                           #"snow_depth_00",
                           #"snow_depth_06",
                           #"soil_temp_0_7cm_00", "soil_temp_0_7cm_06",
                           "soil_moisture_0_7cm_12_bef_day",
                           #"soil_moisture_0_7cm_18_bef_day",
                           "soil_moisture_0_7cm_00",
                           "soil_moisture_0_7cm_06",
                           #"wind_speed_10m_12_bef_day"
                           ]
#   day,925_temperature_12_bef_day,925_temperature_18_bef_day,
#   925_temperature_00,925_temperature_06,
#   925_wind_speed_12_bef_12,925_wind_speed_18_bef_day,
#   925_wind_speed_00,925_wind_speed_06,
#   dew_point_12_bef_day,dew_point_18_bef_day,dew_point_00,dew_point_06,
#   temperature_2m_12_bef_day,temperature_2m_18_bef_day,
#   temperature_2m_00,temperature_2m_06,
#   high_cloud_cover_12_bef_day,high_cloud_cover_18_bef_day,
#   high_cloud_cover_00,high_cloud_cover_06,
#   low_cloud_cover_12_bef_day,low_cloud_cover_18_bef_day,
#   low_cloud_cover_00,low_cloud_cover_06,
#   mid_cloud_cover_12_bef_day,mid_cloud_cover_18_bef_day,
#   mid_cloud_cover_00,mid_cloud_cover_06,
#   snow_depth_12_bef_day,snow_depth_18_bef_day,snow_depth_00,snow_depth_06,
#   soil_temp_0_7cm_12_bef_day,soil_temp_0_7cm_18_bef_day,
#   soil_temp_0_7cm_00,soil_temp_0_7cm_06,
#   soil_moisture_0_7cm_12_bef_day,soil_moisture_0_7cm_18_bef_day,
#   soil_moisture_0_7cm_00,soil_moisture_0_7cm_06,
#   wind_speed_10m_12_bef_day,wind_speed_10m_18_bef_day,
#   wind_speed_10m_00,wind_speed_10m_06
#   
# "low_cloud_cover_06", "soil_temp_0_7cm_18_bef_day",
#    "temperature_2m_12_bef_day", "snow_depth_18_bef_day",
#    "snow_depth_12_bef_day"
#]
X_train = X_train.drop(columns=low_importance_features, errors="ignore")
#X_validation = X_validation.drop(columns=low_importance_features, errors="ignore")
X_test = X_test.drop(columns=low_importance_features, errors="ignore")

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

"""
evaluate_model("Random Forest", Y_test, rf_preds)
evaluate_model("LightGBM", Y_test, lgb_preds)
evaluate_model("XGBoost", Y_test, xgb_preds)
evaluate_model("Ensemble", Y_test, ensemble_preds)
"""

# 10. Neurális hálózat modell létrehozása

#from keras.layers import Dense, Dropout
#from tensorflow.keras.layers import Dense, Dropout
# valamiért ezeket az importokat nem tudja, ezért így kell módosítani a modellt

""" nn_model = Sequential([
    Dense(64, activation='relu', input_shape=(X_train.shape[1],)),
    Dropout(0.2),
    Dense(32, activation='relu'),
    Dropout(0.2),
    Dense(1, activation='linear')  # Regressziós kimenet
])
"""
""" 
nn_model = keras.Sequential([
    keras.layers.Dense(64, activation='relu', input_shape=(X_train.shape[1],)),
    keras.layers.Dropout(0.2),
    keras.layers.Dense(32, activation='relu'),
    keras.layers.Dropout(0.2),
    keras.layers.Dense(1, activation='linear')
])


nn_model.compile(optimizer='adam', loss='mse', metrics=['mae'])

# 11. Modell betanítása
history = nn_model.fit(
    X_train, Y_train,
    validation_data=(X_validation, Y_validation),
    epochs=50,
    batch_size=32,
    verbose=1
) """

# Neurális hálózat új konfiguráció
nn_model = keras.Sequential([
    keras.layers.Dense(128, activation='relu', input_shape=(X_train.shape[1],)),
    keras.layers.Dropout(0.3),  # Dropout növelése
    keras.layers.Dense(128, activation='relu'),
    keras.layers.Dropout(0.3),
    keras.layers.Dense(64, activation='relu'),
    keras.layers.Dense(1, activation='linear')  # Regressziós kimenet
])

# Tanulási sebesség explicit beállítása
optimizer = tf.keras.optimizers.Adam(learning_rate=0.0005)

nn_model.compile(optimizer=optimizer, loss='mse', metrics=['mae'])

# Korai megállás callback
early_stopping = keras.callbacks.EarlyStopping(
    monitor='val_loss',
    patience=10,
    restore_best_weights=True
)

# Modell betanítása
history = nn_model.fit(
    X_train, Y_train,
    #validation_data=(X_validation, Y_validation),
    epochs=100,  # Több epoch
    batch_size=32,
    callbacks=[early_stopping],  # Korai megállás
    verbose=1
)

# 12. Előrejelzések készítése
nn_preds = nn_model.predict(X_test).flatten()

# 13. Modellek értékelése
evaluate_model("Random Forest", Y_test, rf_preds)
evaluate_model("LightGBM", Y_test, lgb_preds)
evaluate_model("XGBoost", Y_test, xgb_preds)
evaluate_model("Ensemble", Y_test, ensemble_preds)
evaluate_model("Neural Network", Y_test, nn_preds)

# 14. Eredmények kombinációja az ensemble módszerrel
ensemble_preds_with_nn = (rf_preds + lgb_preds + xgb_preds + nn_preds) / 4

# 15. Új ensemble értékelés
evaluate_model("Ensemble with Neural Network", Y_test, ensemble_preds_with_nn)

# 16. Eredmények mentése
output_predictions_with_nn = pd.DataFrame({
    "date": test_data["date"].values,
    "actual_min_temperature": Y_test.values,
    "rf_preds": rf_preds,
    "lgb_preds": lgb_preds,
    "xgb_preds": xgb_preds,
    "nn_preds": nn_preds,
    "ensemble_preds_with_nn": ensemble_preds_with_nn
})
output_file_path_predictions_with_nn = "output_data/predicted_min_temperatures_with_nn.csv"
output_predictions_with_nn.to_csv(output_file_path_predictions_with_nn, index=False)
print(f"Predictions with NN saved to {output_file_path_predictions_with_nn}")

# 17. Korrelácis mátrix készítése
correlation_matrix = data.corr()
print(correlation_matrix["Minimum_temperature"].sort_values(ascending=False))















