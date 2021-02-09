#include "matrixLib.h"
#include <iostream>
using namespace std;

void hello_world()
{
    // тестируем ассемблер
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

int* ArraySum(int* p1, int len1, int* p2, int len2) 
{
   
        

    
    return nullptr;
}