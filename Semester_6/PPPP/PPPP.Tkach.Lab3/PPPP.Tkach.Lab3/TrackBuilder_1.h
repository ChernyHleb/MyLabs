#pragma once
#include "TrackBuilder.h"
class TrackBuilder_1 : public TrackBuilder
{
public:
	TrackBuilder_1(int*, int);
	void BuildTrack() override;
	void BuildCars() override;
};

