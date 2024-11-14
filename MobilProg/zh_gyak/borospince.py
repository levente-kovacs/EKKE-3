class BorospinceException(Exception):
    def __init__(self, err):
        # self.uzenet = err
        super().__init__(err)

    
class Bor:

    def __init__(self, fajta, evjarat, alkoholtartalom = 12.5):
        if alkoholtartalom < 0 or alkoholtartalom > 100:
            raise BorospinceException("Nem megfelelo alkoholtartalom!")
        self.__fajta = fajta
        self.__evjarat = evjarat
        self.__alkoholtartalom = alkoholtartalom

    @property
    def fajta(self):
        return self.__fajta

    # @fajta.getter
    # def fajta(self):
    #     return self.__fajta
    
    @fajta.setter
    def fajta(self, value):
        self.__fajta = value

    @property
    def evjarat(self):
        return self.__evjarat
    
    # @evjarat.getter
    # def evjarat(self):
    #     return self.__evjarat
    
    @evjarat.setter
    def evjarat(self, value):
        self.__evjarat = value

    @property
    def alkoholtartalom(self):
        return self.__alkoholtartalom
    
    # @alkoholtartalom.getter
    # def alkoholtartalom(self):
    #     return self.__alkoholtartalom
    
    @alkoholtartalom.setter
    def alkoholtartalom(self, value):
        if value < 0 or value > 100:
            raise BorospinceException("Nem megfelelo alkoholtartalom!")
        self.__alkoholtartalom = value


    def __str__(self):
        return f"{self.fajta} (evjarat: {self.evjarat}), melynek alkoholtartalma: {self.alkoholtartalom}%"

    def __eq__(self, value):
        if not isinstance(value, Bor):
            return False
        return (self.fajta.lower() == value.__fajta.lower() and
                self.evjarat == value.evjarat and
                self.alkoholtartalom == value.alkoholtartalom)

class Szekreny:
    
    # @property
    # def borok(self):
    #     return self.borok

    def __init__(self):
        self.borok = []

    def get_bor(self, index):
        if (index < 0 or index > (len(self.borok)) - 1):
            raise BorospinceException("Nem letezo index!")
        return self.borok[index]
    
    def __iadd__(self, otherVine):
        if not isinstance(otherVine, Bor):
            raise TypeError("Nem bor!")
        self.borok.append(otherVine)
        return self

    def __add__(self, otherCabinet):
        if not isinstance(otherCabinet, Szekreny):
            raise TypeError("Nem szekreny!")
        newCabinet = Szekreny()
        newCabinet.borok = self.borok + otherCabinet.borok
        # print(f"self.borok: {self.borok}")
        # print(f"otherCabinet.borok: {otherCabinet.borok}")
        # print(f"self.borok + otherCabinet.borok): {self.borok + otherCabinet.borok}")
        # print(f"self.borok.extend(otherCabinet.borok): {self.borok.extend(otherCabinet.borok)}")
        # print(f"newCabinet: {newCabinet.borok}")
        return newCabinet

    def atlag_alkoholtartalom(self):
        if len(self.borok) == 0:
            raise BorospinceException("Ures a szekreny!")
        vineSum = 0
        for vine in self.borok:            
            vineSum += vine.alkoholtartalom
        return vineSum / len(self.borok)

    def statisztika(self):
        statDict = dict()
        if len(self.borok) == 0:
            return statDict
        
        for vine in self.borok:
            vineType = vine.fajta.lower()
            if vineType not in statDict:
                statDict[vineType] = 1
            else:
                statDict[vineType] += 1
        return statDict

    def megisszak(self, vine):
        if not isinstance(vine, Bor):
            raise TypeError("Nem bor!")
        if vine not in self.borok:
            raise BorospinceException("Bor nem talalhato!")
        self.borok.remove(vine)

    def __str__(self):
        if len(self.borok) == 0:
            return "Ez egy ures szekreny."
        statDict = self.statisztika()
        # print(f"statDict: {statDict}")
        result = ""
        for key, value in statDict.items():
            result += f"{value} {key}, "        
        return result[:-2]

if __name__ == '__main__':

    borok = []
    try:
        file = open("borok.txt", "r")
        content = file.readlines()
        # a tartalom kiíratása soronként
        for line in content:
            line = line.rstrip()
            lineParts = line.split(", ")
            if (len(lineParts) < 3):
                borok.append(Bor(lineParts[0], int(lineParts[1])))
            else:
                borok.append(Bor(lineParts[0], int(lineParts[1]), float(lineParts[2])))
        file.close()
    except Exception as error:
        print(f"Error: {error}")

    bor1 = borok[0]
    bor2 = borok[1]
    bor3 = borok[2]
    bor4 = borok[3]
    # bor1 = Bor('Tokaji aszu', 2017, 13.5)
    # bor2 = Bor('Gyanus kinezetu kannasbor', 2010)
    # bor3 = Bor('ToKaJi AsZu', 2015, 13.8)
    # bor4 = Bor('Chardonnay', 2019, 13.0)
    bor2.fajta = 'Egri bikaver'
    bor2.evjarat = 2013
    bor2.alkoholtartalom = 12.0
    print(f'{bor2.fajta}, {bor2.evjarat}, {bor2.alkoholtartalom}') # 'Egri bikaver, 2013, 12.0'
    print(bor1) # 'Tokaji aszu (evjarat: 2017), melynek alkoholtartalma: 13.5%'
    print(bor1 == Bor('TOKAJI ASZU', 2017, 13.5)) # True
    print(bor1 == bor2) # False
    print(bor1 == 'Hibas tipusu parameter!') # False
    szekreny1 = Szekreny()
    szekreny2 = Szekreny()
    szekreny1 += bor1
    szekreny1 += bor2
    szekreny1 += bor3
    szekreny2 += bor4
    szekreny3 = szekreny1 + szekreny2
    print(szekreny3.get_bor(0)) # 'Tokaji aszu (evjarat: 2017), melynek alkoholtartalma: 13.5%'
    print(szekreny3.get_bor(3)) # 'Chardonnay (evjarat: 2019), melynek alkoholtartalma: 13.0%'
    print(szekreny3.atlag_alkoholtartalom()) # 13.075
    szekreny2.megisszak(bor4)
    print(szekreny2.statisztika()) # {}
    print(szekreny3.statisztika()) # {'tokaji aszu': 2, 'egri bikaver': 1, 'chardonnay': 1}
    print(szekreny2) # 'Ez egy ures szekreny.'
    print(szekreny3)

















    # def __init__(self, x, y):
    #     self.__x = x  # name mangling
    #     self.__y = y

    # # getter metódus
    # def get_x(self):
    #     return self.__x

    # # setter metódus
    # def set_x(self, value):
    #     self.__x = value

    # # get property szintaxisa
    # @property
    # def x(self):
    #     return self.__x

    # # set property szintaxia
    # @x.setter
    # def x(self, value):
    #     self.__x = value

    # def __str__(self):
    #     return (f"Az x koordináta értéke: {self.__x}"
    #             f" és az y koordináta értéke: {self.__y}")

    # # isinstance(object ,type)
    # def tavolsag_2pont_kozott(self, masik_pont: 'Pont'):
    #     if isinstance(masik_pont, Pont):
    #         return math.sqrt((self.__x - masik_pont.__x) ** 2
    #                          + (self.__y - masik_pont.__y) ** 2)
    #     else:
    #         return ("A távolság kiszámítása csak pont típusok"
    #                 "között történhet!")