#include "Cell.h"

Cell::Cell() { }

Cell::Cell(std::string& a_value) : m_value(a_value) { }

Cell::~Cell() { }

void Cell::setValue(const std::string& a_value) { m_value = a_value; }

const std::string& Cell::value() const 
{
	return m_value;
}

std::string Cell::ToString()
{
	return m_value;
}