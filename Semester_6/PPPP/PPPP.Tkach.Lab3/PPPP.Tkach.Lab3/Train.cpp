#include "Train.h"

Train::Train()
{
	this->trainPrice = 200;
	this->trainSpeed = 100;
	this->trainVolume = 500;
	this->distance = 0;
}

Train::Train(std::tuple<int, int, double> tuple, int dist)
{
	this->trainPrice = std::get<0>(tuple);
	this->trainSpeed = std::get<1>(tuple);
	this->trainVolume = std::get<2>(tuple);
	this->distance = dist;
}

Train::~Train()
{

}

double Train::sumCost(int mass, int dist)
{
	return (mass / trainVolume) * sumTime(dist) * trainPrice;
}

double Train::sumTime(int dist)
{
	return dist / trainSpeed;
}

int Train::getDistance()
{
	return this->distance;
}