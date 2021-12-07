#include "TrackBuilder_1.h"
#include "Car.h"
#include "Info.h"
void TrackBuilder_1::BuildCars()
{
	Info *info = Info::getInfo();
	Car car1 = Car();
	for (auto it = info->table.begin(); it != info->table.end(); it++)
	{
		if ((*it).first.find(info->points[path[0]]))
		{
			car1 = Car(info->tableCost[(*it).second * 3 + 2], info->matrixDist[path[0]][path[1]]);
		}
	}

	track.AddVehicle(car1, volume);
}

void TrackBuilder_1::BuildTrack()
{
	track = Track();
}

TrackBuilder_1::TrackBuilder_1(int* p, int v)
{
	path = p;
	volume = v;
}