#include <iostream>

int main()
{   int a, b, sum;

    __asm__(
        mov %a, $5
        mov %b, $10
        mov %sum, $0

        add %sum, %a
        add %sum, %b
    );
    
    std::cout << sum;

    return 0;
}