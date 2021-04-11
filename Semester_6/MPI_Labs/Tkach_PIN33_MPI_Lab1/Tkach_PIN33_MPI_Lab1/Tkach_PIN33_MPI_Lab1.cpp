#include <iostream>
#include <cstdlib>
#include "mpi.h"
// ������� 1 (���������)
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
		// �������� ������� ���������� ��������� ��������� �����
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
		// ��������� �� ������� ���������
		
		printf("\n");
	}
}

void DoWorkerProcess(int* process_rank,
					 int* process_amount,
					 int* send_message,
					 int* recv_message,
					 MPI_Status* status)
{
	// ������� ��������� ��������� ����� �� ��������� ��������
	MPI_Recv(recv_message, 1, MPI_INT, 0,
		MPI_ANY_TAG, MPI_COMM_WORLD, status);
	printf("process %d recv message:'%d' from process %d\n",
		*process_rank , *recv_message, 0);
	// �������� ������
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
		
			// �������� ������� ���������� ��������� ��������� �����
			for (int i = 1; i < process_amount; i++)
			{
				send_message = rand() % 100;
				MPI_Send(&send_message, 1, MPI_INT, i, 0, MPI_COMM_WORLD);
				printf("Sending message:%d from process %d to %d\n",
					send_message, process_rank, i);
				
			}

			for (int i = 1; i < process_amount; i++)
			{
				// ��������� ���������
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
			// ������� ��������� ��������� ����� �� ��������� ��������
			MPI_Recv(&recv_message, 1, MPI_INT, 0,
				MPI_ANY_TAG, MPI_COMM_WORLD, &status);
			printf("process %d recv message:'%d' from process %d\n",
				process_rank, recv_message, 0);
			// �������� ������
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

		// ������������� ������� ���������� �������
		if (process_rank == 0 && i == 0) 
			DataInitialization(arr, n);
		if (process_rank == 0 && i != 0)
			DataDividion(arr, n, recv_message);

		// �������� �� 0 �������� ���� ��������� arr
		MPI_Bcast(arr, n, MPI_INT, 0, MPI_COMM_WORLD);
		if (process_rank == 0) 
			printf("Sending messages from root process to others: %d, %d, %d\n",
				arr[0], arr[1], arr[2]);

		// ������ ������� ��� �� ������ �� ����� �������
		printf("Im process %d! I have %d incrementing data: %d)\n", process_rank, arr[process_rank], arr[process_rank] + 1);
		arr[process_rank] ++;


		// ��� �������� ���������� ���� ���������, �������� � ��� �����������
		send_message = arr[process_rank];
		MPI_Reduce(&send_message, &recv_message, 1, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);
		if (process_rank == 0)
			printf("Root process recv message: %d\n", recv_message);

		// ��� �������� ��� ������

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

		// ������������� ������� ���������� �������
		if (process_rank == 0)
			DataInitialization(sbuf, n);

		// �������� �� 0 �������� ���� ��������� arr
		MPI_Scatter(sbuf, 1, MPI_INT, rbuf, 1, MPI_INT, 0, MPI_COMM_WORLD);
		if (process_rank == 0)
			printf("Sending messages from root process to others: %d, %d, %d\n",
				sbuf[0], sbuf[1], sbuf[2]);

		// ������ ������� ��� �� ������ �� ����� �������
		printf("Im process %d! I have %d :)\n", process_rank, rbuf[0]);


		// ��� �������� ���������� ���� ��������� (�������� �������� + 1) ��������

		send_message[0] = rbuf[0] + 1;
		// �� ����� ����� ������ � rcount ���� ������� 1 � �� 3
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
		printf("INVALID ARGV! %s\n", argv[1]);
	return 0;
}