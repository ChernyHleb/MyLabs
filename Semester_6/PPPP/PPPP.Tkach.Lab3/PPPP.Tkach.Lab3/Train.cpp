#include "Train.h"

Train::Train()
{
	this->price = 200;
	this->speed = 100;
	this->volume = 500;
	this->distance = 0;
}

Train::Train(std::tuple<int, int, double> tuple, int dist)
{
	this->price = std::get<0>(tuple);
	this->speed = std::get<1>(tuple);
	this->volume = std::get<2>(tuple);
	this->distance = dist;
}

Train::~Train()
{

}