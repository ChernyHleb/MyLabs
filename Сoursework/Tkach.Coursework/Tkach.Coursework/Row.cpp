#include "Row.h"

Row::Row()
{
	name = "";
}

Row::Row(std::string name)
{
	this->name = name;
}

Row::Row(std::string name, std::vector<Cell*> cells)
	: Row(name)
{
	this->cells = cells;
}

Row::~Row()
{
	// cells удал€ютс€ в Table
}

std::string Row::ToString()
{
	std::string output = "";

	for (int i = 0; i < cells.size(); i++)
	{
		output += cells[i]->ToString() + "\t";
	}
}