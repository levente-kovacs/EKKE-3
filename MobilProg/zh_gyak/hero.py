class Szuperhos:
    def __init__(self, nev, szuperero=30):
        # adattagok létrehozása és inicializálása
        self.__nev = nev
        self.__szuperero = szuperero
        print("-- Szuperhős létrehozva. --")

    # def get_szuperero(self):
    #     return self.__szuperero
    # def set_szuperero(self, value):
    #     self.__szuperero = value

    @property
    def nev(self):
        return self.__nev

    @nev.setter
    def nev(self, ertek):
        self.__nev = ertek

    @property
    def szuperero(self):
        return self.__szuperero
    @szuperero.setter
    def szuperero(self, ertek):
        self.__szuperero = ertek

    def __str__(self):
        return (f"{self.__nev} egy szuperhős, akinek"
                f" szuperereje {self.__szuperero}")

    # két szuperhős akkor lesz egyenlő, ha
    # a nevük és a szupererejük megegyezik
    def __eq__(self, masik_hos):
        return (self.__nev == masik_hos.__nev and
                self.__szuperero == masik_hos.__szuperero)

    # két szuperhős összeadása során a szuperejük összeadódik
    def __add__(self, masik_hos):
        uj_szuperero = self.__szuperero + masik_hos.__szuperero
        uj_szuperhos = Szuperhos("Megahős",uj_szuperero)
        return uj_szuperhos

szuperhos1 = Szuperhos("Thor", 100)
szuperhos1.szuperero = 120
print(szuperhos1.szuperero)
print(szuperhos1)
# Nincs function overload
szuperhos2 = Szuperhos("Kovásznai Gergely")
szuperhos3 = Szuperhos("Kovásznai Gergely", 50)
print(szuperhos2)
print(szuperhos2 == szuperhos3)
szuperhos4 = szuperhos2 + szuperhos3
print(szuperhos4)

# Operator ovearloding
# + operátor ki van terjesztve az int és az str osztályokban
# egyaránt
print(3 + 5)
print("alma" + "fa")

# Gyakorlás
# A szuperhősöknek legyen egy kepessegek adattagja is,
# ami kezdetben egy üres lista! Definiáljuk felül a += operátort,
# ami a paraméterül kapott értéket beszúrja a kepessegek lista
# végére, amennyiben az szöveges típusú!