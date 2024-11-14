class NincsPisztaciaException(Exception):
    def __init__(self, uzenet):
        self.uzenet = uzenet
        # ősosztály konstruktorának meghívása
        super().__init__(self.uzenet)

try:
    fagyi_izek = ["csoki", "vanília", "eper", "karamell"]
    if "pisztácia" not in fagyi_izek:
        raise NincsPisztaciaException("Elfogyott a pisztácia!")
except NincsPisztaciaException as npe:
    print(npe)