#pragma once
#include <tuple>
#include "Vehicle.h"

class Train : Vehicle
{
public:
	Train();
	Train(std::tuple<int, int, double>, int);
	~Train();
};
