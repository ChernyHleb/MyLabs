#include "Car.h"

Car::Car()
{
	this->carPrice = 100;
	this->carSpeed = 60;
	this->carVolume = 50;
	this->distance = 0;
}

Car::Car(std::tuple<int, int, double> tuple, int dist)
{
	this->carPrice = std::get<0>(tuple);
	this->carSpeed = std::get<1>(tuple);
	this->carVolume = std::get<2>(tuple);
	this->distance = dist;
}

Car::~Car()
{

}

double Car::sumCost(int mass, int dist)
{
	return (mass / carVolume) * sumTime(dist) * carPrice;
}

double Car::sumTime(int dist)
{
	return dist / carSpeed;
}

int Car::getDistance()
{
	return this->distance;
}


