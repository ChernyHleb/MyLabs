#ifndef __MATRIX_H__
#define __MATRIX_H__

#include <string>
#include <cstdlib>
#include <iostream>
using namespace std;

class Matrix
{
private:
    //n!= 0  m != 0
    int n;
    int m;
    // матрица - массив длины NxM
    int *matrix;
public:
    //Вспомогательные функции
    Matrix(int* matrix, int n, int m);
    Matrix(int n, int m);
    Matrix(int dim);
    Matrix();
    ~Matrix();
    string ToString();
    string ToShortString();
    int GetN();
    int GetM();
    int* GetMatrix();
    /*______________________________________
    ___Функции с Ассемблерными вставками____
    ---------------------------------------*/
    // сумма матриц
    static Matrix* Sum(Matrix* m1, Matrix* m2);
    // разность матриц
    static Matrix* Sub(Matrix* m1, Matrix* m2);
    // умножение матриц
    static Matrix* Mul(Matrix* m1, Matrix* m2);
    // Нахождение детерминанта
    static Matrix* Det(Matrix* m);
    // Нахождение обратной матрицы
    static Matrix* Rev(Matrix* m);
    // Умножение матрицы на число
    static Matrix* CMul(Matrix* m, int c);
    // Транспонирование
    static Matrix* Tran(Matrix* m);
};

#endif