# -*- coding: utf-8 -*-

import matplotlib.pyplot as plt

# Чтение данных из файла
with open('test.txt', 'r') as file:
    data = file.read().split('\n\n')


def time_numVariables():
    x = []  # количество переменных
    y = []  # время работы алгоритма Квайна Маккласки
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        quine_time, map_time, coverage_time = map(int, lines[1].split())

        x.append(vars_count)
        y.append(quine_time + map_time + coverage_time)

    _, axs = plt.subplots(1, 2, figsize=(10, 5))

    # Первый график (обычный)
    axs[0].plot(x, y, marker='.', linestyle='none')
    axs[0].set_title('Обычный график')
    axs[0].set_xlabel('Количество переменных')
    axs[0].set_ylabel('Время работы, ms')

    # Второй график (с логарифмической шкалой по оси y)
    axs[1].plot(x, y, marker='.', linestyle='none')
    axs[1].set_yscale('log')
    axs[1].set_title('График с логарифмической шкалой')
    axs[1].set_xlabel('Количество переменных')
    axs[1].set_ylabel('Время работы, ms')
    # Отображение графиков
    plt.show()


def time_numTerms():
    x = []  # количество переменных
    y = []  # время работы алгоритма Квайна Маккласки
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        quine_time, map_time, coverage_time = map(int, lines[1].split())

        x.append(pos_terms_count)
        y.append(quine_time + map_time + coverage_time)

    _, axs = plt.subplots(1, 2, figsize=(10, 5))

    # Первый график (обычный)
    axs[0].plot(x, y, marker='.', linestyle='none')
    axs[0].set_title('Обычный график')
    axs[0].set_xlabel('Количество термов')
    axs[0].set_ylabel('Время работы, ms')
    axs[0].axvline(x=64)
    axs[0].axvline(x=128)
    axs[0].axvline(x=256)
    axs[0].axvline(x=512)

    # Второй график (с логарифмической шкалой по оси y)
    axs[1].plot(x, y, marker='.', linestyle='none')
    axs[1].set_yscale('log')
    axs[1].set_title('График с логарифмической шкалой')
    axs[1].set_xlabel('Количество термов')
    axs[1].set_ylabel('Время работы, ms')
    axs[1].axvline(x=64)
    axs[1].axvline(x=128)
    axs[1].axvline(x=256)
    axs[1].axvline(x=512)
    # Отображение графиков
    plt.show()


def quine_numTerms():
    x = []  # количество переменных
    y = []  # время работы алгоритма Квайна Маккласки
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        quine_time, map_time, coverage_time = map(int, lines[1].split())

        x.append(pos_terms_count)
        y.append(quine_time)

    _, axs = plt.subplots(1, 2, figsize=(10, 5))

    # Первый график (обычный)
    axs[0].plot(x, y, marker='.', linestyle='none')
    axs[0].set_title('Обычный график')
    axs[0].set_xlabel('Количество термов')
    axs[0].set_ylabel('Время работы, ms')
    axs[0].axvline(x=64)
    axs[0].axvline(x=128)
    axs[0].axvline(x=256)
    axs[0].axvline(x=512)

    # Второй график (с логарифмической шкалой по оси y)
    axs[1].plot(x, y, marker='.', linestyle='none')
    axs[1].set_yscale('log')
    axs[1].set_title('График с логарифмической шкалой')
    axs[1].set_xlabel('Количество термов')
    axs[1].set_ylabel('Время работы, ms')
    axs[1].axvline(x=64)
    axs[1].axvline(x=128)
    axs[1].axvline(x=256)
    axs[1].axvline(x=512)
    # Отображение графиков
    plt.show()


def buildMatrix_numTerms():
    x = []  # количество переменных
    y = []  # время работы алгоритма Квайна Маккласки
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        quine_time, map_time, coverage_time = map(int, lines[1].split())

        x.append(pos_terms_count)
        y.append(map_time)

    plt.plot(x, y, marker='o', linestyle='none')
    plt.title('Время строительства матрицы покрытий от количества положительных термов')
    plt.xlabel('Количество термов')
    plt.ylabel('Время работы')
    plt.axvline(x=64)
    plt.axvline(x=128)
    plt.axvline(x=256)
    plt.axvline(x=512)
    plt.show()


def resolveMatrix_numTerms():
    x = []  # количество переменных
    y = []  # время работы алгоритма Квайна Маккласки
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        quine_time, map_time, coverage_time = map(int, lines[1].split())

        x.append(pos_terms_count)
        y.append(coverage_time)

    plt.plot(x, y, marker='o', linestyle='none')
    plt.title('Время решения задачи о минимальном покрытии от количества положительных термов')
    plt.xlabel('Количество термов')
    plt.ylabel('Время работы')
    plt.axvline(x=64)
    plt.axvline(x=128)
    plt.axvline(x=256)
    plt.axvline(x=512)
    plt.show()


def quine6_numTerms():
    x = []  # количество переменных
    y = []  # время работы алгоритма Квайна Маккласки
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        quine_time, map_time, coverage_time = map(int, lines[1].split())
        if vars_count == 6:
            x.append(pos_terms_count)
            y.append(quine_time)

    plt.plot(x, y, marker='o', linestyle='none')
    plt.xlabel('Количество термов')
    plt.ylabel('Время работы')
    plt.axvline(x=64)
    plt.show()


