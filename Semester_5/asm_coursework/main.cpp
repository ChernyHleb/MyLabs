#include <iostream>
#include <stdio.h>
#include "matrixLib.h"
using namespace std;

// сборка
// g++ matrixLib.cpp matrixLib.h main.cpp -o main.exe 
// запуск
// start main.exe

void Test_ArraySum();
void PrintArray(int arr[], int len);

int main() {
    //Test_ArraySum();
    hello_world_matrix();
    //hello_world_array();
    getchar();
}

void Test_ArraySum()
{
    int len = 3;
    int arr1[] = {1, 2, 3};
    int arr2[] = {4, 5, 6};
    int* result = ArraySum(arr1, len, arr2, len);
    PrintArray(result, len);
}

void PrintArray(int* arr, int len)
{
    for(int i = 0; i < len; i ++)
    {
        printf("%d\t", *(arr + i));
    }
    printf("\n");
}