#pragma once
#include "TrackBuilder.h"

class TrackBuilder_7 : public TrackBuilder
{
public:
	TrackBuilder_7(int*, int);
	void BuildTrack() override;
	void BuildCars() override;
	void BuildTrains() override;
	void BuildPlanes() override;
};


