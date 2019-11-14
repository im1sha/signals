import matplotlib.pyplot as plt
import numpy as np
import math


# N: 64, 128, 256 etc
# n: 0..M
# K < N
# M: K..2N
def main():
    phi = 0
    N = 64
    K = 1  # int(3 * N / 4)

    max_M = 5 * N

    square_root_of_2 = 0.707
    frequency = 1

    delta_amplitude = []
    delta_root_mean_square_a = []
    delta_root_mean_square_b = []

    fig, ax = plt.subplots(2, 2)
    y = []

    for M in range(K, max_M):
        xn_sum = 0
        xn_square_sum = 0
        y = []

        for n in range(M):
            xn = math.sin((2 * frequency * math.pi * n) / N + phi)
            y.append(xn)
            xn_sum += xn
            xn_square_sum += math.pow(xn, 2)

        re_x = 0
        im_x = 0

        for i in range(M):
            re_x += y[i] * math.cos(2 * math.pi * i / M)
            im_x += y[i] * math.sin(2 * math.pi * i / M)

        amp = 1 - 2 * math.sqrt(math.pow(re_x / M, 2) + math.pow(-im_x / M, 2))

        rms_a = square_root_of_2 - math.sqrt(xn_square_sum / (M + 1))
        rms_b = (square_root_of_2
                 - math.sqrt((xn_square_sum / (M + 1))
                             - math.pow(xn_sum / (M + 1), 2)))

        delta_amplitude.append(amp)
        delta_root_mean_square_a.append(rms_a)
        delta_root_mean_square_b.append(rms_b)

    x = np.linspace(K, max_M, max_M - K)
    x1 = np.linspace(0, max_M, max_M - 1)

    interval = 1.25
    ax[0][0].set_ylim(-interval, interval)
    ax[0][1].set_ylim(-interval, interval)
    ax[1][0].set_ylim(-interval, interval)
    ax[1][1].set_ylim(-interval, interval)

    ax[0][0].plot(x1, y)
    ax[0][1].plot(x, delta_amplitude)
    ax[1][0].plot(x, delta_root_mean_square_a)
    ax[1][1].plot(x, delta_root_mean_square_b)

    ax[0][0].set_title("sin")
    ax[0][1].set_title("delta amplitude")
    ax[1][0].set_title("delta root mean square a")
    ax[1][1].set_title("delta root mean square b")

    plt.show()


if __name__ == "__main__":
    main()
