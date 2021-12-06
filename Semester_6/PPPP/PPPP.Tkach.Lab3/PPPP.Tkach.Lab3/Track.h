#pragma once
#include "../PPPP.Tkach.Lab3/Car.h"
#include "../PPPP.Tkach.Lab3/Plane.h"
#include "../PPPP.Tkach.Lab3/Train.h"
class Track
{
	double cost;
	double time;
	int volume;
public:
	Track();
	Track(Car, int);
	Track(Car, Car, Train, int);
	Track(Car, Car, Plane, int);
	Track(Car, Car, Car, Train, Plane, int);
	Track(Car, Car, Car, Car, Train, Train, Plane, int);
	double getCost();
	~Track();
};

