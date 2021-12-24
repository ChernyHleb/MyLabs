/*!
\file
\brief Заголовочный файл с описанием класса Column

Данный файл содержит в себе описание класса Column
*/
#ifndef COLUMN_H
#define COLUMN_H

#pragma once
#include <string>
#include <vector>
#include "Cell.h"
#include "FieldDescr.h"

/*!
	\brief Класс, определяющий колонки таблицы

	описание класса
*/
class Column
{
public:
	Column();
	Column(FieldDescr& a_descr);
	/*!
		Конструктор
		\param[in] a_descr Дескриптор колонки, содержащий имя и тип данных
		\param[in] a_cells Поля колонки
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

