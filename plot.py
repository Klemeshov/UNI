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

    plt.plot(x, y, marker='o', linestyle='none')
    plt.title('Время работы алгоритма Квайна Маккласки от количества переменных')
    plt.xlabel('Количество переменных')
    plt.ylabel('Время работы')
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

    plt.plot(x, y, marker='o', linestyle='none')
    plt.title('Время работы алгоритма Квайна Маккласки от количества положительных термов')
    plt.xlabel('Количество термов')
    plt.ylabel('Время работы')
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

    plt.plot(x, y, marker='o', linestyle='none')
    plt.title('Время работы поиска минтермов от количества положительных термов')
    plt.xlabel('Количество термов')
    plt.ylabel('Время работы')
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
    plt.title('Время время поиска минтермов при 6 переменных от количества положительных термов')
    plt.xlabel('Количество термов')
    plt.ylabel('Время работы')
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
    plt.title('Время время поиска минтермов при 7 переменных от количества положительных термов')
    plt.xlabel('Количество термов')
    plt.ylabel('Время работы')
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

    plt.plot(x, y, marker='o', linestyle='none')
    plt.title('Время время поиска минтермов при 8 переменных от количества положительных термов')
    plt.xlabel('Количество термов')
    plt.ylabel('Время работы')
    plt.show()

quine8_numTerms()