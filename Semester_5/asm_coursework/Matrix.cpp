#include "Matrix.h"

Matrix::Matrix(int* matrix, int n, int m)
{
    this->matrix = matrix;
    this->n = n;
    this->m = m;
}

Matrix::Matrix(int n, int m)
{
    this->n = n;
    this->m = m;
    
    int* matrix = new int[n * m];
    for(int i = 0; i < n; i++)
        for(int j = 0; j < m; j++)
            matrix[i * m + j] = rand() % 100 + 1;
    this->matrix = matrix;
}

Matrix::Matrix(int dim) : Matrix(dim, dim) { }

Matrix::Matrix() : Matrix(5) { }

Matrix::~Matrix()
{
    delete this->matrix;
}

string Matrix::ToString()
{
    string result = "~MATRIX " + std::to_string(this->n) + 
						 "x" + std::to_string(this->m) + "\n";

	for (int i = 0; i < this->n; i++)
	{
		for (int j = 0; j < this->m; j++)
		{
			result += "\t" + to_string(this->matrix[i * this->m + j]);
		}
		result += "\n";
	}

	return result;
}

string Matrix::ToShortString()
{
	return "~MATRIX" + std::to_string(this->n) + "x" + std::to_string(this->m);
}

int Matrix::GetN()
{
    return this->n;
}

int Matrix::GetM()
{
    return this->m;
}

int* Matrix::GetMatrix()
{
    return this->matrix;
}
/*______________________________________
___Функции с Ассемблерными вставками____
---------------------------------------*/
// сумма матриц
Matrix* Matrix::Sum(Matrix* m1, Matrix* m2)
{
    int* matrix1 = m1->GetMatrix();
    int* matrix2 = m2->GetMatrix();
    int lim = m1->GetN() * m1->GetM();
    int* res = new int[lim];
    asm(
        "loop1:\n\t"
        "dec %%ecx\n\t"

        "movl $0, (%%ebx, %%ecx, 4)\n\t"// обнуляем
        "movl (%%esi, %%ecx, 4), %%eax\n\t"
        "add %%eax, (%%ebx, %%ecx, 4)\n\t"// прибавляем элемент 1 массива
        "movl (%%edi, %%ecx, 4), %%eax\n\t"
        "add %%eax, (%%ebx, %%ecx, 4)\n\t"// прибавляем элемент 2 массива
        
        "cmp $0, %%ecx\n\t"
        "jne loop1"

        ::"b"(res), "S"(matrix1), "D"(matrix2), "c"(lim)
    );
    return new Matrix(res, m1->GetN(), m1->GetM());
}
// разность матриц
Matrix* Matrix::Sub(Matrix* m1, Matrix* m2)
{
    int* matrix1 = m1->GetMatrix();
    int* matrix2 = m2->GetMatrix();
    int lim = m1->GetN() * m1->GetM();
    int* res = new int[lim];
    asm(
        "loop2:\n\t"
        "dec %%ecx\n\t"

        "movl $0, (%%ebx, %%ecx, 4)\n\t"// обнуляем
        "movl (%%esi, %%ecx, 4), %%eax\n\t"
        "add %%eax, (%%ebx, %%ecx, 4)\n\t"// прибавляем элемент 1 массива
        "movl (%%edi, %%ecx, 4), %%eax\n\t"
        "neg %%eax\n\t"//меняем знак элемента 2 массива
        "add %%eax, (%%ebx, %%ecx, 4)\n\t"// прибавляем элемент 2 массива
        
        "cmp $0, %%ecx\n\t"
        "jne loop2"

        ::"b"(res), "S"(matrix1), "D"(matrix2), "c"(lim)
    );
    return new Matrix(res, m1->GetN(), m1->GetM());
}
// умножение матриц
Matrix* Matrix::Mul(Matrix* m1, Matrix* m2)
{
    /*asm(
        "i_loop:\n\t"
        "j_loop:\n\t"

        "movw %5 ,%%ax\n\t"// i
        "movw %4 ,%%bx\n\t"// m
        "mul %%bx\n\t"// i*m
        "add %6, %%eax\n\t"// i*m + j
        "movl %%eax, %%ecx\n\t"

        "movl %0, %%ebx\n\t"// результирующий массив
        // "movl %1, %%esi\n\t"// массив 1
        // "movl %2, %%edi\n\t"// массив 2

        "movl $0, (%%ebx, %%ecx, 4)\n\t"// обнуляем
        
        "add $1, %6\n\t"
        "movl %6, %%edx\n\t"
        "cmp %%edx, %4\n\t"
        "jne j_loop\n\t"

        "add $1, %5\n\t"
        "movl %5, %%edx\n\t"
        "cmp %%edx, %3\n\t"
        "jne i_loop"

        ::"m"(res), "m"(matrix1), "m"(matrix2), "m"(n), "m"(m), "m"(i), "m"(j)
    );*/
}
// Нахождение детерминанта
Matrix* Matrix::Det(Matrix* m)
{

}
// Нахождение обратной матрицы
Matrix* Matrix::Rev(Matrix* m)
{

}
// Умножение матрицы на число
Matrix* Matrix::CMul(Matrix* m, int c)
{

}
// Транспонирование
Matrix* Matrix::Tran(Matrix* m)
{

}

