from PIL import Image
from statistics import median


def load_image(path):
    return Image.open(path, 'r').convert('RGB')


def save_image(image, path):
    image.save(path)


def fourth_degree_parabola(image):
    def __fourth_degree_parabola_for_channel(arr):
        return int(1 / 429 * (15 * arr[0]
                              - 55 * arr[1]
                              + 30 * arr[2]
                              + 135 * arr[3]
                              + 179 * arr[4]
                              + 135 * arr[5]
                              + 30 * arr[6]
                              - 55 * arr[7]
                              + 15 * arr[8]))

    image_width, image_height = image.size
    result = Image.new('RGB', (image_width, image_height))
    half_of_window = 1

    for y in range(half_of_window, image_height - half_of_window):
        for x in range(half_of_window, image_width - half_of_window):
            x_range = __get_window_range(x, half_of_window, image_width)
            y_range = __get_window_range(y, half_of_window, image_height)
            window_pixels = [(x, y) for x in x_range for y in y_range]

            pixel_red = __fourth_degree_parabola_for_channel(__get_color_values(image, window_pixels, 'red'))
            pixel_green = __fourth_degree_parabola_for_channel(__get_color_values(image, window_pixels, 'green'))
            pixel_blue = __fourth_degree_parabola_for_channel(__get_color_values(image, window_pixels, 'blue'))
            result.putpixel((x, y), (pixel_red, pixel_green, pixel_blue))
    return result


def moving_average(image, window_length):
    def __moving_average_for_channel(arr):
        return sum(arr) // len(arr)

    return __window_function(image, window_length, __moving_average_for_channel)


def moving_median(image, window_length):
    def __moving_median_for_channel(arr):
        return int(median(arr))

    return __window_function(image, window_length, __moving_median_for_channel)


def __window_function(image, window_length, func):
    assert window_length % 2 == 1, "Window side length should be odd"
    image_width, image_height = image.size
    result = Image.new('RGB', (image_width, image_height))
    half_of_window = window_length // 2

    for y in range(image_height):
        for x in range(image_width):
            x_range = __get_window_range(x, half_of_window, image_width)
            y_range = __get_window_range(y, half_of_window, image_height)
            window_pixels = [(x, y) for x in x_range for y in y_range]

            pixel_red = func(__get_color_values(image, window_pixels, 'red'))
            pixel_green = func(__get_color_values(image, window_pixels, 'green'))
            pixel_blue = func(__get_color_values(image, window_pixels, 'blue'))
            result.putpixel((x, y), (pixel_red, pixel_green, pixel_blue))
    return result


def __get_color_values(image, pixels_coords, color_name):
    colors_to_tuple_pos = {'red': 0,
                           'green': 1,
                           'blue': 2}
    assert color_name in colors_to_tuple_pos.keys(), "Unknown color"
    return [image.getpixel(pixel)[colors_to_tuple_pos[color_name]] for pixel in pixels_coords]


def __get_window_range(current, window_half_width, length):
    return range(max(current - window_half_width, 0), min(current + window_half_width + 1, length))
