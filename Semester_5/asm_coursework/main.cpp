#include <iostream>
#include <stdio.h>
#include "matrixLib.h"
using namespace std;

// сборка
// g++ matrixLib.cpp matrixLib.h main.cpp -o main.exe 
// запуск
// start main.exe

void Test_ArraySum();
void PrintArray(float arr[], int len);

int main() {
    Test_ArraySum();
    getchar();
}

void Test_ArraySum()
{
    int len = 3;
    float array1[] = {1, 2, 3};
    float array2[] = {4, 5, 6};
    float result[] = {0, 0, 0};

    PrintArray(array1, len);
}

void PrintArray(float* arr, int len)
{
    for(int i = 0; i < len; i ++)
    {
        printf("%f\t", arr[i]);
    }
    printf("\n");
}