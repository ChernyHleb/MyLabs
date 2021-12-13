#include "Column.h"

Column::Column() : type(DataType::EMPTY) // в остальных сделать так же
{

}

Column::Column(std::string name, DataType type) 
{
	this->name = name;
	this->type = type;
}

Column::Column(std::string name, DataType type, std::vector<Cell*> cells)
{ 
	this->cells = cells;
}

Column::~Column()
{
	// cells удаяляются в Table
}

std::string Column::ToString()
{
	std::string output = name + ": ";
	
	for (int i = 0; i < cells.size(); i++)
	{
		output += cells[i]->ToString() + "\t";
	}

	return output;
}