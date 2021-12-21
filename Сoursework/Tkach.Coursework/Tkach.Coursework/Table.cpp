#include "Table.h"

Table::Table() { }

Table::Table(
	std::string& a_name,
	std::vector<FieldDescr>& a_descrs
) : m_name(a_name)
{ 
	for (auto it = std::begin(a_descrs); it != std::end(a_descrs); it++)
	{
		m_columns.push_back(new Column(*it));
	}
}

Table::~Table()
{
	for (auto it = std::begin(m_rows); it != std::end(m_rows); it++)
	{
		delete (*it);
	}

	for (auto it = std::begin(m_columns); it != std::end(m_columns); it++)
	{
		delete (*it);
	}

	for (auto it = std::begin(m_cells); it != std::end(m_cells); it++)
	{
		delete (*it);
	}
}

void Table::addRow(const std::vector<std::string>& a_values)
{
	std::vector<Cell*> cells;
	int columnCounter = 0;
	for (auto it = std::begin(a_values); it != std::end(a_values); it++)
	{
		std::string value = (*it);
		Cell* cell = new Cell(value);
		cells.push_back(cell);
		m_cells.push_back(cell);
		m_columns[columnCounter]->addCell(cell);
		columnCounter++;
	}

	m_rows.push_back(new Row(cells));
}

const std::vector<Row*>& Table::rows() const
{
	return m_rows;
}

void Table::addColumn(const FieldDescr& a_descr)
{
	FieldDescr descr = FieldDescr(a_descr.dataType, a_descr.name);
	m_columns.push_back(new Column(descr));
}

const std::vector<Column*>& Table::columns() const
{
	return m_columns;
}

void Table::setName(const std::string& a_name)
{
	m_name = a_name;
}

const std::string& Table::name() const
{
	return m_name;
}

std::string Table::ToString()
{
	std::string output = m_name + "\n";

	for (auto it = std::begin(m_columns); it != std::end(m_columns); it++)
	{
		output += (*it)->descr().name + "\t";
	}

	output += "\n";

	int columnCounter = 0;
	for (auto it = std::begin(m_cells); it != std::end(m_cells); it++)
	{
		columnCounter++;
		output += (*it)->ToString() + "\t";
		
		if (columnCounter == m_columns.size())
		{
			columnCounter = 0;
			output += "\n";
		}
	}

	return output;
}