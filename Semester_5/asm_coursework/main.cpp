#include <iostream>
#include <stdio.h>
#include "matrixLib.h"
#include "Matrix.h"
using namespace std;

// сборка
// g++ matrixLib.cpp matrixLib.h main.cpp -o main.exe 
// g++ matrixLib.cpp matrixLib.h Matrix.cpp Matrix.h main.cpp -o main.exe 
// запуск
// start main.exe

void TestSum();
void PrintArray(int arr[], int len);

int main() {
    int arr1[6] = {1, 2, 3, 4, 5, 6};
    int arr2[6] = {1, 1, 1, 0, 0, 0};
    Matrix* M1 = new Matrix(arr1, 3, 2);
    Matrix* M2 = new Matrix(arr2, 3, 2);


    cout << M1->ToString();
    cout << M2->ToString();
    cout <<"SUM M1 + M1\n"<< Matrix::Sum(M1, M1)->ToString();
    cout <<"SUB M2 - M1\n"<<Matrix::Sub(M2, M1)->ToString();
    getchar();
}