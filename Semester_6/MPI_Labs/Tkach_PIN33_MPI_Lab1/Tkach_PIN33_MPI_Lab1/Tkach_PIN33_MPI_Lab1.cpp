#include <iostream>
#include <cstdlib>
#include "mpi.h"
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

void Star(int repeat)
{
	int process_rank;
	int process_amount;
	int send_message;
	int recv_message;
	MPI_Status status;

	MPI_Init(NULL, NULL);
	MPI_Comm_rank(MPI_COMM_WORLD, &process_rank);
	MPI_Comm_size(MPI_COMM_WORLD, &process_amount);

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

void Star_Lab2(int repeat) 
{
	int arr[3];
	int n = 3;

	int process_rank;
	int process_amount;
	int send_message;
	int recv_message;
	MPI_Status status;

	MPI_Init(NULL, NULL);
	MPI_Comm_rank(MPI_COMM_WORLD, &process_rank);
	MPI_Comm_size(MPI_COMM_WORLD, &process_amount);

	for (int i = 0; i < 3; i++)
	{
		printf("~ITERATION %d\n", i);

		// инициализаци€ массива рандомными числами
		if (process_rank == 0) 
			DataInitialization(arr, n);

		// рассылка от 0 процесса всем остальным arr
		MPI_Bcast(arr, n, MPI_INT, 0, MPI_COMM_WORLD);
		if (process_rank == 0) 
			printf("Sending messages from root process to others: %d, %d, %d\n",
				arr[0], arr[1], arr[2]);

		// каждый процесс что то делает со своей порцией
		printf("Im process %d! I have %d :)\n", process_rank, arr[process_rank]);

		// все процессы отправл€ют свое сообщение, главному и они суммируютс€
		send_message = arr[process_rank];
		MPI_Reduce(&send_message, &recv_message, 1, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);
		if (process_rank == 0)
			printf("Root process recv message: %d\n", recv_message);


	}

	MPI_Finalize();

	return;
}

int main(int argc, char* argv[]) {
	//Star(3);
	Star_Lab2(2);
	return 0;
}