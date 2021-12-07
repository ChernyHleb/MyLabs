#include "Track.h"

Track::Track()
{
	this->cost = 0;
	this->time = 0;
	this->volume = 0;
}

Track::~Track()
{

}

void Track::AddVehicle(Vehicle vehicle, int volume)
{
	cost += vehicle.sumCost(volume, vehicle.getDistance());
	time += vehicle.sumTime(vehicle.getDistance());
}

double Track::getCost()
{
	return this->cost;
}