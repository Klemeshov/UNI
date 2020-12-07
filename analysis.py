import matplotlib.pyplot as plt
import numpy as np
from luAlgorithm import generator, lu_decomposition

RANGE_N = (4, 81)


def f_plot(f):
    x = np.arange(*RANGE_N)
    fig, ax = plt.subplots()
    ax.scatter(x, f, c='blue', edgecolor='black', label="$f(n)$")
    ax.set_title("Измеренные значения трудоемкости")
    ax.set_xlabel("Размер входных данных (n)")
    ax.set_ylabel("Трудоемкость (мс)")
    ax.legend()
    plt.show()
    fig.savefig('data/f_plot.png')


def asymptotic_plot(f, c1, c2):
    x = np.arange(*RANGE_N)
    low = c1 * (x ** 3)
    up = c2 * (x ** 3)
    fig, ax = plt.subplots()
    ax.plot(x, up, color="green", label="$C_2n^3$")
    ax.scatter(x, f, c="red", edgecolor='black', label="$f(n)$")
    ax.plot(x, low, color="orange", label="$C_1n^3$")
    ax.set_title("Верхняя и нижняя асимптотика измеренных значений трудоёмкости")
    ax.set_xlabel("Размер входных данных (n)")
    ax.set_ylabel("Трудоёмкость (мс)")
    ax.legend()
    plt.show()
    fig.savefig('data/asymptotic_plot.png')


def ratio_f2n_fn_plot(ratio_f2_f1, n):
    fig, ax = plt.subplots()
    ax.set_title("Отношение измеренных значений трудоемкости\n при удвоении размера входных данных")
    ax.set_xlabel("Размер входных данных (n)")
    ax.scatter(n, ratio_f2_f1, marker='o', c="red", edgecolor='black')
    ax.plot(n, ratio_f2_f1, color="red", label="$f(2n)/f(n)$")
    ax.legend()
    plt.show()
    fig.savefig('data/ratio_f2_f1.png')


def empirical_analysis():
    range_n = RANGE_N
    m = 10
    f = [None] * (range_n[1] - range_n[0])

    for i, n in enumerate(range(*range_n)):
        f_n = [None] * m
        for j in range(m):
            a = generator(n)
            f_n[j], L, U = lu_decomposition(a)
            if L is None:
                j -= 1
        f[i] = sum(f_n) / m
        print(n)

    f_plot(f)

    with open('data/empirical_f_data.txt', 'w') as data:
        for fi in f:
            data.write(f"{str(fi)}\n")

    # f / g plot with asymptotic c1 & c2
    n = np.arange(*range_n)
    f = np.array(f)
    g = n**3
    ratio_f_g = f / g
    for i in range(len(n)):
        c1 = min(ratio_f_g[i:])
        c2 = max(ratio_f_g[i:])
        if c1 > 0 and c2 > 0:
            print('n0:', n[i])  # n0 = 4
            print('C1:', c1)  # c1 = 2.7494993065937393e-07
            print('C2:', c2)  # c2 = 1.5642493963241576e-06
            break

    asymptotic_plot(f, c1, c2)

    # f(2n) / f(n) plot
    n = range(*range_n)[:range_n[1] // 2 - range_n[0] + 1]
    f_n_1 = np.array(f[:range_n[1] // 2 - range_n[0] + 1])
    f_n_2 = np.array(f[range_n[0] * 2 - range_n[0]::2])
    ratio_f2_f1 = f_n_2 / f_n_1

    ratio_f2n_fn_plot(ratio_f2_f1, n)


empirical_analysis()
