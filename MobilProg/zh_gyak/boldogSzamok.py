# Segédfüggvény: Számjegyek négyzetösszege
def szamjegyek_negyzetosszege(n):
    return sum(int(i) ** 2 for i in str(n))

# Iteratív megoldás
def boldog_szamok_iterativ(szam):
    while szam != 1 and szam != 4:
        szam = szamjegyek_negyzetosszege(szam)

    if szam == 1:
        return "Boldog szám! :)"
    else:
        return "Boldogtalan szám! :’("

# Rekurzív megoldás
def boldog_szamok_rekurziv(szam):
    if szam == 1:
        return "Boldog szám! :)"
    elif szam == 4:
        return "Boldogtalan szám! :’("
    else:
        return boldog_szamok_rekurziv(szamjegyek_negyzetosszege(szam))

# Tesztelés
szam = 23
print(f"Iteratív megoldás - {szam}: {boldog_szamok_iterativ(szam)}")
print(f"Rekurzív megoldás - {szam}: {boldog_szamok_rekurziv(szam)}")