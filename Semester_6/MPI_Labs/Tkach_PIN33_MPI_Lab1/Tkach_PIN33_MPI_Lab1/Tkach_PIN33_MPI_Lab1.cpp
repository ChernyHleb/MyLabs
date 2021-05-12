#include <iostream>
#include <cstdlib>
#include "mpi.h"
#include <string>
using namespace std;
// ¬ариант 1 («вездочка)
void DoManagerProcess(int *process_rank, 
					  int *process_amount, 
					  int *send_message,
					  int *recv_message,
					  MPI_Status* status,
					  int *repeat)
{
	for (int i = 0; i < 3; i++)
	{
		printf("~ITERATION %d\n", i);
		// основной процесс отправл€ет остальным рандомное число
		for (int i = 1; i < *process_amount; i++)
		{
			*send_message = rand() % 100;
			MPI_Send(send_message, 1, MPI_INT, i, 0, MPI_COMM_WORLD);
			printf("Sending message:%d from process %d to %d\n",
				*send_message, *process_rank, i);
			MPI_Recv(recv_message, 1, MPI_INT, i,
				MPI_ANY_TAG, MPI_COMM_WORLD, status);
			printf("process %d recv message:'%d' from process %d\n",
				*process_rank, *recv_message, i);
		}
		// принимает от каждого сообщение
		
		printf("\n");
	}
}

void DoWorkerProcess(int* process_rank,
					 int* process_amount,
					 int* send_message,
					 int* recv_message,
					 MPI_Status* status)
{
	// процесс принимает рандомное число от основного процесса
	MPI_Recv(recv_message, 1, MPI_INT, 0,
		MPI_ANY_TAG, MPI_COMM_WORLD, status);
	printf("process %d recv message:'%d' from process %d\n",
		*process_rank , *recv_message, 0);
	// отправка ответа
	*send_message = *process_rank;
	MPI_Send(send_message, 1, MPI_INT, 0, 0, MPI_COMM_WORLD);
	printf("Sending message:%d from process %d to %d\n",
		*send_message, *process_rank, 0);
}

void Star_Lab1(int repeat)
{
	int process_rank;
	int process_amount;
	int send_message;
	int recv_message;
	MPI_Status status;

	double t1, t2;

	MPI_Init(NULL, NULL);
	MPI_Comm_rank(MPI_COMM_WORLD, &process_rank);
	MPI_Comm_size(MPI_COMM_WORLD, &process_amount);

	MPI_Barrier(MPI_COMM_WORLD);
	if (process_rank == 0)
		t1 = MPI_Wtime();

	for (int i = 0; i < 3; i++)
	{
		printf("~ITERATION %d\n", i);

		if (process_rank == 0) {
		/*DoManagerProcess(&process_rank,
						 &process_amount,
						 &send_message,
						 &recv_message,
						 &status,
						 &repeat);*/
		
			// основной процесс отправл€ет остальным рандомное число
			for (int i = 1; i < process_amount; i++)
			{
				send_message = rand() % 100;
				MPI_Send(&send_message, 1, MPI_INT, i, 0, MPI_COMM_WORLD);
				printf("Sending message:%d from process %d to %d\n",
					send_message, process_rank, i);
				
			}

			for (int i = 1; i < process_amount; i++)
			{
				// принимает сообщение
				MPI_Recv(&recv_message, 1, MPI_INT, i,
					MPI_ANY_TAG, MPI_COMM_WORLD, &status);
				printf("process %d recv message:'%d' from process %d\n",
					process_rank, recv_message, i);

			}

			printf("\n");
		
		}
		else {
			/*DoWorkerProcess(&process_rank,
							&process_amount,
							&send_message,
							&recv_message,
							&status);*/
			// процесс принимает рандомное число от основного процесса
			MPI_Recv(&recv_message, 1, MPI_INT, 0,
				MPI_ANY_TAG, MPI_COMM_WORLD, &status);
			printf("process %d recv message:'%d' from process %d\n",
				process_rank, recv_message, 0);
			// отправка ответа
			send_message = process_rank;
			MPI_Send(&send_message, 1, MPI_INT, 0, 0, MPI_COMM_WORLD);
			printf("Sending message:%d from process %d to %d\n",
				send_message, process_rank, 0);

		}

	}

	MPI_Barrier(MPI_COMM_WORLD);
	if (process_rank == 0)
	{
		t2 = MPI_Wtime();
		printf("~TIME1: %f", t2 - t1);
	}

	MPI_Finalize();
	
	return;
}

void DataInitialization(int* arr, int n)
{
	for (int i = 0; i < n; i++) {
		arr[i] = rand() % 100;
	}
	return;
}


void DataDividion(int* arr, int n, int num)
{
	int modRes = num % n;
	int divRes = num / n;
	for (int i = 0; i < n; i++) {
		arr[i] = divRes;
	}
	arr[0] += modRes;
	return;
}

