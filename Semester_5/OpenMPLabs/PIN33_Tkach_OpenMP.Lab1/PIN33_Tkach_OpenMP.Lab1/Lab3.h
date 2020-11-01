#include "omp.h"
#include "Matrix.h"
class Lab3
{
public:
	void Demonstrate();
private:
	Lab3() { }
protected:
	auto MeasureTime_Reduction(Matrix matrix);
	auto MeasureTime_WithoutOpenMP(Matrix matrix);
};

