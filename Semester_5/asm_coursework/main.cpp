#include <iostream>
#include <stdio.h>
#include "Matrix.h"
using namespace std;

// сборка
// g++ Matrix.cpp Matrix.h main.cpp -o main.exe 
// запуск
// start main.exe

void hello_world_array();
void hello_world_matrix(int** matr, int n, int m);


void TestSum();
void PrintArray(int arr[], int len);

int main() {
    /*int arr1[6] = {1, 2, -3, 4, -5, 6};
    int arr2[6] = {1, 1, -1, 0, 0, 0};
    int arr3[12] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
    int arr4[6] = {1, 2, 3, 4, 5, 6};
    int arr5[6] = {7, 8, 9, 1, 2, 3};
    int arr6[4] = {-2, 1, 5, 4};
    int arr7[2] = {3, -1};

    Matrix* M1 = new Matrix(arr1, 3, 2);
    Matrix* M2 = new Matrix(arr2, 3, 2);
    Matrix* M3 = new Matrix(arr3, 4, 3);
    Matrix* M4 = new Matrix(arr4, 2, 3);
    Matrix* M5 = new Matrix(arr5, 3, 2);
    Matrix* M6 = new Matrix(arr6, 2, 2);
    Matrix* M7 = new Matrix(arr7, 2, 1);*/

    //cout <<"M1\n"<< M1->ToString();
    //cout <<"M2\n"<< M2->ToString();
    //cout <<"M3\n"<< M3->ToString();
    //cout <<"M4\n"<< M4->ToString();
    //cout <<"M5\n"<< M5->ToString();
    //cout <<"M6\n"<< M6->ToString();
    //cout <<"M7\n"<< M7->ToString();
    //cout << "-------------------------------\n";
    //cout <<"SUM: M1 + M1\n"<< Matrix::Sum(M1, M1)->ToString();
    //cout <<"SUB: M2 - M1\n"<< Matrix::Sub(M2, M1)->ToString();
    //cout << "CMUL: M1 * 3\n" << Matrix::CMul(M1, 3)->ToString();
    //cout << "CMUL: M1 * -5\n" << Matrix::CMul(M1, -5)->ToString();
    //cout << "TRAN: (M3)T\n" << Matrix::Tran(M3)->ToString();
    //cout << "TRAN: (M1)T\n" << Matrix::Tran(M1)->ToString();
    //cout << "MUL: M4 x M5\n" << Matrix::Mul(M4, M5)->ToString();
    //cout << "MUL: M6 x M7\n" << Matrix::Mul(M6, M7)->ToString();

    /*int arr1[4] = {1, 2, 3, 4};
    int arr2[4] = {0, -2, 0, 0};
    int arr3[4] = {0, 10, 10, 0};

    Matrix* M1 = new Matrix(arr1, 2, 2);
    Matrix* M2 = new Matrix(arr2, 2, 2);
    Matrix* M3 = new Matrix(arr3, 2, 2);

    cout <<"M1\n"<< M1->ToString();
    cout <<"M2\n"<< M2->ToString();
    cout <<"M3\n"<< M3->ToString();

    Matrix* sum_res = Matrix::Sum(M1, M2);

    cout <<"SUM: M1 + M2\n"<< sum_res->ToString();
    Matrix::Mul(sum_res, M3);*/
    
   /*int str1[2] = {1, 0};
   int str2[2] = {3, 4};

    int str3[2] = {0, 10};
    int str4[2] = {10, 0};

    cout << "MUL_Vectors 1 and 3: " << Matrix::MulVectors(str1, str3, 2) << endl;
    cout << "MUL_Vectors 1 and 4: " << Matrix::MulVectors(str1, str4, 2) << endl;
    cout << "MUL_Vectors 2 and 3: " << Matrix::MulVectors(str2, str3, 2) << endl;
    cout << "MUL_Vectors 2 and 4: " << Matrix::MulVectors(str1, str4, 2) << endl;
    */

   int arr1[9] = {5, 8, -4, 6, 9, -5, 4, 7, -3};
   int arr2[9] = {3, 2, 5, 4, -1, 3, 9, 6, 5};

   Matrix* M1 = new Matrix(arr1, 3, 3);
   Matrix* M2 = new Matrix(arr2, 3, 3);
   cout << M1->ToString() << "MUL\n" << M2->ToString();

   cout << "RESULT:\n" << Matrix::Mul(M1, M2)->ToString();

    getchar();
}



// бесполезная функция для изучения ассемблера 1
void hello_world_array()
{   
    int arr[3] = {1, 2, 3};
    int n = 3;
    int *p = arr;
    int *out = (int*) malloc(n * sizeof(int));

    printf("before:\n");
    for (int i = 0; i < 3; i++){
        *(out + i) = 0;
        printf("%d: %d|%d\n", i,*(p + i), *(out + i));
    }

    asm("xor %%ecx, %%ecx\n\t" //обуляем счетчик
        "label:\n\t" // метка
        "add $1, (%0, %%ecx, 4)\n\t" // добавляем единичку в out (адрес, индекс, размер)
        "add $1, %%ecx \n\t" // инкрементируем счетчик
        "cmp %%ecx, %1\n\t" // сравниваем
        "jne label" // если не равны то переход
        ::"r"(out), "m"(n)
        
        );

    printf("after:\n");
    for(int i = 0; i < 3; i ++){
        printf("%d: %d|%d\n", i,*(p + i), *(out + i));
    }
}
// бесполезная функция для изучения ассемблера 2
void hello_world_matrix(int matr[][12], int n, int m)
{
    printf("before:\n");
    for(int i = 0; i < n; i++)
        for(int j = 0; j < m; j++)
            printf("%d-%d: %d\n", i, j, matr[i][j]);

    asm("xor %%ecx, %%ecx\n\t"
        "inc %%ecx\n\t"
        "add $1, (%0, %%ecx,4)\n\t"
        "inc %%ecx\n\t"
        "add $1, (%0, %%ecx,4)\n\t"
        ::"r"(matr), "m"(n), "m"(m)
    );

    printf("after:\n");
    for(int i = 0; i < n; i++)
        for(int j = 0; j < m; j++)
            printf("%d-%d: %d\n", i, j, matr[i][j]);
}