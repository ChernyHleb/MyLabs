#pragma once
#include <string>
#include <vector>
#include "Cell.h"

class Row
{
public:
	std::string name;
	std::vector<Cell*> cells;

	Row();
	Row(std::string);
	Row(std::string, std::vector<Cell*>);
	~Row();

	std::string ToString();
};

