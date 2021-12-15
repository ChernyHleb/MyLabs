#include "Column.h"

Column::Column() : type(DataType::EMPTY) { }

Column::Column(std::string name, DataType type) : name(name), type(type) { }

Column::Column(std::string name, DataType type, std::vector<Cell*> &cells)
	: name(name), type(type), cells(cells) { }

// cells уда€л€ютс€ в Table
Column::~Column() { }

std::string Column::ToString()
{
	std::string output = name + ": ";

	for (auto it = std::begin(cells); it != std::end(cells); it++)
	{
		output += (*it)->ToString() + "\t";
	}

	return output;
}