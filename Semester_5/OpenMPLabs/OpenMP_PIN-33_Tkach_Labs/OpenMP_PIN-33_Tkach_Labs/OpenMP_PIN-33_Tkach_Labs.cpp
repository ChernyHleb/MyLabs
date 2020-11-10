#include <iostream>

#include "Matrix.h"
#include "Lab3.h"

int main()
{
    //Matrix *m = new Matrix(3, 6);
    //std::cout << m->ToString();

    Lab3 *testLab3 = new Lab3();
    testLab3 -> Demonstrate();

    delete testLab3;
}