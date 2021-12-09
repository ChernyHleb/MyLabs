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

Table::Table(std::string name, std::vector<Column*> columns)
{
	this->name = name;
	this->columns = columns;

	for (int i = 0; i < columns[0]->cells.size(); i++)
	{
		std::vector<Cell*> rowCells;
		for (int j = 0; j < columns.size(); j++)
		{
			rowCells.push_back(columns[j]->cells[i]);
		}
		rows.push_back(new Row("", rowCells));
		this->cells.push_back(rowCells);
	}
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

std::string Table::ToString()
{
	std::string output = name + "\n";

	for (int i = 0; i < columns.size(); i++)
	{
		output += columns[i]->name + "\t";
	}
	output += "\n";

	for (int i = 0; i < cells.size(); i++)
	{
		for (int j = 0; j < cells[i].size(); j++)
		{
			output += cells[i][j]->ToString() + "\t";
		}
		output += "\n";
	}
}