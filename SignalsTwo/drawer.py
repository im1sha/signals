import matplotlib.pyplot as plt
import numpy as np


def draw_chart(K, max_M, delta_amplitude, delta_root_mean_square_a, delta_root_mean_square_b):
    fig, ax = plt.subplots(3, 1)

    x = np.linspace(K, max_M, max_M - K)

    interval = 1.2
    ax[0].set_ylim(-interval + 1, interval)
    ax[1].set_ylim(-interval + 1, interval)
    ax[2].set_ylim(-interval + 1, interval)

    ax[0].plot(x, delta_amplitude)
    ax[1].plot(x, delta_root_mean_square_a)
    ax[2].plot(x, delta_root_mean_square_b)

    ax[0].set_title("delta amplitude")
    ax[1].set_title("delta root mean square a")
    ax[2].set_title("delta root mean square b")

    plt.show()
