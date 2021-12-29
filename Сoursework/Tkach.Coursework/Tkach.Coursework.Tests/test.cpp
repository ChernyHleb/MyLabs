#include "pch.h"
#include "../Tkach.Coursework/Table.h"
#include "../Tkach.Coursework/Row.h"
#include "../Tkach.Coursework/FieldDescr.h"
#include "../Tkach.Coursework/DataType.h"
#include "../Tkach.Coursework/Column.h"
#include "../Tkach.Coursework/Cell.h"

#include "../Tkach.Coursework/Table.cpp"
#include "../Tkach.Coursework/Row.cpp"
#include "../Tkach.Coursework/Column.cpp"
#include "../Tkach.Coursework/Cell.cpp"

TEST(Test_Table_AddColumn, When_no_rows_in_table) 
{
	// добавление колонки когда таблица без р€дов
	// ARRANGE
	bool result;
	Table* tableMock = new Table();
	FieldDescr descr = FieldDescr(DataType::DATETIME, "¬рем€");

	// ACT
	result = tableMock->addColumn(descr);

	//ASSERT
	ASSERT_TRUE(result);
}

TEST(Test_Table_AddRow, When_no_columns_in_table) 
{
	// добавление р€да когда таблица без колонок
	// ARRANGE
	bool result;
	Table* tableMock = new Table();
	std::vector<std::string> rowData { "01.01.2020", "6", "23", "ћосква" };

	// ACT
	result = tableMock->addRow(rowData);

	//ASSERT
	ASSERT_FALSE(result);
}

TEST(Test_Table_AddRow, When_row_size_not_equal_columns_size)
{
	// добавление р€да, количество €чеек р€да не соответствует количетву колонок таблицы
	// ARRANGE
	bool result;
	Table* tableMock = new Table();
	FieldDescr descr = FieldDescr(DataType::DATETIME, "¬рем€");
	tableMock->addColumn(descr);
	std::vector<std::string> rowData{ "01.01.2020", "6", "23", "ћосква" };

	// ACT
	result = tableMock->addRow(rowData);

	//ASSERT
	ASSERT_FALSE(result);
}
