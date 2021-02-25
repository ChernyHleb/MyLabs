#include "Matrix.h"
// TODO: добавить try catch
Matrix::Matrix(int* matrix, int n, int m)
{
    // TODO: copy elements to new arr
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
    // TODO: копировать элементы в новый массив 
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
    // тк матрица представлена линейным массивом,
    // просто делаем i++, аналогично для разности
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

        :"+b"(res), "+c"(lim)// TODO: заполнить выходными
        // TODO: [X]"r"(var);; %[X]
        :"S"(matrix1), "D"(matrix2)
        :"%eax", "memory", "cc"// TODO: заполнить используемыми регистрами
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

        :"+b"(res), "+c"(lim)
        :"S"(matrix1), "D"(matrix2)
        :"%eax", "memory", "cc"
    );
    return new Matrix(res, m1->GetN(), m1->GetM());
}
// умножение матриц
/*Matrix* Matrix::Mul(Matrix* m1, Matrix* m2)
{
    // число столбцов m1 k должно равняться числу строк m2 l
    // транспонируем матрицу 2 для удобства
    // (тогда можно просто умножать построчно)
    Matrix* m2T = Matrix::Tran(m2);
    // результирующая матрица
    int resN = m1->GetN();
    int resM = m2->GetM();
    int res_lim = resN * resM;
    int* res = new int[res_lim];
    // исходные матрицы
    int* matrix1 = m1->GetMatrix();
    int* matrix2T = m2T->GetMatrix();
    // вспомогательные переменные и счетчики
    int N1 = m1->GetN();
    int M1 = m1->GetM();
    int lim2 = m2->GetN() * m2->GetM();
    int c_M1 = 0;
    int c_lim2 = 0;
    int sum = 0;
    int lim1 = N1 * M1;
    //схема:
    //loop lim1 -> 0
    //  loop M1 -> 0
    //    c_m1 --
    //    lim1 --
    //    loop lim2 -> 0
    //      c_lim2 --
    //      sum += m1[lim1] * m2[lim2] 

    asm(
        "loop_mul_lim1:\n\t"
            // c_m1 = m1
            "movl %4, %%eax\n\t"
            "movl %%eax, %6\n\t"

            "loop_mul_m1:\n\t"
                // c_m1--
                "movl %6, %%eax\n\t"
                "dec %%eax\n\t"
                "movl %%eax, %6\n\t"

                // lim1 --
                "movl %3, %%eax\n\t"
                "dec %%eax\n\t"
                "movl %%eax, %3\n\t"

                // c_lim2 = lim2
                "movl %5, %%eax\n\t"
                "movl %%eax, %7\n\t"

                // sum = 0;
                "xor %%eax, %%eax\n\t"
                "movl %%eax, %8\n\t"
                // ___LOOP LIM2___ //
                "loop_mul_lim2:\n\t"
                    // c_lim2--
                    "movl %7, %%eax\n\t"
                    "dec %%eax\n\t"
                    "movl %%eax, %7\n\t"

                    // m1[lim1] * m2[lim2] 

                    "movl %3, %%eax\n\t"
                    "movw (%%edi, %%eax, 4), %%ax\n\t"

                    "movl %7, %%eax\n\t"
                    "movw (%%esi, %%eax, 4) ,%%bx\n\t"

                    "imulw %%bx\n\t"// результат в dx:ax

                    "xor %%ebx, %%ebx\n\t"
                    "movw %%dx, %%bx\n\t"//2 младших байта ebx
                    "shl $16, %%ebx\n\t"// двигаем значение bx в старшие байты ebx
                    "movw %%ax, %%bx\n\t"

                    // sum += reselt of imul
                    "movl %8, %%eax\n\t"
                    "add %%ebx, %%eax\n\t"
                    "movl %%eax, %8\n\t"

                "movl %7, %%eax\n\t"
                "cmp $0, %%eax\n\t"
                "jne loop_mul_lim2\n\t"

                //res_lim--
                "movl %9, %%eax\n\t"
                "dec %%eax\n\t"
                "movl %%eax, %9\n\t"

                // res[] = sum ---------------
                "movl %8, %%ebx\n\t"
                "movl %%ebx, (%%ecx, %%eax, 4)\n\t"

            "movl %6, %%eax\n\t"
            "cmp $0, %%eax\n\t"
            "jne loop_mul_m1\n\t"

        "movl %3, %%eax\n\t"
        "cmp $0, %%eax\n\t"
        "jne loop_mul_lim1"
        :"+c"(res)
        :"D"(matrix1), "S"(matrix2T), "m"(lim1), "m"(M1), "m"(lim2), "m"(c_M1), "m"(c_lim2), "m"(sum), "m"(res_lim)
        :"%eax", "%ebx", "%edx", "memory", "cc"
    );
    return new Matrix(res, resN, resM);
}
*/

