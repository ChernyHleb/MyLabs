#pragma once
#include <string>
#include <vector>
#include "Row.h"
#include "Column.h"

class Table
{
public:
	Table();

	// доработать
	// сделать остальные по образцу
	// сделать комментарии для методов в формате doxygen
	Table(
		std::string& a_name,
		std::vector<FieldDescr>& a_descrs
	);
	virtual ~Table();

	// реализовать
	void addRow(const std::vector<std::string>& a_values);
	std::vector<Row*>& rows();

	void addColumn(const FieldDescr& a_descr);
	std::vector<Column*>& columns();

	void setName(const std::string& a_name);
	std::string& name() const;

	std::string ToString();

private:
	std::string m_name;
	std::vector<Row*> m_rows;
	std::vector<Column*> m_columns;
	std::vector<Cell*> m_cells;
};

