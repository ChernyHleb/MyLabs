#ifndef  Lab4_HEADER
#define Lab4_HEADER


#include "omp.h"
#include "Matrix.h"
#include <chrono>
#include <iostream>
#include <stdlib.h>

class Lab4
{
public:
	void SetMatrixA(Matrix* matrix) { if (matrixA != nullptr) delete matrixA; matrixA = matrix; };
	void SetMatrixB(Matrix* matrix) { if (matrixB != nullptr) delete matrixB; matrixB = matrix; };

	virtual void Demonstrate();
	virtual std::string GetStatistics(int dim);
	Lab4() { matrixA = matrixB = nullptr; }
	~Lab4();
protected:
	Matrix* matrixA;
	Matrix* matrixB;
	int64_t FuncWithReduction(Matrix *matrixA, Matrix* matrixB);
	int64_t FuncWithoutOpenMP(Matrix* matrixA, Matrix* matrixB);
	int64_t FuncWithSync(Matrix* matrixA, Matrix* matrixB);
};

#endif