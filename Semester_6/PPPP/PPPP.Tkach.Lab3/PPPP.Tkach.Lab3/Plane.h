#pragma once
#include <tuple>

class Plane
{
	int planeSpeed;
	int planeVolume;
	double planePrice;
	int distance;
public:
	Plane();
	Plane(std::tuple<int, int, double>, int);
	~Plane();
	double sumCost(int, int);
	double sumTime(int);
	int getDistance();
};