Matrix* Matrix::Mul(Matrix* m1, Matrix* m2)
{
    Matrix* m2T = Matrix::Tran(m2);
    int n = m1->GetN();

    int *matrix1 = m1->GetMatrix();
    int *matrix2 = m2->GetMatrix();
    
    int* str1 = new int[n];
    int* str2 = new int[n];

    for(int i = 0; i < n; i++)
    {
        for(int i2 = 0; i2 < n; i2++)
        for(int j = 0; j < n; j++)
        {
            str1[j] = matrix1[n * i + j];
            str2[j] = matrix2[n * i2 + j];
            int res = Matrix::MulVectors(str1, str2, n);

            cout << res << " ";
        }

        cout << "\n";
    }

    delete[] str1;
    delete[] str2;

    return nullptr;
}

int Matrix::MulVectors(int* arr1, int* arr2, int elementsAmount)
{
    int res = 0;

    asm(
        "loop_mulVectors_lim:\n\t"
        "dec %%ecx\n\t"

            // m1[lim_counter] * m2[lim_counter] 
            "movw (%%esi, %%ecx, 4), %%ax\n\t"
            "movw (%%edi, %%ecx, 4), %%bx\n\t"

            "imulw %%bx\n\t"// результат в dx:ax

            "xor %%ebx, %%ebx\n\t"
            "movw %%dx, %%bx\n\t"//2 младших байта ebx
            "shl $16, %%ebx\n\t"// двигаем значение bx в старшие байты ebx
            "movw %%ax, %%bx\n\t"

            // sum += result of imul
            "movl %1, %%eax\n\t"
            "add %%ebx, %%eax\n\t"
            "movl %%eax, %1\n\t"

        "cmp $0, %%ecx\n\t"
        "jne loop_mulVectors_lim"

        :"+c"(elementsAmount), "+m"(res)
        :"S"(arr1), "D"(arr2)
        :"memory", "cc", "%eax", "%ebx", "%edx"
    );

    return res;
}

// Нахождение детерминанта
Matrix* Matrix::Det(Matrix* m)
{
    // рекурсия пока не получится матрица 1х1 ?
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
        "shl $16, %%ebx\n\t"// двигаем значение bx в старшие байты ebx
        "movw %%ax, %%bx\n\t"
        "movl %%ebx, (%%edi, %%ecx, 4)\n\t"

        "cmp $0, %%ecx\n\t"
        "jne loop_cmul"

        :"+D"(res), "+c"(lim)
        :"S"(matrix), "m"(c)
        :"%ebx", "%ax", "memory", "cc" 
        // перед вставкой значения этих регистров будут
        // сохранены в стеке, а после вставки они будут
        // восстановлены
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
    int counter = 0;
    int lim = N * M;
    int fin = lim - N;
    //схема:
    //c_res = lim
    //loop lim -> fin
    //  c_mat = lim
    //  loop N -> 0
    //    c_res --
    //    res[c_res] = mat[c_mat]
    //    c_mat -= M
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

        "cmp %6, %%ecx\n\t"
        "jne loop_tran_m"

        :"+D"(res)
        :"S"(matrix), "m"(M), "m"(N), "m"(counter), "m"(lim), "m"(fin)
        :"%edx", "%ecx", "%ebx", "%eax", "memory", "cc"
    );
    return new Matrix(res, M, N);
}

