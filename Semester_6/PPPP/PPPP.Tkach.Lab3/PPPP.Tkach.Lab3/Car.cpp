#include "Car.h"

Car::Car()
{
	this->price = 100;
	this->speed = 60;
	this->volume = 50;
	this->distance = 0;
}

Car::Car(std::tuple<int, int, double> tuple, int dist)
{
	this->price = std::get<0>(tuple);
	this->speed = std::get<1>(tuple);
	this->volume = std::get<2>(tuple);
	this->distance = dist;
}

Car::~Car()
{

}


