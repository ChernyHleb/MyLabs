#include "Column.h"

Column::Column()
{
	name = "";
	type = DataType::EMPTY;
}

Column::Column(std::string name, DataType type) 
{
	this->name = name;
	this->type = type;
}

Column::Column(std::string name, DataType type, std::vector<Cell*> cells)
	: Column(name, type)
{ 
	this->cells = cells;
}

Column::~Column()
{
	// cells уда€л€ютс€ в Table
}