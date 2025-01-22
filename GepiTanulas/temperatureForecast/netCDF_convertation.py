import xarray as xr
import pandas as pd

# NetCDF fájlok elérési útvonala
file_925_path = "source_data/925hPa_1racspont_0331.nc"  # Helyettesítsd a megfelelő fájl elérési útvonalával
file_surface_path = "source_data/felszin_1racspont_0331.nc"  # Helyettesítsd a megfelelő fájl elérési útvonalával

# NetCDF fájlok betöltése
data_925 = xr.open_dataset(file_925_path)
data_surface = xr.open_dataset(file_surface_path)

# NetCDF adatok pandas DataFrame-be konvertálása
df_925 = data_925.to_dataframe().reset_index()
df_surface = data_surface.to_dataframe().reset_index()

# Csak a szükséges változók kiválasztása
df_925 = data_925[["valid_time", "t", "u", "v"]].to_dataframe().reset_index()
df_surface = data_surface[["valid_time", "u10", "v10", "d2m", "t2m", "hcc", "lcc", "mcc", "sd", "stl1", "swvl1"]].to_dataframe().reset_index()

# Csak a szükséges oszlopok megtartása
df_925_selected = df_925[["valid_time", "t", "u", "v"]]
df_surface_selected = df_surface[["valid_time", "u10", "v10", "d2m", "t2m", "hcc", "lcc", "mcc", "sd", "stl1", "swvl1"]]

# CSV fájlok mentése
output_925_csv = "transformed_data/925hPa_data_0331.csv"
output_surface_csv = "transformed_data/surface_data_0331.csv"

df_925.to_csv(output_925_csv, index=False)
df_surface.to_csv(output_surface_csv, index=False)

print(f"925 hPa adatok CSV-be írva: {output_925_csv}")
print(f"Felszíni adatok CSV-be írva: {output_surface_csv}")
