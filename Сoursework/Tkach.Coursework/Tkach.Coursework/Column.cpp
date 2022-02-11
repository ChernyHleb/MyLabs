#include "Column.h"

Column::Column()
{
	m_descr.dataType = DataType::EMPTY;
}

Column::Column(FieldDescr& a_descr) : m_descr(a_descr) { }

Column::Column(FieldDescr& a_descr, std::vector<Cell*>& a_cells)
	: m_descr(a_descr), m_cells(a_cells) { }

Column::~Column() { }

bool Column::setDescr(const FieldDescr& a_descr) 
{ 
	// дескриптор можно изменять только если не были добавлены клетки

	if(m_cells.size() == 0)
	{
		m_descr = a_descr;
		return true;
	}

	return false;
}

const FieldDescr& Column::descr() const { return m_descr; }

bool Column::addCell(Cell* a_cell)
{
	// клетки можно добавлять только если дескриптор не пустой
	if (m_descr.dataType != DataType::EMPTY && m_descr.name != "")
	{
		m_cells.push_back(a_cell);
		return true;
	}

	return false;
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