#ifndef __MATRIX_H__
#define __MATRIX_H__

#include <string>
#include <cstdlib>
using namespace std;

class Matrix
{
private:
    int n;
    int m;
    int **matrix;
public:
    //Вспомогательные функции
    Matrix(int ** matrix, int n, int m);
    Matrix(int n, int m);
    Matrix(int dim);
    string ToString();
    string ToShortString();
    int GetN();
    int GetM();
    int ** GetMatrix();
    //______________________________________
    //__Функции с Ассемблерными вставками___
    // сумма матриц
    static Matrix* Sum(int** p1, int** p2, int n, int m);
    // разность матриц
    static Matrix* Sub(int** p1, int** p2, int n, int m);
    // умножение матриц
    static Matrix* Mul(int** p1, int** p2, int n1, int m1, int n2, int m2);
    // Нахождение детерминанта
    static Matrix* Det(int** p, int dim);
    // Нахождение обратной матрицы
    static Matrix* Rev(int ** p, int n, int m);
    // Умножение матрицы на число
    static Matrix* CMul(int** p, int n, int m, int c);
    // Транспонирование
    static Matrix* Tran(int** p, int n, int m);
};

#endif