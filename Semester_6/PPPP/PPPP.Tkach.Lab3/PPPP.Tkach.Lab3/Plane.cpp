#include "Plane.h"

Plane::Plane()
{
	this->price = 500;
	this->speed = 300;
	this->volume = 100;
	this->distance = 0;
}

Plane::Plane(std::tuple<int, int, double> tuple, int dist)
{
	this->price = std::get<0>(tuple);
	this->speed = std::get<1>(tuple);
	this->volume = std::get<2>(tuple);
	this->distance = dist;
}

Plane::~Plane()
{

}
