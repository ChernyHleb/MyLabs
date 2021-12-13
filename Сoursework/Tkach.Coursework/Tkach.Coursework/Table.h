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
	std::vector<Cell*> cells;// TODO : сделать одномерным

	Table();
	Table(std::string, 
		std::vector<Row*>, std::vector<Column*>);
	Table(std::string, 
		std::vector<Row*>, std::vector<Column*>, 
		std::vector<std::vector<Cell*>>);
	Table(std::string, std::vector<Column*>);
	~Table();// TODO : сделать через итераторы

	std::string ToString();
};

