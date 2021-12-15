#pragma once
#include <string>
#include <vector>
#include "Cell.h"

class Row
{
public:
	std::vector<Cell*> cells;

	Row();
	Row(std::vector<Cell*> &);
	virtual ~Row();

	std::string ToString();
};

