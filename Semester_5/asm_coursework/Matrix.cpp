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
        "loop_sum:\n\t"
        "dec %%ecx\n\t"

        "movl $0, (%%ebx, %%ecx, 4)\n\t"// обнуляем
        "movl (%%esi, %%ecx, 4), %%eax\n\t"
        "add %%eax, (%%ebx, %%ecx, 4)\n\t"// прибавляем элемент 1 массива
        "movl (%%edi, %%ecx, 4), %%eax\n\t"
        "add %%eax, (%%ebx, %%ecx, 4)\n\t"// прибавляем элемент 2 массива
        
        "cmp $0, %%ecx\n\t"
        "jne loop_sum"

        :
        :"b"(res), "S"(matrix1), "D"(matrix2), "c"(lim)
        :
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
        "loop_sub:\n\t"
        "dec %%ecx\n\t"

        "movl $0, (%%ebx, %%ecx, 4)\n\t"// обнуляем
        "movl (%%esi, %%ecx, 4), %%eax\n\t"
        "add %%eax, (%%ebx, %%ecx, 4)\n\t"// прибавляем элемент 1 массива
        "movl (%%edi, %%ecx, 4), %%eax\n\t"
        "neg %%eax\n\t"//меняем знак элемента 2 массива
        "add %%eax, (%%ebx, %%ecx, 4)\n\t"// прибавляем элемент 2 массива
        
        "cmp $0, %%ecx\n\t"
        "jne loop_sub"

        :
        :"b"(res), "S"(matrix1), "D"(matrix2), "c"(lim)
        :
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
    int* matrix = m->GetMatrix();
    int lim = m->GetN() * m->GetM();
    int* res = new int[lim];
    asm(
        "loop_cmul:\n\t"
        "dec %%ecx\n\t"

        "movl $0, (%%edi, %%ecx, 4)\n\t"// обнуляем
        
        "movw (%%esi, %%ecx, 4), %%ax\n\t"
        "movw %3 ,%%bx\n\t"
        "imulw %%bx\n\t"// результат в dx:ax

        "xor %%ebx, %%ebx\n\t"
        "movw %%dx, %%bx\n\t"//2 младших байта ebx
        "shl $8, %%ebx\n\t"// двигаем значение bx в старшие байты ebx
        "movw %%ax, %%bx\n\t"
        "movl %%ebx, (%%edi, %%ecx, 4)\n\t"

        "cmp $0, %%ecx\n\t"
        "jne loop_cmul"
        :
        :"D"(res), "S"(matrix), "c"(lim), "m"(c)
        : 
    );
    return new Matrix(res, m->GetN(), m->GetM());
}
// Транспонирование
Matrix* Matrix::Tran(Matrix* m)
{
    int* matrix = m->GetMatrix();
    int N = m->GetN();
    int M = m->GetM();
    int* res = new int[N * M];
    int counter;
    int lim = N * M;
    asm(
        "movl %5, %%ecx\n\t"
        "loop_tran_m:\n\t"
        "dec %%ecx\n\t"
        "movl %%ecx, %4\n\t"// счетчик для перемещения по исходному массиву

        "movl %3, %%edx\n\t"
        "loop_tran_n:\n\t"
        "dec %%edx\n\t"

        //счетчик результирующего массива --
        "movl %5, %%ebx\n\t"
        "dec %%ebx\n\t" 
        "movl %%ebx, %5\n\t"

        "movl %4, %%ebx\n\t"
        "movl (%%esi, %%ebx, 4), %%eax\n\t"
        "movl %5, %%ebx\n\t"
        "movl %%eax, (%%edi, %%ebx, 4)\n\t"

        // счетчик исходного массива -= M;
        "movl %4, %%ebx\n\t"
        "sub %2, %%ebx\n\t"
        "movl %%ebx, %4\n\t"

        "cmp $0, %%edx\n\t"
        "jne loop_tran_n\n\t"

        "cmp $0, %%ecx\n\t"
        "jne loop_tran_m"
        :
        :"D"(res), "S"(matrix), "m"(M), "m"(N), "m"(counter), "m"(lim)
        : 
    );
    return new Matrix(res, M, N);
}

