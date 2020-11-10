#pragma once
#include "Lab3.h"

class Lab4 : public Lab3
{
public:
	void Demonstrate();
	std::string GetStatistics(int dim);
	Lab4() {}
	~Lab4() { Lab3::~Lab3(); }
protected:
	int64_t FuncWithSync(Matrix* matrixA, Matrix* matrixB);
};

