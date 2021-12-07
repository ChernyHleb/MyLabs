#pragma once
#include <tuple>
#include "Vehicle.h"

class Car : public Vehicle
{
public:
	Car();
	Car(std::tuple<int, int, double>, int);
	~Car();
};

