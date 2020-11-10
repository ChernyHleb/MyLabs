#include "Matrix.h"

std::string Matrix::ToString()
{
	std::string result = "~MATRIX " + std::to_string(this->N) + 
						 "X" + std::to_string(this->M) + "\n";

	for (int i = 0; i < this->N; i++)
	{
		for (int j = 0; j < this->M; j++)
		{
			result += "\t" + std::to_string(this->matrix[i][j]);
		}
		result += "\n";
	}

	return result;
}

std::string Matrix::ToShortString()
{
	if (this->M == this->M)
	{
		return "~MATRIX DIM: " + std::to_string(this->N);
	}
	else
	{
		return "~MATRIX" + std::to_string(this->N) + "X" + std::to_string(this->M);
	}
}

Matrix::Matrix() : Matrix(5) { }

Matrix::Matrix(int dimention) : Matrix(dimention, dimention) { }

Matrix::Matrix(int N, int M)
{
	this->N = N;
	this->M = M;

	this->matrix = new int* [this->N];

	for (int i = 0; i < this->N; i++)
	{
		this->matrix[i] = new int [this->M];
		for (int j = 0; j < this->M; j++)
		{
			this->matrix[i][j] = rand() % 100 + 1;
		}
	}
}

