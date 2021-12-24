/*!
\file
\brief ������������ ���� � ��������� ������ Column

������ ���� �������� � ���� �������� ������ Column
*/
#ifndef COLUMN_H
#define COLUMN_H

#pragma once
#include <string>
#include <vector>
#include "Cell.h"
#include "FieldDescr.h"

/*!
	\brief �����, ������������ ������� �������

	�������� ������
*/
class Column
{
public:
	Column();
	Column(FieldDescr& a_descr);
	/*!
		�����������
		\param[in] a_descr ���������� �������, ���������� ��� � ��� ������
		\param[in] a_cells ���� �������
	*/
	Column(
		FieldDescr& a_descr, 
		std::vector<Cell*>& a_cells
	);
	virtual ~Column();

	void setDescr(const FieldDescr& a_descr);
	const FieldDescr& descr() const;

	void addCell(Cell* a_cell);
	const std::vector<Cell*>& cells() const;

	std::string ToString();

private:
	FieldDescr m_descr;
	std::vector<Cell*> m_cells;
};

#endif // CLASSES_H