def quine7_numTerms():
    x = []  # количество переменных
    y = []  # время работы алгоритма Квайна Маккласки
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        quine_time, map_time, coverage_time = map(int, lines[1].split())
        if vars_count == 7:
            x.append(pos_terms_count)
            y.append(quine_time)

    plt.plot(x, y, marker='o', linestyle='none')
    plt.xlabel('Количество термов')
    plt.ylabel('Время работы')
    plt.axvline(x=128)
    plt.show()


def quine8_numTerms():
    x = []  # количество переменных
    y = []  # время работы алгоритма Квайна Маккласки
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        quine_time, map_time, coverage_time = map(int, lines[1].split())
        if vars_count == 8:
            x.append(pos_terms_count)
            y.append(quine_time)

    _, axs = plt.subplots(1, 2, figsize=(10, 5))

    # Первый график (обычный)
    axs[0].plot(x, y, marker='.', linestyle='none')
    axs[0].set_title('Обычный график')
    axs[0].set_xlabel('Количество термов')
    axs[0].set_ylabel('Время работы, ms')
    axs[0].axvline(x=256)

    # Второй график (с логарифмической шкалой по оси y)
    axs[1].plot(x, y, marker='.', linestyle='none')
    axs[1].set_yscale('log')
    axs[1].set_title('График с логарифмической шкалой')
    axs[1].set_xlabel('Количество термов')
    axs[1].set_ylabel('Время работы, ms')
    axs[1].axvline(x=256)
    # Отображение графиков
    plt.show()


def quine9_numTerms():
    x = []  # количество переменных
    y = []  # время работы алгоритма Квайна Маккласки
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        quine_time, map_time, coverage_time = map(int, lines[1].split())
        if vars_count == 9:
            x.append(pos_terms_count)
            y.append(quine_time)
    _, axs = plt.subplots(1, 2, figsize=(10, 5))

    # Первый график (обычный)
    axs[0].plot(x, y, marker='.', linestyle='none')
    axs[0].set_title('Обычный график')
    axs[0].set_xlabel('Количество термов')
    axs[0].set_ylabel('Время работы, ms')
    axs[0].axvline(x=512)

    # Второй график (с логарифмической шкалой по оси y)
    axs[1].plot(x, y, marker='.', linestyle='none')
    axs[1].set_yscale('log')
    axs[1].set_title('График с логарифмической шкалой')
    axs[1].set_xlabel('Количество термов')
    axs[1].set_ylabel('Время работы, ms')
    axs[1].axvline(x=512)
    # Отображение графиков
    plt.show()


def karno_numVariables():
    x = []
    y = []
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        karno_time, = map(int, lines[1].split())

        x.append(vars_count)
        y.append(karno_time)

    _, axs = plt.subplots(1, 2, figsize=(10, 5))

    # Первый график (обычный)
    axs[0].plot(x, y, marker='.', linestyle='none')
    axs[0].set_title('Обычный график')
    axs[0].set_xlabel('Количество переменных')
    axs[0].set_ylabel('Время работы, ms')

    # Второй график (с логарифмической шкалой по оси y)
    axs[1].plot(x, y, marker='.', linestyle='none')
    axs[1].set_yscale('log')
    axs[1].set_title('График с логарифмической шкалой')
    axs[1].set_xlabel('Количество переменных')
    axs[1].set_ylabel('Время работы, ms')
    # Отображение графиков
    plt.show()


def karno_numTerms():
    x = []
    y = []
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        karno_time, = map(int, lines[1].split())

        x.append(pos_terms_count)
        y.append(karno_time)

    _, axs = plt.subplots(1, 2, figsize=(10, 5))

    # Первый график (обычный)
    axs[0].plot(x, y, marker='.', linestyle='none')
    axs[0].set_title('Обычный график')
    axs[0].set_xlabel('Количество положительных терм')
    axs[0].set_ylabel('Время работы, ms')

    # Второй график (с логарифмической шкалой по оси y)
    axs[1].plot(x, y, marker='.', linestyle='none')
    axs[1].set_yscale('log')
    axs[1].set_title('График с логарифмической шкалой')
    axs[1].set_xlabel('Количество положительных терм')
    axs[1].set_ylabel('Время работы, ms')
    # Отображение графиков
    plt.show()


def karno6_numTerms():
    x = []
    y = []
    for block in data:
        lines = block.split('\n')
        if len(lines) < 2:
            continue
        vars_count, pos_terms_count = map(int, lines[0].split())
        karno_time, = map(int, lines[1].split())
        if vars_count == 6:
            x.append(pos_terms_count)
            y.append(karno_time)

    _, axs = plt.subplots(1, 2, figsize=(10, 5))

    # Первый график (обычный)
    axs[0].plot(x, y, marker='.', linestyle='none')
    axs[0].set_title('Обычный график')
    axs[0].set_xlabel('Количество положительных терм')
    axs[0].set_ylabel('Время работы, ms')

    # Второй график (с логарифмической шкалой по оси y)
    axs[1].plot(x, y, marker='.', linestyle='none')
    axs[1].set_yscale('log')
    axs[1].set_title('График с логарифмической шкалой')
    axs[1].set_xlabel('Количество положительных терм')
    axs[1].set_ylabel('Время работы, ms')
    # Отображение графиков
    plt.show()


# time_numVariables()
# time_numTerms()
# quine_numTerms()
# buildMatrix_numTerms()
# resolveMatrix_numTerms()
# quine6_numTerms()
# quine7_numTerms()
# quine8_numTerms()
# quine9_numTerms()
# karno_numVariables()
# karno_numTerms()
# karno6_numTerms()
