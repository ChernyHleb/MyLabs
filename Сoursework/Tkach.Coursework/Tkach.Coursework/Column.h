#pragma once
#include <string>
#include <vector>
#include "Cell.h"
#include "FieldDescr.h"

class Column
{
public:
	Column();
	Column(FieldDescr& a_descr);
	Column(
		FieldDescr& a_descr, 
		std::vector<Cell*>& a_cells
	);
	virtual ~Column();

	void setDescr(const FieldDescr& a_descr);
	FieldDescr& descr() const;


	std::vector<Cell*>& cells() const;

	std::string ToString();

private:
	FieldDescr m_descr;
	std::vector<Cell*> m_cells;
};

