#include <iostream>

#include "Matrix.h"
#include "Lab3.h"
#include "Lab4.h"

int main()
{
    //Matrix *m = new Matrix(3, 6);
    //std::cout << m->ToString();

    /*Lab3 *testLab3 = new Lab3();
    testLab3 -> Demonstrate();

    delete testLab3;*/

    Lab4* testLab4 = new Lab4();
    testLab4->Demonstrate();

    delete testLab4;
}