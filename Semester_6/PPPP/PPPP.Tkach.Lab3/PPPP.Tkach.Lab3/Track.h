#pragma once
#include "../PPPP.Tkach.Lab3/Vehicle.h"

class Track
{
	double cost;
	double time;
	int volume;
public:
	Track();
	void AddVehicle(Vehicle, int);
	double getCost();
	~Track();
};

