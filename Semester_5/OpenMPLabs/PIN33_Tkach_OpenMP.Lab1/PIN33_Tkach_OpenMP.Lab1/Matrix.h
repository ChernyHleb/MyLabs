#include <omp.h>
#include <string>

class Matrix
{
public:
	int **matrix;
	int N, M;
	std::string ToString();
	Matrix();
	Matrix(int dimention);
	Matrix(int N, int M);
private:
};

