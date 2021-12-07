#pragma once
#include "TrackBuilder.h"

class TrackBuilder_3 : public TrackBuilder
{
public:
	TrackBuilder_3(int*, int);
	void BuildTrack() override;
	void BuildCars() override;
	void BuildTrains() override;
	void BuildPlanes() override;
};

