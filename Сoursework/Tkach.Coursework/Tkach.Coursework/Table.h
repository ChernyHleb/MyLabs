#pragma once
#include <string>
#include <vector>
#include "Row.h"
#include "Column.h"

class Table
{
public:

	// после модульных тестов задокументировать в формате doxygen
	// на каждый метод public минимум 1 тест,  написать тесты для всех классов

	// созд таблицу
	// подача колонок (дескр) через метод
	// пока данных нет можно добавлять колонки
	// если таблица не пустая то addColumn выдает ошибка
	// addRow не работает если нет колонок или кол-во знач не соотв кол-ву колонок
	// addRow/Column - возвр bool
	// true - если добавление произошло


	// тесты должны быть
	// тип2 - корректное поведение - для true
	// тип1 - некорректное поведение (для false)
	Table();

	// сделать комментарии для методов в формате doxygen
	Table(
		std::string& a_name
	);
	// google test - написать тесты для классов, конструкторы, методы .. 
	// создать метод очистки векторов
	virtual ~Table();

	void addRow(const std::vector<std::string>& a_values);
	const std::vector<Row*>& rows() const;

	void addColumn(const FieldDescr& a_descr);
	const std::vector<Column*>& columns() const;

	void setName(const std::string& a_name);
	const std::string& name() const;

	std::string ToString();

private:
	std::string m_name;
	std::vector<Row*> m_rows;
	std::vector<Column*> m_columns;
	std::vector<Cell*> m_cells;
};

