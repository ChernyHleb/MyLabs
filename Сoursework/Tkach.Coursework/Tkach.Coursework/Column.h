#pragma once
#include <string>
#include <vector>
#include "Cell.h"
#include "DataType.h"

class Column
{
public:
	std::string name;
	std::vector<Cell*> cells;
	DataType type;

	Column();
	Column(std::string, DataType);
	Column(std::string, DataType, std::vector<Cell*>);
	// TODO: ������� �������� ������� �� ������
	virtual ~Column();// TODO: ������� virtual

	std::string ToString();
};

