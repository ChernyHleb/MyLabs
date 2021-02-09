#ifndef __MATRIXLIB_H__
#define __MATRIXLIB_H__

void hello_world_array();
void hello_world_matrix();
// сумма матриц
int** Sum(int** p1, int** p2, int n, int m);
// разность матриц
int** Sub(int** p1, int** p2, int n, int m);
// умножение матриц
int** Mul(int** p1, int** p2, int n1, int m1, int n2, int m2);
// Нахождение детерминанта
int** Det(int** p, int dim);
// Нахождение обратной матрицы
int** Rev(int ** p, int n, int m);
// Умножение матрицы на число
int** CMul(int** p, int n, int m, int c);
// Транспонирование
int** Tran(int** p, int n, int m);

#endif