void Star_Lab2(int repeat) 
{
	int arr[3];
	int n = 3;

	int process_rank;
	int process_amount;
	int send_message;
	int recv_message;
	MPI_Status status;

	double t1, t2;

	MPI_Init(NULL, NULL);
	MPI_Comm_rank(MPI_COMM_WORLD, &process_rank);
	MPI_Comm_size(MPI_COMM_WORLD, &process_amount);

	MPI_Barrier(MPI_COMM_WORLD);
	if(process_rank == 0)
		t1 = MPI_Wtime();

	for (int i = 0; i < 3; i++)
	{
		printf("~ITERATION %d\n", i);

		// инициализаци€ массива рандомными числами
		if (process_rank == 0 && i == 0) 
			DataInitialization(arr, n);
		if (process_rank == 0 && i != 0)
			DataDividion(arr, n, recv_message);

		// рассылка от 0 процесса всем остальным arr
		MPI_Bcast(arr, n, MPI_INT, 0, MPI_COMM_WORLD);
		if (process_rank == 0) 
			printf("Sending messages from root process to others: %d, %d, %d\n",
				arr[0], arr[1], arr[2]);

		// каждый процесс что то делает со своей порцией
		printf("Im process %d! I have %d incrementing data: %d)\n", process_rank, arr[process_rank], arr[process_rank] + 1);
		arr[process_rank] ++;


		// все процессы отправл€ют свое сообщение, главному и они суммируютс€
		send_message = arr[process_rank];
		MPI_Reduce(&send_message, &recv_message, 1, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);
		if (process_rank == 0)
			printf("Root process recv message: %d\n", recv_message);

		// все процессы изм данные

	}

	MPI_Barrier(MPI_COMM_WORLD);
	if (process_rank == 0)
	{
		t2 = MPI_Wtime();
		printf("~TIME2: %f", t2-t1);
	}
		

	MPI_Finalize();

	return;
}

void Star_Lab3(int repeat)
{
	int sbuf[3];
	int n = 3;
	int rbuf[1];

	int process_rank;
	int process_amount;

	int send_message[1];
	int recv_message[3];

	double t1, t2;

	MPI_Init(NULL, NULL);
	MPI_Comm_rank(MPI_COMM_WORLD, &process_rank);
	MPI_Comm_size(MPI_COMM_WORLD, &process_amount);

	MPI_Barrier(MPI_COMM_WORLD);
	if (process_rank == 0)
		t1 = MPI_Wtime();

	for (int i = 0; i < 3; i++)
	{
		printf("~ITERATION %d\n", i);

		// инициализаци€ массива рандомными числами
		if (process_rank == 0)
			DataInitialization(sbuf, n);

		// рассылка от 0 процесса всем остальным arr
		MPI_Scatter(sbuf, 1, MPI_INT, rbuf, 1, MPI_INT, 0, MPI_COMM_WORLD);
		if (process_rank == 0)
			printf("Sending messages from root process to others: %d, %d, %d\n",
				sbuf[0], sbuf[1], sbuf[2]);

		// каждый процесс что то делает со своей порцией
		printf("Im process %d! I have %d :)\n", process_rank, rbuf[0]);


		// все процессы отправл€ют свое сообщение (прин€тое значение + 1) главному

		send_message[0] = rbuf[0] + 1;
		// не очень пон€л почему в rcount надо ставить 1 а не 3
		MPI_Gather(send_message, 1, MPI_INT, recv_message, 1, MPI_INT, 0, MPI_COMM_WORLD);
		if (process_rank == 0)
			printf("Root process gathered messages: %d, %d, %d\n",
				recv_message[0], recv_message[1], recv_message[2]);


	}

	MPI_Barrier(MPI_COMM_WORLD);
	if (process_rank == 0)
	{
		t2 = MPI_Wtime();
		printf("~TIME3: %f", t2 - t1);
	}


	MPI_Finalize();

	return;
}

struct LongNum
{
	int* body;
	int len;
};

LongNum *LongMul(LongNum *num1, LongNum *num2)
{
	LongNum* res = new LongNum();
	res->len = num1->len + num2->len;
	res->body = new int[res->len];
	res->body[res->len - 1] = 0;
	for (int i = 0; i < res->len; i++)
	{
		res->body[i] = 0;
	}

	for (int i = 0; i < num1->len; i++)
		for (int j = 0; j < num2->len; j++)
			res->body[i + j] += num1->body[i] * num2->body[j];

	for (int i = 0; i < res->len - 1; i++)
	{
		res->body[i + 1] += res->body[i] / 10;
		res->body[i] %= 10;
	}

	if (res->body[res->len - 1] == 0)
		res->len--;

	return res;
}

void PrintLongNum(LongNum *num)
{
	printf("%d", num->len == 0 ? 0 : num->body[num->len-1]);
	for (int i = num->len - 2; i >= 0; i--)
		printf("%d", num->body[i]);
}

LongNum* StringToLongNum(string s) 
{
	LongNum *num = new LongNum();
	num->len = s.length();
	num->body = new int[num->len];

	for (int i = 0; i < num->len; i ++)
	{
		num->body[num->len - i - 1] = atoi(s.substr(i, 1).c_str());
	}
	
	return num;
}

LongNum* RandLongNum(int len)
{
	LongNum* num = new LongNum;
	num->len = len;
	num->body = new int[len];
	for (int i = 0; i < len; i++)
	{
		num->body[i] = rand() % 10;
		if (i == len - 1 && num->body[i] == 0)
			num->body[i] ++;
	}
	return num;
}

void Lab4()
{
	LongNum *num = StringToLongNum("111222333444555666");
	//PrintLongNum(num);
	//printf("\n");
	//PrintLongNum(LongMul(num, num));
	LongNum* num1 = RandLongNum(100);
	PrintLongNum(num1);
	printf("\n\n");
	LongNum* num2 = RandLongNum(100);
	PrintLongNum(num2);
	printf("\n\n");

	PrintLongNum(LongMul(num1, num2));
}

int main(int argc, char* argv[]) {
	if (argv[1][0] == '1')
		Star_Lab1(3);
	else
	if (argv[1][0] == '2')
		Star_Lab2(3);
	else
	if (argv[1][0] == '3')
		Star_Lab3(3);
	else
	if (argv[1][0] == '4')
		Lab4();
	else
		printf("INVALID ARGV! %s\n", argv[1]);
	return 0;
}