#include "Row.h"

Row::Row()
{

}


Row::Row(std::vector<Cell*> cells)
{
	this->cells = cells;
}

Row::~Row()
{
	// cells удал€ютс€ в Table
}

std::string Row::ToString()
{
	std::string output;

	for (int i = 0; i < cells.size(); i++)
	{
		output += cells[i]->ToString() + "\t";
	}
	return output;
}