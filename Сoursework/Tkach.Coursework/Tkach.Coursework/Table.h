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
	std::vector<Cell*> cells;

	Table();
	Table(std::string,
		std::vector<std::string>&,
		std::vector<DataType>&,
		std::vector<Row*>&
	);
	virtual ~Table();

	std::string ToString();
};

