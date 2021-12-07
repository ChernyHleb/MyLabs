#include "Vehicle.h"

double Vehicle::sumCost(int mass, int dist)
{
	return (mass / volume) * sumTime(dist) * price;
}

double Vehicle::sumTime(int dist)
{
	return dist / speed;
}

int Vehicle::getDistance()
{
	return this->distance;
}