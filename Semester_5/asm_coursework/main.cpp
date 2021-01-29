#include <iostream>
using namespace std;

int main() {

    int res [] = {0,0};
    int a=45;
    cout << res[1];
    asm ( "mov %1,%0 \n"           
        : "=m"(res[1])                    
        : "r"(a)
    );

     cout << res[1];
     cin >> a;
}

int sum(int a, int b)
{
    asm(
        "add %1,%0 \n"
        : "r"(a)
        : "r"(b)
    );
    return b;
}