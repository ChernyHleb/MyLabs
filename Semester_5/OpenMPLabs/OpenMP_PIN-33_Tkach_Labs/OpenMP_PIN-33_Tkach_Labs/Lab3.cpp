#include "Lab3.h"

void Lab3::Demonstrate()
{
	for (int dim = 5; dim < 15626; dim *= 5)
	{
		Matrix* matrixA = new Matrix(dim);
		Matrix* matrixB = new Matrix(dim);

		std::cout << matrixA->ToShortString() + "\n";

		auto timerStart = std::chrono::high_resolution_clock::now();
		FuncWithoutOpenMP(matrixA, matrixB);
		auto timerStop = std::chrono::high_resolution_clock::now();

		auto duration = std::chrono::duration_cast<std::chrono::nanoseconds>(timerStop - timerStart).count();
		std::cout << "Without OpenMP: " << duration << " nanoSec\n";

		timerStart = std::chrono::high_resolution_clock::now();
		FuncWithReduction(matrixA, matrixB);
		timerStop = std::chrono::high_resolution_clock::now();
		duration = std::chrono::duration_cast<std::chrono::microseconds>(timerStop - timerStart).count();
	
		duration = std::chrono::duration_cast<std::chrono::microseconds>(timerStop - timerStart).count();
		std::cout << "With OpenMP: " << duration << " nanoSec\n\n";

		delete matrixA;
		delete matrixB;
	}
}

int64_t Lab3::FuncWithReduction(Matrix* matrixA, Matrix* matrixB)
{
	int64_t sum;
	int i, j, temp;
	int dim = matrixA->N;
	int** A, ** B;

	#pragma omp parallel shared(dim, matrixA, matrixB)
	{
		#pragma opm for private(i, j, temp, A, B) reduction(+:sum)
		{
			A = matrixA->matrix;
			B = matrixB->matrix;

			sum = 0;
			for (i = 0; i < dim; i++)
			{
				for (j = 0; j < dim; j++)
				{
					int a = A[i][j];
					int b = B[i][j];

					temp = std::max(a + b, 4 * a - b);

					if (temp > 1)
						sum += temp;
				}
			}
		}
	}
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