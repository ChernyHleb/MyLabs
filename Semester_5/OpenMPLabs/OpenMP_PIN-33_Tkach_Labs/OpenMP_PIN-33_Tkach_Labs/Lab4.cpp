#include "Lab4.h"

void Lab4::Demonstrate()
{
	for (int dim = 6; dim < 7776 + 1; dim *= 6)
	{
		std::cout << GetStatistics(dim) << std::endl;
	}
}

std::string Lab4::GetStatistics(int dim)
{
	std::string output = "";

	SetMatrixA(new Matrix(dim));
	SetMatrixB(new Matrix(dim));

	output += matrixA->ToShortString() + "\n";

	auto timerStart = std::chrono::high_resolution_clock::now();
	int64_t result = FuncWithoutOpenMP(matrixA, matrixB);
	auto timerStop = std::chrono::high_resolution_clock::now();

	auto duration = std::chrono::duration_cast<std::chrono::nanoseconds>(timerStop - timerStart).count();
	output += "~~Without OpenMP: " + std::to_string(duration) + " nanoSec\n";
	output += "~~RESULT: " + std::to_string(result) + "\n";

	/*timerStart = std::chrono::high_resolution_clock::now();
	result = FuncWithLock(matrixA, matrixB);
	timerStop = std::chrono::high_resolution_clock::now();

	duration = std::chrono::duration_cast<std::chrono::nanoseconds>(timerStop - timerStart).count();
	output += "~~With Lock: " + std::to_string(duration) + " nanoSec\n";
	output += "~~RESULT: " + std::to_string(result) + "\n";*/

	timerStart = std::chrono::high_resolution_clock::now();
	result = FuncWithBarrier(matrixA, matrixB);
	timerStop = std::chrono::high_resolution_clock::now();

	duration = std::chrono::duration_cast<std::chrono::nanoseconds>(timerStop - timerStart).count();
	output += "~~With Barrier: " + std::to_string(duration) + " nanoSec\n";
	output += "~~RESULT: " + std::to_string(result) + "\n";
	
	return output;
}

Lab4::~Lab4()
{
	if(matrixA != nullptr)
		delete matrixA;
	if(matrixB != nullptr)
		delete matrixB;
}

int64_t Lab4::FuncWithLock(Matrix* matrixA, Matrix* matrixB)
{
	int64_t sum = 0;
	int64_t partitialSum;
	int i, j, temp;
	int dim = matrixA->N;
	int** A, ** B;

	omp_lock_t lock;
	omp_init_lock(&lock);

	#pragma omp parallel shared(dim, matrixA, matrixB)
	{
	#pragma omp for private(i, j, temp, A, B, partitialSum)
		for (i = 0; i < dim; i++)
		{
			partitialSum = 0;
			A = matrixA->matrix;
			B = matrixB->matrix;
			for (j = 0; j < dim; j++)
			{
				int a = A[i][j];
				int b = B[i][j];

				temp = std::max(a + b, 4 * a - b);

				if (temp > 1) {
					partitialSum += temp;
				}
					
			}
			omp_set_lock(&lock);
			sum += partitialSum;
			omp_unset_lock(&lock);
		}

	}
	omp_destroy_lock(&lock);
	return sum;
}

int64_t Lab4::FuncWithBarrier(Matrix* matrixA, Matrix* matrixB)
{
	int64_t sum = 0;
	int64_t partitialSum = 0;
	int i, j, temp;
	int dim = matrixA->N;
	int** A, ** B;

#pragma omp parallel shared(dim, matrixA, matrixB) private(partitialSum)
	{
#pragma omp for private(i, j, temp, A, B)
		for (i = 0; i < dim; i++)
		{
			partitialSum = 0;
			A = matrixA->matrix;
			B = matrixB->matrix;
			for (j = 0; j < dim; j++)
			{
				int a = A[i][j];
				int b = B[i][j];

				temp = std::max(a + b, 4 * a - b);

				if (temp > 1) {
					partitialSum += temp;
				}

			}
		}
		#pragma omp barrier
		sum += partitialSum;

	}
	return sum;
}


int64_t Lab4::FuncWithReduction(Matrix* matrixA, Matrix* matrixB)
{
	int64_t sum = 0;
	int i, j, temp;
	int dim = matrixA->N;
	int** A, ** B;

	#pragma omp parallel shared(dim, matrixA, matrixB)
	{
		#pragma omp for private(i, j, temp, A, B) reduction(+:sum)
			for (i = 0; i < dim; i++)
			{
				A = matrixA->matrix;
				B = matrixB->matrix;
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
	return sum;
}

int64_t Lab4::FuncWithoutOpenMP(Matrix* matrixA, Matrix* matrixB)
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

int64_t Lab4::FuncWithSync(Matrix* matrixA, Matrix* matrixB)
{
	int64_t sum = 0;
	int i, j, temp;
	int dim = matrixA->N;
	int** A, ** B;

#pragma omp parallel shared(dim, matrixA, matrixB)
	{
#pragma omp for private(i, j, temp, A, B)
		for (i = 0; i < dim; i++)
		{
			A = matrixA->matrix;
			B = matrixB->matrix;
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
	return sum;
}

int64_t Lab4::FuncWithSections(Matrix* matrixA, Matrix* MatrixB)
{
	int64_t sum = 0;
	int i, j, temp;
	int dim = matrixA->N;
	int** A, ** B;

#pragma omp parallel 
	{
	#pragma omp sections private(i, j, temp, A, B) reduction(+:sum)
		{
		#pragma omp section
			{
				for (i = 0; i < dim / 6; i++)
				{
					A = matrixA->matrix;
					B = matrixB->matrix;
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
		#pragma omp section
			{
				for (i = dim / 6; i < dim / 6 * 2; i++)
				{
					A = matrixA->matrix;
					B = matrixB->matrix;
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
		#pragma omp section
			{
				for (i = dim / 6 * 2; i < dim / 6 * 3; i++)
				{
					A = matrixA->matrix;
					B = matrixB->matrix;
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
		#pragma omp section
			{
				for (i = dim / 6 * 3; i < dim / 6 * 4; i++)
				{
					A = matrixA->matrix;
					B = matrixB->matrix;
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
		#pragma omp section
			{
				for (i = dim / 6 * 4; i < dim / 6 * 5; i++)
				{
					A = matrixA->matrix;
					B = matrixB->matrix;
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
		#pragma omp section
			{
				for (i = dim / 6 * 5; i < dim; i++)
				{
					A = matrixA->matrix;
					B = matrixB->matrix;
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
	}
	return sum;
}
