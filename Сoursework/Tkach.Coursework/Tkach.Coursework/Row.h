#pragma once
#include <string>
#include <vector>
#include "Cell.h"

class Row
{
public:
	Row();
	Row(std::vector<Cell*>& a_cells);
	virtual ~Row();

	void setCells(const std::vector<Cell*>& a_cells);
	std::vector<Cell*>& cells() const;

	std::string ToString();

private:
	std::vector<Cell*> m_cells;
};

