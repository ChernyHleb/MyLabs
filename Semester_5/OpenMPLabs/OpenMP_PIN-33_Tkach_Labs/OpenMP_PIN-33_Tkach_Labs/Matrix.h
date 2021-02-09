#ifndef  Matrix_HEADER
#define Matrix_HEADER

#include <omp.h>
#include <string>
#include <cstdlib>
using namespace std;


class Matrix
{
public:
	int **matrix;
	int N, M;
	string ToString();
	std::string ToShortString();
	Matrix();
	Matrix(int dimention);
	Matrix(int N, int M);
	~Matrix();
};

#endif // ! Matrix_HEADER

