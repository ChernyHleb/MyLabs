#pragma once
#include "TrackBuilder.h"
class TrackBuilder_5 : public TrackBuilder
{
public:
	TrackBuilder_5(int*, int);
	void BuildTrack() override;
	void BuildCars() override;
	void BuildTrains() override;
	void BuildPlanes() override;
};

