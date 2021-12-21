#pragma once
#include <string>
#include <vector>
#include "Row.h"
#include "Column.h"

struct FieldDescr
{
	DataType dataType;
	std::string name;
};

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
	void addColumn(const FieldDescr& a_descr);

	void setName(const std::string& a_name);
	std::string& name() const;

	std::vector<Row*>& rows();
	std::vector<Column*>& columns();

	std::string ToString();

private:
	std::string m_name;// m - member a - attribute
	std::vector<Row*> m_rows;
	std::vector<Column*> m_columns;
	std::vector<Cell*> m_cells;
};

