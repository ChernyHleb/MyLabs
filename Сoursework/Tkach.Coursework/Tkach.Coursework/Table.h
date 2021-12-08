#pragma once
#include <string>
#include <vector>
#include "Row.h"
#include "Column.h"
class Table
{
public:
	std::string name;
	std::vector<Row*> rows;
	std::vector<Column*> columns;
	std::vector<std::vector<Cell*>> cells;

	Table();
	Table(std::string, std::vector<Row*>, std::vector<Column*>);
	Table(std::string, std::vector<Row*>, std::vector<Column*>, 
		std::vector<std::vector<Cell*>>);
	~Table();
};

