from drawer import draw_chart
import math


def get_sin_part(frequency, n, N, phi):
    return math.sin((2 * frequency * math.pi * n) / N + phi)


def get_cos_part(frequency, n, N, phi):
    return math.cos((2 * frequency * math.pi * n) / N + phi)


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
            xn = get_sin_part(frequency, n, N, phi)
            y.append(xn)
            xn_sum += xn
            xn_square_sum += math.pow(xn, 2)

        re_x = 0
        im_x = 0

        for i in range(M):
            re_x += get_cos_part(frequency, i, M, phi) * y[i]
            im_x += get_sin_part(frequency, i, M, phi) * y[i]

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
