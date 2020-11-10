#include "Lab4.h"

void Lab4::Demonstrate()
{
	for (int dim = 5; dim < 15626; dim *= 5)
	{
		std::cout << GetStatistics(dim) << std::endl;
	}
}

std::string Lab4::GetStatistics(int dim)
{
	std::string output = Lab3::GetStatistics(dim);

	auto timerStart = std::chrono::high_resolution_clock::now();
	int64_t result = FuncWithSync(matrixA, matrixB);
	auto timerStop = std::chrono::high_resolution_clock::now();

	auto duration = std::chrono::duration_cast<std::chrono::nanoseconds>(timerStop - timerStart).count();
	output += "~~With Sync: " + std::to_string(duration) + " nanoSec\n";
	output += "~~RESULT: " + std::to_string(result) + "\n";

	return output;
}

int64_t Lab4::FuncWithSync(Matrix* matrixA, Matrix* matrixB)
{
	int64_t sum;
	int i, j, temp;
	int dim = matrixA->N;
	int** A, ** B;

#pragma omp parallel shared(dim, matrixA, matrixB)
	{
#pragma omp for private(i, j, temp, A, B)
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

				#pragma omp critical
					if (temp > 1)
						sum += temp;
				}
			}
		}
	}
	return sum;
}
