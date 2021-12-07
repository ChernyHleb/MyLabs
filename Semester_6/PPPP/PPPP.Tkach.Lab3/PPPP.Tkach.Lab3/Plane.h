#pragma once
#include <tuple>
#include "Vehicle.h"

class Plane : public Vehicle
{
public:
	Plane();
	Plane(std::tuple<int, int, double>, int);
	~Plane();
};

