#pragma once
#include <string>
#include <vector>
#include "Cell.h"

class Row
{
public:
	std::vector<Cell*> cells;

	Row();
	Row(std::vector<Cell*>);
	~Row();

	std::string ToString();
};

