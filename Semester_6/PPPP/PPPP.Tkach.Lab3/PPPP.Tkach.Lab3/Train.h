#pragma once
#include <tuple>

class Train
{
	int trainSpeed;
	int trainVolume;
	double trainPrice;
	int distance;
public:
	Train();
	Train(std::tuple<int, int, double>, int);
	~Train();
	double sumCost(int, int);
	double sumTime(int);
	int getDistance();
};
