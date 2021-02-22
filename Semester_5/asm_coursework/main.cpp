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
    int arr1[6] = {1, 2, -3, 4, -5, 6};
    int arr2[6] = {1, 1, -1, 0, 0, 0};
    int arr3[12] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
    Matrix* M1 = new Matrix(arr1, 3, 2);
    Matrix* M2 = new Matrix(arr2, 3, 2);
    Matrix* M3 = new Matrix(arr3, 4, 3);


    cout <<"M1\n"<< M1->ToString();
    cout <<"M2\n"<< M2->ToString();
    cout <<"M3\n"<< M3->ToString();
    cout << "-------------------------------\n";
    //cout <<"SUM: M1 + M1\n"<< Matrix::Sum(M1, M1)->ToString();
    //cout <<"SUB: M2 - M1\n"<< Matrix::Sub(M2, M1)->ToString();
    //cout << "CMUL: M1 * 3\n" << Matrix::CMul(M1, 3)->ToString();
    //cout << "CMUL: M1 * -5\n" << Matrix::CMul(M1, -5)->ToString();
    cout << "TRAN: (M3)T\n" << Matrix::Tran(M3)->ToString();
    
    getchar();
}