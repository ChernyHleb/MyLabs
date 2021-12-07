#include "Vehicle.h"

Vehicle::Vehicle()
{
	this->distance = 0;
	this->price = 0;
	this->speed = 0;
	this->volume = 0;
}

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