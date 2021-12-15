#include "Row.h"

Row::Row() { }

Row::Row(std::vector<Cell*> &cells) : cells(cells) { }

// cells удал€ютс€ в Table
Row::~Row() { }

std::string Row::ToString()
{
	std::string output;

	for (auto it = std::begin(cells); it != std::end(cells); it ++)
	{
		output += (*it)->ToString() + "\t";
	}

	return output;
}