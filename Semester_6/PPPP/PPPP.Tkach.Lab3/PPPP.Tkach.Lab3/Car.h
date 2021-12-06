#pragma once
#include <tuple>

class Car
{
	int carSpeed;
	int carVolume;
	double carPrice;
	int distance;
public:
	Car();
	Car(std::tuple<int, int, double>, int);
	~Car();
	double sumCost(int, int);
	double sumTime(int);
	int getDistance();
};

