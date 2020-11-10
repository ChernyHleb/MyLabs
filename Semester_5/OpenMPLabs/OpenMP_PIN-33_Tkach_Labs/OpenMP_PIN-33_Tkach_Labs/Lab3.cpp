#include "Lab3.h"

void Lab3::Demonstrate()
{
	for (int dim = 5; dim < 15626; dim *= 5)
	{
		Matrix* matrixA = new Matrix(dim);
		Matrix* matrixB = new Matrix(dim);

		auto timerStart = std::chrono::high_resolution_clock::now();
		FuncWithoutOpenMP(matrixA, matrixB);
		auto timerStop = std::chrono::high_resolution_clock::now();

		auto duration = std::chrono::duration_cast<std::chrono::nanoseconds>(timerStop - timerStart).count();
		std::cout << "Without OpenMP: " << matrixA->ToShortString() << std::endl
			      << "DURATION: " << duration << " nanoSec\n";

		timerStart = std::chrono::high_resolution_clock::now();
		FuncWithReduction(matrixA, matrixB);
		timerStop = std::chrono::high_resolution_clock::now();
		duration = std::chrono::duration_cast<std::chrono::microseconds>(timerStop - timerStart).count();
	
		duration = std::chrono::duration_cast<std::chrono::microseconds>(timerStop - timerStart).count();
		std::cout << "With OpenMP: " << matrixA->ToShortString() << std::endl 
				  << "DURATION: " << duration << " nanoSec\n\n";
	}
}

int64_t Lab3::FuncWithReduction(Matrix* matrixA, Matrix* matrixB)
{
	int64_t sum = 0;

	return sum;
}

int64_t Lab3::FuncWithoutOpenMP(Matrix* matrixA, Matrix* matrixB)
{
	int64_t sum = 0;
	for (int i = 0; i < matrixA->N; i++)
	{
		for (int j = 0; j < matrixA->N; j++)
		{
			int temp = std::max(matrixA->matrix[i][j] + matrixB->matrix[i][j], 
				   4 * matrixA->matrix[i][j] - matrixB->matrix[i][j]);
			if (temp > 1)
				sum += temp;
		}
	}

	return sum;
}