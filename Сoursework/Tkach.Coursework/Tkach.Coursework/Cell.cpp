#include "Cell.h"

Cell::Cell()
{
	value = "";
}

Cell::Cell(std::string value)
{
	this->value = value;
}

Cell::~Cell()
{

}

std::string Cell::ToString()
{
	return value;
}