import matplotlib.pyplot as plt
import numpy as np
import math


def main():
    N = 64
    K = 2
    # xSin = 0
    # xSinSquare = 0
    # aSin = 0
    f = 1
    fi = 0
    A = []
    SKZa = []
    SKZb = []
    fig, a = plt.subplots(2, 2)
    for M in range(K, 5 * N):
        xnSum = 0
        xnSquareSum = 0
        y = []
        for n in range(M):
            xn = math.sin((2 * f * math.pi * n) / N + fi)
            y.append(xn)
            xnSum += xn
            xnSquareSum += math.pow(xn, 2)

        reX = 0
        imX = 0
        for i in range(M):
            reX += y[i] * math.cos(2 * math.pi * i / M)
            imX += y[i] * math.sin(2 * math.pi * i / M)

        aSin = 1 - 2 * math.sqrt(math.pow(reX / M, 2) + math.pow(-imX / M, 2))
        xSin = 0.707 - (math.sqrt((xnSquareSum / (M + 1))))
        xSinSquare = 0.707 - (math.sqrt((xnSquareSum / (M + 1))) - math.pow((xnSum / (M + 1)), 2))
        A.append(aSin)
        SKZa.append(xSin)
        SKZb.append(xSinSquare)

        # xSinPrev = xSin
        # xSinSquarePrev = xSinSquare
        # aSinPrev = aSin
    x = np.linspace(K, 5 * N, 5 * N - K)
    x1 = np.linspace(0, 5 * N, 5 * N - 1)

    a[0][0].set_ylim(-1, 1)
    a[0][1].set_ylim(-1, 1.10)
    a[1][0].set_ylim(-1, 1)
    a[1][1].set_ylim(-1, 1)

    a[0][0].plot(x1, y)
    a[0][1].plot(x, A)
    a[1][0].plot(x, SKZa)
    a[1][1].plot(x, SKZb)

    a[0][0].set_title("Сигнал")
    a[0][1].set_title("A")
    a[1][0].set_title("СКЗ")
    a[1][1].set_title("СКО")

    plt.show()


if __name__ == "__main__":
    main()
