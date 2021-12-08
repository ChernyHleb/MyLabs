#include "Table.h"

Table::Table()
{
	name = "";
}

Table::Table(std::string name, std::vector<Row*> rows, std::vector<Column*> columns)
{
	this->name = name;
	this->rows = rows;
	this->columns = columns;
}

Table::Table(std::string name, std::vector<Row*> rows, std::vector<Column*> columns,
			 std::vector<std::vector<Cell*>> cells)
	: Table(name, rows, columns)
{
	this->cells = cells;
}

Table::~Table()
{
	for (int i = 0; i < rows.size(); i++)
	{
		delete rows[i];
	}

	for (int i = 0; i < columns.size(); i++)
	{
		delete columns[i];
	}

	for (int i = 0; i < cells.size(); i++)
	{
		for (int j = 0; j < cells[i].size(); j++)
		{
			delete cells[i][j];
		}
	}
}