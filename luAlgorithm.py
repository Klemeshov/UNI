import random
import time

import numpy as np


def print_matrix(matrix):
    for i in range(len(matrix)):
        for j in range(len(matrix[i])):
            print(matrix[i][j], end=" ")
        print()


def generator(n):
    A = np.empty((n, n), dtype=int)

    for i in range(n):
        for j in range(n):
            A[i][j] = random.randint(-2000, 2000)
    return A


def lu_decomposition(A):
    timer_start = time.time()
    n = len(A)
    L = np.zeros((n, n))
    U = np.zeros((n, n))

    try:
        for i in range(n):
            L[i][i] = 1

        for i in range(n):
            for j in range(n):
                if i <= j:
                    U[i][j] = A[i][j]
                    for k in range(i):
                        U[i][j] -= L[i][k] * U[k][j]
                else:
                    L[i][j] = A[i][j]
                    for k in range(j):
                        L[i][j] -= L[i][k] * U[k][j]
                    L[i][j] /= U[j][j]
        return time.time() - timer_start, L, U
    except Exception:
        return time.time() - timer_start, None, None
