#include "Column.h"

Column::Column()
{
	m_descr.dataType = DataType::EMPTY;
}

Column::Column(FieldDescr& a_descr) : m_descr(a_descr) { }

Column::Column(FieldDescr& a_descr, std::vector<Cell*>& a_cells)
	: m_descr(a_descr), m_cells(a_cells) { }

Column::~Column() { }

void Column::setDescr(const FieldDescr& a_descr) { m_descr = a_descr; }

const FieldDescr& Column::descr() const { return m_descr; }

void Column::addCell(Cell* a_cell)
{
	m_cells.push_back(a_cell);
}

const std::vector<Cell*>& Column::cells() const { return m_cells; }

std::string Column::ToString()
{
	std::string output = m_descr.name + ": ";

	for (auto it = std::begin(m_cells); it != std::end(m_cells); it++)
	{
		output += (*it)->ToString() + "\t";
	}

	return output;
}