#include "Table.h"

Table::Table() { }

Table::Table(
	std::string& a_name
) : m_name(a_name) { }

Table::~Table()
{
	deleteVectorOfObjects(m_rows);
	deleteVectorOfObjects(m_columns);
	deleteVectorOfObjects(m_cells);
}

template<typename T>
void Table::deleteVectorOfObjects(const std::vector<T>& collection)
{
	for (auto it = std::begin(collection); it != std::end(collection); it++)
	{
		delete (*it);
	}
}

bool Table::addRow(const std::vector<std::string>& a_values)
{
	bool wasAdded = false;

	// ряд можно добавить только если колонки существуют
	// и количество колонок соответствует количеству ячеек ряда
	if (!m_columns.empty() && a_values.size() == m_columns.size())
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
		wasAdded = true;
	}

	return wasAdded;
}

const std::vector<Row*>& Table::rows() const
{
	return m_rows;
}

bool Table::addColumn(const FieldDescr& a_descr)
{
	bool wasAdded = false;

	// новые колонки можно добавлять только если рядов и клеток еще нет
	if (m_rows.empty() && m_cells.empty())
	{
		FieldDescr descr = FieldDescr(a_descr.dataType, a_descr.name);
		m_columns.push_back(new Column(descr));
		wasAdded = true;
	}

	return wasAdded;
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