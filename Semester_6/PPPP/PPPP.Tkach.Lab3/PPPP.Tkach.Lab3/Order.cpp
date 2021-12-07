#include "Order.h"

#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string>
#include <algorithm>
#include <map>
#include "Info.h"
#include "TrackBuilder.h"
#include "TrackBuilder_1.h"
#include "TrackBuilder_3.h"
#include "TrackBuilder_5.h"
#include "TrackBuilder_7.h"

Order::Order()
{
	this->cost = 0;
	this->volume = 0;
	this->startPoint = "";
	this->finishPoint = "";
	this->track = Track();
	this->type = Type::Economy;
}

Order::Order(Type deliv, std::string startP, std::string finishP, int vol)
{
	this->startPoint = startP;
	this->finishPoint = finishP;
	type = deliv;
	this->track = best(startP, finishP, deliv, vol);
	this->cost = track.getCost();
	this->volume = vol;
}

Order::~Order()
{

}

Track Order::ConstructTrack()
{
	builder.BuildTrack();
	builder.BuildCars();
	builder.BuildTrains();
	builder.BuildPlanes();

	return builder.getTrack();
}

void Order::SetTrackBuilder(TrackBuilder b)
{
	builder = b;
}

Track Order::best(std::string startP, std::string finishP, Type deliv, int volume)
{
	Info* info = Info::getInfo();

	int start = decr(startP);
	int finish = decr(finishP);
	int** mat = new int* [info->SIZE];
	for (int i = 0; i < info->SIZE; i++)
		mat[i] = new int[info->SIZE];
	mat = matrixUpd(deliv);
	int* path = new int[info->SIZE];
	for (int i = 0; i < info->SIZE; i++)
	{
		path[i] = -1;
	}
	path = optim(mat, start, finish);
	int count = 0;
	for (int i = 0; i < info->SIZE; i++)
	{
		if (path[i] != -1)
		{
			count++;
		}
		else
		{
			break;
		}
	}

	switch (count)
	{
		case 1:
			SetTrackBuilder(TrackBuilder_1(path, volume));
			break;
		case 3:
			SetTrackBuilder(TrackBuilder_3(path, volume));
			break;
		case 5:
			SetTrackBuilder(TrackBuilder_5(path, volume));
			break;
		case 7:
			SetTrackBuilder(TrackBuilder_7(path, volume));
			break;
	}

	return ConstructTrack();
}

int** Order::matrixUpd(Type type)
{
	Info* info = Info::getInfo();
	int** matrix = new int* [info->SIZE];
	for (int i = 0; i < info->SIZE; i++)
	{
		matrix[i] = new int[info->SIZE];
		for (int j = 0; j < info->SIZE; j++)
		{
			matrix[i][j] = info->matrixDist[i][j];
		}
	}
	switch (type)
	{
	case Economy:
		for (int i = 0; i < info->SIZE; i++)
		{
			if (info->points[i].find("TS"))
				for (int j = 0; j < info->SIZE; j++)
					matrix[i][j] = 99999;
		}
	case Standart:
		for (int i = 0; i < info->SIZE; i++)
		{
			if (info->points[i].find("AP"))
				for (int j = 0; j < info->SIZE; j++)
					matrix[i][j] = 99999;
		}
	case Turbo:
		for (int i = 0; i < info->SIZE; i++)
		{
			for (int j = 0; j < info->SIZE; j++)
				if (matrix[i][j] == 0)
					matrix[i][j] = 99999;
		}
	}
	return matrix;
}

int* Order::optim(int** arr, int beginPoint, int endPoint)
{
	Info* info = Info::getInfo();
	int* d = new int[info->SIZE];
	int* v = new int[info->SIZE];
	int temp, minindex, min;
	int begin_index = beginPoint;

	for (int i = 0; i < info->SIZE; i++)
	{
		d[i] = 99999;
		v[i] = 1;
	}
	d[begin_index] = 0;

	do {
		minindex = 99999;
		min = 99999;
		for (int i = 0; i < info->SIZE; i++)
		{
			if ((v[i] == 1) && (d[i] < min))
			{
				min = d[i];
				minindex = i;
			}
		}

		if (minindex != 99999)
		{
			for (int i = 0; i < info->SIZE; i++)
			{
				if (arr[minindex][i] > 0)
				{
					temp = min + arr[minindex][i];
					if (temp < d[i])
					{
						d[i] = temp;
					}
				}
			}
			v[minindex] = 0;
		}
	} while (minindex < 99999);

	int* ver = new int[info->SIZE];
	int end = endPoint;
	ver[0] = end;
	int k = 1;
	int weight = d[end];

	while (end != begin_index)
	{
		for (int i = 0; i < info->SIZE; i++)
			if (arr[end][i] != 0)
			{
				int temp = weight - arr[end][i];
				if (temp == d[i])
				{
					weight = temp;
					end = i;
					ver[k] = i + 1;
					k++;
				}
			}
	}
	for (int i = 0; i < k / 2; i++)
		std::swap(ver[i], ver[k - 1 - i]);
	delete[] d, v;
	return ver;
}

int Order::decr(std::string str)
{
	Info* info = Info::getInfo();
	for (auto it = info->towns.begin(); it != info->towns.end(); it++)
	{
		if (str._Equal((*it).first))
			return (*it).second;
	}
	return -1;
}