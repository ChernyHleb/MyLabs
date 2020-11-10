#ifndef  Matrix_HEADER
#define Matrix_HEADER

#include <omp.h>
#include <string>
#include <cstdlib>


class Matrix
{
public:
	int **matrix;
	int N, M;
	std::string ToString();
	std::string ToShortString();
	Matrix();
	Matrix(int dimention);
	Matrix(int N, int M);
};

#endif // ! Matrix_HEADER

