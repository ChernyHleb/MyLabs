#include "Table.h"

Table::Table() { }

Table::Table(std::string name, 
		     std::vector<std::string> &columnNames, 
			 std::vector<DataType> &columnTypes,
			 std::vector<Cell*> &cells) 
	: name(name), cells(cells)
{
	
}

Table::Table(std::string name, std::vector<Column*> &columns)
	: name(name), columns(columns)
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
	for (auto it = std::begin(rows); it != std::end(rows); it++)
	{
		delete (*it);
	}

	for (auto it = std::begin(columns); it != std::end(columns); it++)
	{
		delete (*it);
	}

	for (auto it = std::begin(cells); it != std::end(cells); it++)
	{
		delete (*it);
	}
}

std::string Table::ToString()
{
	std::string output = name + "\n";

	for (auto it = std::begin(columns); it != std::end(columns); it++)
	{
		output += (*it)->name + "\t";
	}

	output += "\n";

	int columnCounter = 0;
	for (auto it = std::begin(cells); it != std::end(cells); it++)
	{
		columnCounter++;
		output += (*it)->ToString() + "\t";
		
		if (columnCounter == columns.size())
		{
			columnCounter = 0;
			output += "\n";
		}
	}

	return output;
}