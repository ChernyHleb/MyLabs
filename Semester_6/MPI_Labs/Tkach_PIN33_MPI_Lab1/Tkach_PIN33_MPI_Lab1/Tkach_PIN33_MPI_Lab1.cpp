#include <iostream>
#include "mpi.h"

int main()
{
    int commsize;
    int rank;
    MPI_Init(NULL, NULL);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &commsize);

    std::cout << "Hello World!\n";

    MPI_Finalize();
    return 0; 
}