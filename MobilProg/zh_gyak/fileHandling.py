# Fájlkezelő függvények
# open(path, mode): fájl megnyitása
# path: a megnyitni kívánt fájl elérési útvonala (szöveg)
# mode: a fájlmegnyitás módja (szöveg)
    # "r": olvasás (alapértelmezett)
    # "w": írás (felülírja a fájl tartalmát)
    # "a": fájl végéhez való hozzáfűzés
    # "x": kizárólagos létrehozás (ha már létezik, hibát kapunk)

# Fájl műveletek:
# read(n): n darab karakter beolvasása
# readline(): egy sor beolvasása
# readlines(): egy fájl beolvasása soronként
# write(szoveg): adott szöveg írása fájlba
# close(): a megnyitott fájl lezárása

try:
    file = open("be.txt", "r")
    tartalom = file.readlines()
    # a tartalom kiíratása soronként
    for sor in tartalom:
        # sor = sor.rstrip()
        print(sor, end="")
    file.close()
except FileNotFoundError as fnfe:
    print("A fájl nem található")

# Kontextuskezelő mechanizmus (context manager)
with open("be.txt", "r") as my_file:
    tartalom = my_file.readlines()

# Gyakorlás: Olvassuk be a be.txt fájl tartalmát, majd számítsuk ki
# a fájlban szereplő értékek átlagát! Ezt írjuk ki egy ki.txt nevű
# állományba!