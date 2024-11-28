# # Rekurzív függvény definíciója
# def a_i(i):
#     if i == 0:
#         return 8
#     elif i == 1:
#         return 5
#     else:
#         return (a_i(i - 1)**2 + 2 * a_i(i - 2)) / 10

# # Az első 11 elem kiszámítása és kiíratása
# for i in range(11):
#     print(f"a_{i} = {a_i(i):.6f}")




def first(i):
    if i == 0:
        return 8
    if i == 1:
        return 5
    return (first(i-1) * first(i-1) + 2 * first(i-2)) / 10


def fibonacci(i, c1, c2, c3):
    if i == 0:
        return 1
    if i == 1:
        return c1
    if i >= 2:
        return c2 * fibonacci(i-2, c1, c2, c3) + c3 * fibonacci(i-1, c1, c2, c3)
    

def szamol(a, n, x):
    # print(f"a: {a}")
    # print(f"n: {n}")
    # print(f"x: {x}")
    if n == 0:
        return x
    return szamol(a, n-1, (x/2 + a/(2*x)))

@staticmethod
def foo(x, y):
    if (x >= y):
        if (x % y == 0):
            print(y)
            return foo(x/y, y)
        return foo(x, y+1)


if __name__ == "__main__":
    # for i in range(0,11):
    #     print(first(i))
    # c1 = int(input("Add meg a c1 értékét: "))
    # c2 = int(input("Add meg a c2 értékét: "))
    # c3 = int(input("Add meg a c3 értékét: "))
    # for i in range(0,11):
    #     print(fibonacci(i, c1, c2, c3))

    # print(f"A  szamol(32,6,4) visszatérési értéke: {szamol(32,6,4)}")

    # print(f"A  foo(900,2) visszatérési értéke: {foo(900,2)}")

    foo(900,2)



























