from drawer import draw_chart
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

        amp = 1 - (math.sqrt(math.pow(2 / M * re_x, 2)
                             + math.pow(2 / M * im_x, 2)))

        rms_a = square_root_of_2 - math.sqrt(xn_square_sum / (M + 1))
        rms_b = (square_root_of_2
                 - math.sqrt((xn_square_sum / (M + 1))
                             - math.pow(xn_sum / (M + 1), 2)))

        delta_amplitude.append(amp)
        delta_root_mean_square_a.append(rms_a)
        delta_root_mean_square_b.append(rms_b)

    draw_chart(K, max_M, delta_amplitude, delta_root_mean_square_a, delta_root_mean_square_b)


if __name__ == "__main__":
    main()
