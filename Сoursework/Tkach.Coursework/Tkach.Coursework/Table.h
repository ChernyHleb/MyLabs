#pragma once
#include <string>
#include <vector>
#include "Row.h"
#include "Column.h"

class Table
{
public:
	// ������� ����������� ��� ������� � ������� doxygen

	// google test - �������� ����� ��� �������, ������������, ������ ..
	// ����� ��������� ������ ����������������� � ������� doxygen
	// �� ������ ����� public ������� 1 ����,  �������� ����� ��� ���� �������
	// ����� ������ ����
	// ���2 - ���������� ��������� - ��� true
	// ���1 - ������������ ��������� (��� false)

	// + ���� ������� 
	// + ������ ������� (�����) ����� ����� 
	// + ���� ������ ��� ����� ��������� �������
	// + ���� ������� �� ������ �� addColumn ������ ������
	// + addRow �� �������� ���� ��� ������� ��� ���-�� ���� �� ����� ���-�� �������
	// + addRow/Column - ����� bool
	// + true - ���� ���������� ���������

	Table();
	Table(
		std::string& a_name
	);
	virtual ~Table();

	bool addRow(const std::vector<std::string>& a_values);
	const std::vector<Row*>& rows() const;

	bool addColumn(const FieldDescr& a_descr);
	const std::vector<Column*>& columns() const;

	void setName(const std::string& a_name);
	const std::string& name() const;

	std::string ToString();

private:
	std::string m_name;
	std::vector<Row*> m_rows;
	std::vector<Column*> m_columns;
	std::vector<Cell*> m_cells;

	// ��������������� ����� �����������
	template<typename T>
	void deleteVectorOfObjects(const std::vector<T>& collection);
};

