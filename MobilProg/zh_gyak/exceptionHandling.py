# eretnekseg = 5 / 0
# print("Angry Szakács Tomi noises..")

# Kivétel dobása
# raise Exception() # Exception típusú kivétel dobása
# raise Exception("Valamit elszúrtunk..")

# Kivételek elkapása
# try:
#     # a kód azon része, ahol kivétel dobódhat
# except ExceptionType as e:
#     # ExceptionType típusú kivétel elkapása
# except Exception:
#     # Exception típusú kivétel elkapása
# finally:
#     # mindenképpen lefutó kódrész

# Példa: Írjunk egy osztály függvényt, amely két egész szám
# paramétert vár (a és b), visszatérési értéke pedig
# a/b hányados! Ha nem egész típusú paraméterkeet kapunk vagy
# ha nullával szeretnénk osztani, dobjunk kivételt!

def osztas(a, b):
    if isinstance(a, int) and isinstance(b, int):
        if b == 0:
            raise ZeroDivisionError("Ejnye, nullával nem osztunk!")
        return a / b
    raise TypeError("Egész típusú paramétereket adj meg!")

try:
    print(osztas(5,2))
    print(osztas(5.0, 0))

# Több except ág esetén a legelső, a dobott kivétel típusra illeszkedő fut le.
except ZeroDivisionError as zde:
    print(zde)
except TypeError as te:
    print(te)
except Exception:
    print("Valami egyéb hiba történt..")
finally:
    print("--- kivételkezelés vége ---")

