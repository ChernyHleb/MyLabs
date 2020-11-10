#include "omp.h"
#include "Matrix.h"
#include <chrono>
#include <iostream>
#include <stdlib.h>

class Lab3
{
public:
	void Demonstrate();
	Lab3() { }
protected:
	int64_t FuncWithReduction(Matrix *matrixA, Matrix* matrixB);
	int64_t FuncWithoutOpenMP(Matrix* matrixA, Matrix* matrixB);
};

