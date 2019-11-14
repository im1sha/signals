import matplotlib.pyplot as pyplot
import numpy


def draw_chart(K, max_M, delta_amplitude, delta_root_mean_square_a, delta_root_mean_square_b):
    fig, ax = pyplot.subplots(3, 1, figsize=(10, 15))

    x = numpy.linspace(K, max_M, max_M - K)

    down_bound = -0.2
    ax[0].set_ylim(down_bound, 1.2)
    ax[1].set_ylim(down_bound, 0.8)
    ax[2].set_ylim(down_bound, 0.8)

    ax[0].plot(x, delta_amplitude)
    ax[1].plot(x, delta_root_mean_square_a)
    ax[2].plot(x, delta_root_mean_square_b)

    ax[0].set_title("delta amplitude")
    ax[1].set_title("delta root mean square a")
    ax[2].set_title("delta root mean square b")

    pyplot.show()
