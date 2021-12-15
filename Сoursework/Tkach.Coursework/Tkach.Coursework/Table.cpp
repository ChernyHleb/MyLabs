#include "Table.h"

Table::Table() { }

Table::Table(std::string name, 
		     std::vector<std::string> &columnNames, 
			 std::vector<DataType> &columnTypes,
			 std::vector<Row*> &rows) 
	: name(name), rows(rows)
{
	int columnsAmount = rows[0]->cells.size();

	for (int columnCounter = 0; columnCounter < columnsAmount; columnCounter++)
	{
		std::vector<Cell*> columnCells;
		for (auto row = std::begin(rows); row != std::end(rows); row++)
		{
			Cell* currentCell = (*row)->cells[columnCounter];
			columnCells.push_back(currentCell);
		}

		columns.push_back(
			new Column(
				columnNames[columnCounter], 
				columnTypes[columnCounter], 
				columnCells
			)
		);
	}

	for (auto row = std::begin(rows); row != std::end(rows); row++)
	{
		for (auto cell = std::begin((*row)->cells); cell != std::end((*row)->cells); cell++)
		{
			cells.push_back(*cell);
		}
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