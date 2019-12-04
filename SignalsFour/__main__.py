from antialiasing import load_image, save_image, moving_average, moving_median, fourth_degree_parabola


def main():
    source = "test.bmp"
    for width in [3, 5, 7, 9]:
        save_image(moving_average(load_image(source), width), "avg" + str(width) + ".bmp")
        save_image(moving_median(load_image(source), width), "m" + str(width) + ".bmp")

    save_image(fourth_degree_parabola(load_image(source)), "p4.bmp")


if __name__ == "__main__":
    main()
