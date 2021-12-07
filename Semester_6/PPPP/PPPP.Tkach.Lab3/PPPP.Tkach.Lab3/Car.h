#pragma once
#include <tuple>
#include "Vehicle.h"

class Car : Vehicle
{
public:
	Car();
	Car(std::tuple<int, int, double>, int);
	~Car();
};

