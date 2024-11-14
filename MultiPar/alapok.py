text = "Hello World!"
number = 2

x, y, color = 1, 2, "blue"
q = w = z = 0.123

print(type(text))

a = 3
print(a)

print(bool(False))
print(bool(None))
print(bool(0))

print("a" not in "Python")

x = 3
if (x > 5):
    print("X értéke nagyobb mint 5.")
elif (x > 2):
    print("X értéke nagyobb mint 2.")
else:
    print("X értéke nem nagyobb mint 5.")

z = 5
while(z > 1):
    print("Fut a ciklus")
    z -= 1

szoveg = "szoveg"
for betu in szoveg:
    print(betu)

for i in range(2, 11, 3):
    print("i változó értéke: ", i)

def fuggveny():
    print("Hello World!")

eredmeny = fuggveny()
print(eredmeny)