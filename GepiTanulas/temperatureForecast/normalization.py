import pandas as pd
from sklearn.preprocessing import MinMaxScaler

"""
A kód működése:

    Betölti a CSV fájlt:
        A file_path változóban megadott fájlt tölti be
        Pandas DataFrame-be.
    Kiválasztja a numerikus oszlopokat:
        A time oszlop kivételével az összes numerikus oszlopra
        elvégzi a normalizálást.
    Normalizálás:
        A MinMaxScaler skálázza az adatokat 0 és 1 közé.
    Mentés:
        Az eredményt elmenti egy új CSV fájlba az
        output_file_path útvonalon.

"""

# Load the merged dataset
file_path = "transformed_data/correct_target_data.csv"  # Helyettesítsd a fájl elérési útvonalával
data = pd.read_csv(file_path)

# Identify numeric columns (excluding 'time')
numeric_columns = data.columns.difference(["time"])

# Initialize the MinMaxScaler
scaler = MinMaxScaler()

# Normalize the numeric data
data[numeric_columns] = scaler.fit_transform(data[numeric_columns])

# Save the normalized data to a new CSV file
output_file_path = "transformed_data/normalized_correct_data.csv"  # Helyettesítsd a kívánt fájl elérési útvonalával
data.to_csv(output_file_path, index=False)

print(f"Normalized data saved to {output_file_path}")
