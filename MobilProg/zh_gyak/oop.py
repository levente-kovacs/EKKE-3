import math

print("Objektumorientált programozás")


# Pass utasítás azt jelzi, hogy az osztályunk törzse üres,
# ezt majd később fogjuk megírni.
class Osztaly:
    pass


class Pont:
    def __init__(self, x, y):
        self.__x = x  # name mangling
        self.__y = y

    # getter metódus
    def get_x(self):
        return self.__x

    # setter metódus
    def set_x(self, value):
        self.__x = value

    # get property szintaxisa
    @property
    def x(self):
        return self.__x

    # set property szintaxia
    @x.setter
    def x(self, value):
        self.__x = value

    def __str__(self):
        return (f"Az x koordináta értéke: {self.__x}"
                f" és az y koordináta értéke: {self.__y}")

    # isinstance(object ,type)
    def tavolsag_2pont_kozott(self, masik_pont: 'Pont'):
        if isinstance(masik_pont, Pont):
            return math.sqrt((self.__x - masik_pont.__x) ** 2
                             + (self.__y - masik_pont.__y) ** 2)
        else:
            return ("A távolság kiszámítása csak pont típusok"
                    "között történhet!")


random_pont = Pont(1, 3)
# print(f"Az x változó értéke: {random_pont.__x}")
print(f"Az x változó értéke: {random_pont._Pont__x}")
print(f"Az x változó értéke: {random_pont.get_x()}")
random_pont.set_x(7)
print(f"A x változó új értéke: {random_pont.get_x()}")
print(random_pont)