#ifndef  Lab3_HEADER
#define Lab3_HEADER


#include "omp.h"
#include "Matrix.h"
#include <chrono>
#include <iostream>
#include <stdlib.h>

class Lab3
{
public:
	void SetMatrixA(Matrix* matrix) { if (matrixA != nullptr) delete matrixA; matrixA = matrix; };
	void SetMatrixB(Matrix* matrix) { if (matrixB != nullptr) delete matrixB; matrixB = matrix; };

	virtual void Demonstrate();
	virtual std::string GetStatistics(int dim);
	Lab3() { matrixA = matrixB = nullptr; }
	~Lab3();
protected:
	Matrix* matrixA;
	Matrix* matrixB;
	int64_t FuncWithReduction(Matrix *matrixA, Matrix* matrixB);
	int64_t FuncWithoutOpenMP(Matrix* matrixA, Matrix* matrixB);
};

#endif