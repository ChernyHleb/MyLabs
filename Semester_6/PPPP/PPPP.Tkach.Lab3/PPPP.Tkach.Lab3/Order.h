#pragma once
#include <string>
#include "Track.h"
#include "TrackBuilder.h"

enum Type { Turbo, Standart, Economy };

class Order
{
	double cost;
	int volume;
	std::string startPoint;
	std::string finishPoint;
	enum::Type type;
	Track track;
	TrackBuilder builder;
public:
	Order();
	Order(Type, std::string, std::string, int);
	~Order();
	int decr(std::string);
	int** matrixUpd(Type);
	int* optim(int**, int, int);
	Track best(std::string, std::string, Type, int);
	Track ConstructTrack();
	void SetTrackBuilder(TrackBuilder);
};

