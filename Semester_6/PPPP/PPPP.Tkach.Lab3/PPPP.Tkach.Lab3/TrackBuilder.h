#pragma once
#include "Track.h"
class TrackBuilder
{
protected:
	Track track;
	int* path;
	int volume;
 public:
	virtual void BuildTrack();
	virtual void BuildTrains();
	virtual void BuildPlanes();
	virtual void BuildCars();
	virtual Track getTrack()
	{
		return track;
	}
};

