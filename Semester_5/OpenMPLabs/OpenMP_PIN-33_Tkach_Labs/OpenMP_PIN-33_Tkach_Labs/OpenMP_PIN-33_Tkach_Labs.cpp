#include <iostream>

#include "Matrix.h"
#include "Lab4.h"

int main()
{
    /*Matrix *m = new Matrix(3, 6);
    std::cout << m->ToString();*/

    Lab4 *testLab3 = new Lab4();
    testLab3 -> Demonstrate();

    delete testLab3;
}