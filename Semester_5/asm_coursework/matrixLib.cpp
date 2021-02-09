#include "matrixLib.h"
#include <iostream>
using namespace std;
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
void hello_world_matrix()
{
    int matr[3][2] = {{1, 2}, 
                      {3, 4}, 
                      {5, 6}};
    int n = 3, m = 2;
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

int* ArraySum(int* p1, int len1, int* p2, int len2) 
{
   
        

    
    return nullptr;
}