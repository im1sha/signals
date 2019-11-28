import math
import random

from filter import Spectrum, filter_spectrum
from fourier_transform import DirectFourierTransformer, InverseFourierTransformer, FastFourierTransformer
from graphs import GraphDrawer, Graph


def generate_harmonic_sequence(length):
    return [10 * math.cos(2 * math.pi * i / length) for i in range(length)]


def generate_polyharmonic_sequence(length):
    polyharmonics_count = 30
    amplitudes = [1, 3, 5, 8, 10, 12, 16]
    phases = [math.pi / 6, math.pi / 4, math.pi / 3, math.pi / 2, 3 * math.pi / 4, math.pi]
    chosen_amplitudes = [random.choice(amplitudes) for _ in range(polyharmonics_count)]
    chosen_phases = [random.choice(phases) for _ in range(polyharmonics_count)]
    return [sum(chosen_amplitudes[j] * math.cos(2 * math.pi * j * i / length - chosen_phases[j])
                for j in range(polyharmonics_count)) for i in range(length)]


def task_2(sequence_length, phase_filtering):
    harmonic_sequence = generate_harmonic_sequence(sequence_length)
    direct_transformer = DirectFourierTransformer(harmonic_sequence)
    amplitude_spectrum = direct_transformer.get_amplitude_spectrum()
    phase_spectrum = [x if amplitude_spectrum[i] > phase_filtering else 0
                      for i, x in enumerate(direct_transformer.get_phase_spectrum())]
    restored_sequence = InverseFourierTransformer(amplitude_spectrum, phase_spectrum).restore_harmonic()

    drawer = GraphDrawer()
    drawer.add_plot(Graph(range(sequence_length), harmonic_sequence, "Original sequence"))
    drawer.add_stem(Graph(range(sequence_length), amplitude_spectrum, "Amplitude spectrum"))
    drawer.add_stem(Graph(range(sequence_length), phase_spectrum, "Phase spectrum"))
    drawer.add_plot(Graph(range(sequence_length), restored_sequence, "Restored sequence"))
    drawer.draw()
    drawer.show()


def task_3(sequence_length, phase_filtering):
    polyharmonic_sequence = generate_polyharmonic_sequence(sequence_length)
    direct_transformer = DirectFourierTransformer(polyharmonic_sequence)
    amplitude_spectrum = direct_transformer.get_amplitude_spectrum()
    phase_spectrum = [x if amplitude_spectrum[i] > phase_filtering else 0
                      for i, x in enumerate(direct_transformer.get_phase_spectrum())]
    restored_sequence = InverseFourierTransformer(amplitude_spectrum, phase_spectrum).restore_polyharmonic(True)
    restored_sequence_without_phases \
        = InverseFourierTransformer(amplitude_spectrum, phase_spectrum).restore_polyharmonic(False)

    drawer = GraphDrawer()
    drawer.add_plot(Graph(range(sequence_length), polyharmonic_sequence, "Original sequence"))
    drawer.add_stem(Graph(range(sequence_length), amplitude_spectrum, "Amplitude spectrum"))
    drawer.add_stem(Graph(range(sequence_length), phase_spectrum, "Phase spectrum"))
    drawer.add_plot(Graph(range(sequence_length), restored_sequence, "Restored sequence"))
    drawer.add_plot(Graph(range(sequence_length), restored_sequence_without_phases,
                          "Restored sequence w/o phase spectrum"))
    drawer.draw()
    drawer.show()


def task_4(sequence_length, phase_filtering):
    polyharmonic_sequence = generate_polyharmonic_sequence(sequence_length)
    fast_transformer = FastFourierTransformer(polyharmonic_sequence)
    amplitude_spectrum = fast_transformer.get_amplitude_spectrum()
    phase_spectrum = [x if amplitude_spectrum[i] > phase_filtering else 0
                      for i, x in enumerate(fast_transformer.get_phase_spectrum())]
    restored_sequence = InverseFourierTransformer(amplitude_spectrum, phase_spectrum).restore_polyharmonic(True)

    drawer = GraphDrawer()
    drawer.add_plot(Graph(range(sequence_length), polyharmonic_sequence, "Original sequence"))
    drawer.add_stem(Graph(range(sequence_length), amplitude_spectrum, "Amplitude spectrum"))
    drawer.add_stem(Graph(range(sequence_length), phase_spectrum, "Phase spectrum"))
    drawer.add_plot(Graph(range(sequence_length), restored_sequence, "Restored sequence"))
    drawer.draw()
    drawer.show()


def task_5(sequence_length, phase_filtering, low, high):
    polyharmonic_sequence = generate_polyharmonic_sequence(sequence_length)
    direct_transformer = DirectFourierTransformer(polyharmonic_sequence)
    amplitude_spectrum = direct_transformer.get_amplitude_spectrum()
    phase_spectrum = [x if amplitude_spectrum[i] > phase_filtering else 0
                      for i, x in enumerate(direct_transformer.get_phase_spectrum())]
    filtered = filter_spectrum(Spectrum(amplitude_spectrum, phase_spectrum), low, high)
    restored = InverseFourierTransformer(filtered.amplitude, filtered.phase).restore_polyharmonic()

    drawer = GraphDrawer()
    drawer.add_plot(Graph(range(sequence_length), polyharmonic_sequence, "Original sequence"))
    drawer.add_stem(Graph(range(sequence_length), amplitude_spectrum, "Amplitude spectrum"))
    drawer.add_stem(Graph(range(sequence_length), phase_spectrum, "Phase spectrum"))
    drawer.add_stem(Graph(range(sequence_length), filtered.amplitude, "Filtered amplitude"))
    drawer.add_stem(Graph(range(sequence_length), filtered.phase, "Filtered phase"))
    drawer.add_plot(Graph(range(sequence_length), restored, "Restored filtered"))
    drawer.draw()
    drawer.show()


def main():

    length = 64
    filter = 0.001

    task_2(length, filter)
    task_3(length, filter)
    task_4(length, filter)
    task_5(length, filter, 0, 5)


if __name__ == "__main__":
    main()
