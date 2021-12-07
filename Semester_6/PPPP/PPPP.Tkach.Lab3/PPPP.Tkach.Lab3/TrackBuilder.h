#pragma once
#include "Track.h"
class TrackBuilder
{
private:
	Track* track;
public:
	virtual void BuildTrack();
	virtual void BuildTrains();
	virtual void BuildPlanes();
	virtual void BuildCars();
	virtual void getTrack();
};

