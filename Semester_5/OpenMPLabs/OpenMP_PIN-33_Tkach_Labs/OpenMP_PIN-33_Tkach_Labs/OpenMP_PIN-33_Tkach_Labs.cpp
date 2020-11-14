#include <iostream>

#include "Matrix.h"
#include "Lab4.h"


void Sample1()
{
    Matrix* m = new Matrix(1000);
    int smax = 0;
    int i, j, NMAX = 1000;
    int64_t sum, total = 0;
#pragma omp parallel shared(total, m) private(i,j,sum)
    {
#pragma omp for
        for (i = 0; i < NMAX; i++)
        {
            sum = 0;
            for (j = 0; j < NMAX; j++)
                sum += m->matrix[i][j];
            std::cout << "Sum of elements on row " + std::to_string(i) + " equals " + std::to_string(sum) + "\n";
#pragma omp atomic
            total += sum;
        }
    } /* Завершение параллельного фрагмента */
    std::cout << "Sum of elements of the matrix equals: " << std::to_string(total) + "\n";
}

void Sample2()
{
    Matrix* m = new Matrix(1000);
    int smax = 0;
    int i, j, NMAX = 1000;
    int sum;
#pragma omp parallel shared(smax,m) private(i,j,sum)
    {
#pragma omp for
        for (i = 0; i < NMAX; i++)
        {
            sum = 0;
            for (j = 0; j < NMAX; j++)
                sum += m->matrix[i][j];
            printf("Sum of elements on row %d equals %d\n", i, sum);
            if (sum > smax)
#pragma omp critical
                if (sum > smax)
                    smax = sum;
        }
    } /* Завершение параллельного фрагмента */
    printf("Max sum is %d\n", smax);
    delete m;
}

int main()
{
    /*Matrix *m = new Matrix(3, 6);
    std::cout << m->ToString();*/

    Lab4 *testLab3 = new Lab4();
    testLab3 -> Demonstrate();

    delete testLab3;

    std::cout << std::endl;
    Sample1();

    std::cout << std::endl;
    Sample2();
}