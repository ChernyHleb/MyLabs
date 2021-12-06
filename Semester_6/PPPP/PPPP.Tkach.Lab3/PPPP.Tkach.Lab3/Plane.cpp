#include "Plane.h"

Plane::Plane()
{
	this->planePrice = 500;
	this->planeSpeed = 300;
	this->planeVolume = 100;
	this->distance = 0;
}

Plane::Plane(std::tuple<int, int, double> tuple, int dist)
{
	this->planePrice = std::get<0>(tuple);
	this->planeSpeed = std::get<1>(tuple);
	this->planeVolume = std::get<2>(tuple);
	this->distance = dist;
}

Plane::~Plane()
{

}

double Plane::sumCost(int mass, int dist)
{
	return (mass / planeVolume) * sumTime(dist) * planePrice;
}

double Plane::sumTime(int dist)
{
	return dist / planeSpeed;
}

int Plane::getDistance()
{
	return this->distance;
}
