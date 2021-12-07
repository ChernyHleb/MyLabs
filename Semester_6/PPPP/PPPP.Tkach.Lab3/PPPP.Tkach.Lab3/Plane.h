#pragma once
#include <tuple>
#include "Vehicle.h"

class Plane : Vehicle
{
public:
	Plane();
	Plane(std::tuple<int, int, double>, int);
	~Plane();
};

