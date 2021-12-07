#include "TrackBuilder_7.h"
#include "Info.h"
#include "Car.h"
#include "Train.h"
#include "Plane.h"
TrackBuilder_7::TrackBuilder_7(int* p, int v)
{
	path = p;
	volume = v;
}
void TrackBuilder_7::BuildTrack()
{
	track = Track();
}

void TrackBuilder_7::BuildCars()
{
	Info* info = Info::getInfo();

	Car car1 = Car();
	for (auto it = info->table.begin(); it != info->table.end(); it++)
	{
		if ((*it).first.find(info->points[path[0]]))
		{
			car1 = Car(info->tableCost[(*it).second * 3 + 2], info->matrixDist[path[0]][path[1]]);
		}
	}

	Car car2 = Car();
	for (auto it = info->table.begin(); it != info->table.end(); it++)
	{
		if ((*it).first.find(info->points[path[2]]))
		{
			car2 = Car(info->tableCost[(*it).second * 3 + 2], info->matrixDist[path[2]][path[3]]);
		}
	}

	Car car3 = Car();
	for (auto it = info->table.begin(); it != info->table.end(); it++)
	{
		if ((*it).first.find(info->points[path[4]]))
		{
			car3 = Car(info->tableCost[(*it).second * 3 + 2], info->matrixDist[path[4]][path[5]]);
		}
	}

	Car car4 = Car();
	for (auto it = info->table.begin(); it != info->table.end(); it++)
	{
		if ((*it).first.find(info->points[path[6]]))
		{
			car4 = Car(info->tableCost[(*it).second * 3 + 2], info->matrixDist[path[6]][path[7]]);
		}
	}

	track.AddVehicle(car1, volume);
	track.AddVehicle(car2, volume);
	track.AddVehicle(car3, volume);
	track.AddVehicle(car4, volume);
}

void TrackBuilder_7::BuildTrains()
{
	Info* info = Info::getInfo();

	Train train1 = Train();
	for (auto it = info->table.begin(); it != info->table.end(); it++)
	{
		if ((*it).first.find(info->points[path[1]]))
		{
			train1 = Train(info->tableCost[(*it).second * 3 + 1], info->matrixDist[path[1]][path[2]]);
		}
	}

	Train train2 = Train();
	for (auto it = info->table.begin(); it != info->table.end(); it++)
	{
		if ((*it).first.find(info->points[path[5]]))
		{
			train2 = Train(info->tableCost[(*it).second * 3 + 1], info->matrixDist[path[5]][path[6]]);
		}
	}
	
	track.AddVehicle(train1, volume);
	track.AddVehicle(train2, volume);
}

void TrackBuilder_7::BuildPlanes()
{
	Info* info = Info::getInfo();

	Plane plane1 = Plane();
	for (auto it = info->table.begin(); it != info->table.end(); it++)
	{
		if ((*it).first.find(info->points[path[3]]))
		{
			plane1 = Plane(info->tableCost[(*it).second * 3], info->matrixDist[path[3]][path[4]]);
		}
	}

	track.AddVehicle(plane1, volume);
}
