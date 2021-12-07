#pragma once
class Vehicle
{
protected:
	int speed;
	int volume;
	double price;
	int distance;
public:
	double sumCost(int, int);
	double sumTime(int);
	int getDistance();
};

