#include "Cell.h"

Cell::Cell() { }

Cell::Cell(std::string value) : value(value) { }

Cell::~Cell() { }

std::string Cell::ToString()
{
	return value;
}