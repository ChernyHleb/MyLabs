#include "matrixLib.h"
#include <iostream>
using namespace std;

void hello_world()
{
    int res [] = {0,0};
    int a=45;
    cout << res[1];
    asm ( "mov %1,%0 \n"           
        : "=m"(res[1])                    
        : "r"(a)
    );

     cout << res[1] << "lol";
     cin >> a;
}