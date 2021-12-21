#include "Row.h"

Row::Row() { }

Row::Row(std::vector<Cell*>& a_cells) : m_cells(a_cells) { }

Row::~Row() { }

void Row::setCells(const std::vector<Cell*>& a_cells) { m_cells = a_cells; }

const std::vector<Cell*>& Row::cells() const 
{ 
	return m_cells; 
}

std::string Row::ToString()
{
	std::string output;

	for (auto it = std::begin(m_cells); it != std::end(m_cells); it ++)
	{
		output += (*it)->ToString() + "\t";
	}

	return output;
}