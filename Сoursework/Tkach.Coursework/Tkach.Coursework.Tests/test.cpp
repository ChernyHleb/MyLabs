#include "pch.h"
#include "../Tkach.Coursework/Table.h"
#include "../Tkach.Coursework/Row.h"
#include "../Tkach.Coursework/FieldDescr.h"
#include "../Tkach.Coursework/DataType.h"
#include "../Tkach.Coursework/Column.h"
#include "../Tkach.Coursework/Cell.h"
#include "../Tkach.Coursework/DataFormatChecker.h"

#include "../Tkach.Coursework/Table.cpp"
#include "../Tkach.Coursework/Row.cpp"
#include "../Tkach.Coursework/Column.cpp"
#include "../Tkach.Coursework/Cell.cpp"
#include "../Tkach.Coursework/DataFormatChecker.cpp"

namespace TABLE_TESTS
{
	TEST(Table_AddColumn, When_table_with_NO_rows) 
{
	// ���������� ������� ����� ������� ��� �����
	// ARRANGE
	bool result;
	Table table;
	FieldDescr descr = FieldDescr(DataType::DATETIME, "�����");

	// ACT
	result = table.addColumn(descr);

	//ASSERT
	EXPECT_EQ(table.columns().size(), 1);
	EXPECT_STREQ(table.columns().back()->descr().name.c_str(), descr.name.c_str());
	EXPECT_EQ(table.columns().back()->descr().dataType, descr.dataType);

	ASSERT_TRUE(result);
}
	
	TEST(Table_AddColumn, When_table_with_rows)
{
	// ���������� ������� ����� ������� ����� ����
	// ARRANGE
	bool result;
	Table table;
	FieldDescr descr = FieldDescr(DataType::DATETIME, "�����");
	table.addColumn(descr);
	std::vector<std::string> rowData { "01.01.2020" };
	table.addRow(rowData);

	// ACT
	result = table.addColumn(FieldDescr(DataType::STRING, "�����"));

	//ASSERT
	EXPECT_EQ(table.columns().size(), 1);
	EXPECT_STREQ(table.columns().back()->descr().name.c_str(), descr.name.c_str());
	EXPECT_EQ(table.columns().back()->descr().dataType, descr.dataType);

	ASSERT_FALSE(result);
}
	
	TEST(Table_AddRow, When_table_with_columns)
{
	// ���������� ���� � ������� � ���������
	// ARRANGE
	bool result;
	Table table;
	table.addColumn(FieldDescr(DataType::STRING, "�����"));
	std::vector<std::string> rowData{ "������" };

	// ACT
	result = table.addRow(rowData);

	//ASSERT
	EXPECT_EQ(table.rows().size(), 1);
	EXPECT_STREQ(table.rows().back()->cells().back()->value().c_str(), rowData.back().c_str());
	
	ASSERT_TRUE(result);
}
	
	TEST(Table_AddRow, When_table_with_NO_columns) 
{
	// ���������� ���� � ������� ��� �������
	// ARRANGE
	bool result;
	Table table;
	std::vector<std::string> rowData { "01.01.2020", "6", "23", "������" };

	// ACT
	result = table.addRow(rowData);

	//ASSERT
	EXPECT_EQ(table.rows().size(), 0);
	
	ASSERT_FALSE(result);
}
	
	TEST(Table_AddRow, When_row_size_not_equal_columns_size)
{
	// ���������� ����, ���������� ����� ���� �� ������������� ��������� ������� �������
	// ARRANGE
	bool result;
	Table table;
	table.addColumn(FieldDescr(DataType::DATETIME, "�����"));
	std::vector<std::string> rowData { "01.01.2020", "6", "23", "������" };

	// ACT
	result = table.addRow(rowData);

	//ASSERT
	EXPECT_EQ(table.rows().size(), 0);

	ASSERT_FALSE(result);
}
	
	TEST(Table_Constructor, Constructor_with_name)
	{
		// �������� ������������ � a_name
		// ARRANGE
		std::string testName = "testTable";
	
		// ACT
		Table table(testName);
	
		//ASSERT
		EXPECT_EQ(table.rows().size(), 0);
		EXPECT_EQ(table.columns().size(), 0);
	
		ASSERT_STREQ(testName.c_str(), table.name().c_str());
	}

	TEST(Table_Constructor, Constructor_with_no_arguments)
	{
		// ARRANGE
	
		// ACT
		Table table = Table();
	
		//ASSERT
		EXPECT_EQ(table.rows().size(), 0);
		EXPECT_EQ(table.columns().size(), 0);
	
		ASSERT_STREQ("", table.name().c_str());
	}
	
	TEST(Table_setName, Table_name_setter)
	{
		// �������� ������ ������� �����
		// ARRANGE
		Table table(std::string("initialName"));
		std::string testName = "testName";
	
		// ACT
		table.setName(testName);
	
		//ASSERT
		EXPECT_EQ(table.rows().size(), 0);
		EXPECT_EQ(table.columns().size(), 0);
	
		ASSERT_STREQ(testName.c_str(), table.name().c_str());
	}
	
	TEST(Table_ToString, Table_ToString)
{
	// �������� ������ ToString
	// ARRANGE
	std::string name = "������� 1";
	std::vector<FieldDescr> descrs
	{
		FieldDescr(DataType::DATETIME, "�����"),
		FieldDescr(DataType::INTEGER, "�����������"),
		FieldDescr(DataType::INTEGER, "���������"),
		FieldDescr(DataType::STRING, "�����")
	};
	std::vector<std::vector<std::string>> data
	{
		{ "01.01.2020", "6", "23", "������" },
		{ "02.01.2020", "4", "43", "������" },
		{ "03.01.2020", "2", "25", "������" },
		{ "01.02.2020", "4", "24", "������" },
		{ "02.02.2020", "5", "64", "��������" },
		{ "03.02.2020", "2", "15", "��������" },
		{ "03.03.2020", "1", "24", "������" }
	};
	Table table(name);
	for (auto it = std::begin(descrs); it != std::end(descrs); it++)
	{
		table.addColumn(*it);
	}
	for (auto it = std::begin(data); it != std::end(data); it++)
	{
		table.addRow(*it);
	}

	std::string expectedStr = "";
	expectedStr += "������� 1\n";
	expectedStr += "�����\t�����������\t���������\t�����\t\n";
	expectedStr += "01.01.2020\t6\t23\t������\t\n";
	expectedStr += "02.01.2020\t4\t43\t������\t\n";
	expectedStr += "03.01.2020\t2\t25\t������\t\n";
	expectedStr += "01.02.2020\t4\t24\t������\t\n";
	expectedStr += "02.02.2020\t5\t64\t��������\t\n";
	expectedStr += "03.02.2020\t2\t15\t��������\t\n";
	expectedStr += "03.03.2020\t1\t24\t������\t\n";

	// ACT
	std::string resultStr = table.ToString();

	// ASSERT
	ASSERT_STREQ(resultStr.c_str(), expectedStr.c_str());
}

}

namespace COLUMN_TESTS
{
	TEST(Column_Constructor, Constructor_with_no_arguments)
	{
		// ARRANGE

		// ACT
		Column column = Column();

		//ASSERT
		EXPECT_EQ(column.descr().dataType, DataType::EMPTY);
		EXPECT_STREQ(column.descr().name.c_str(), "");
		EXPECT_EQ(column.cells().size(), 0);
	}

	TEST(Column_Constructor, Constructor_with_descr)
	{
		// ARRANGE
		FieldDescr descr(DataType::INTEGER, "Units");
		
		// ACT
		Column column(descr);

		//ASSERT
		EXPECT_EQ(column.descr().dataType, descr.dataType);
		EXPECT_STREQ(column.descr().name.c_str(), descr.name.c_str());
		EXPECT_EQ(column.cells().size(), 0);
	}

	TEST(Column_Constructor, Constructor_with_descr_and_cells)
	{
		// ARRANGE
		FieldDescr descr(DataType::INTEGER, "Units");
		std::vector<Cell*> cells { new Cell(std::string("1")), new Cell(std::string("2")) };

		// ACT
		Column column(descr, cells);

		//ASSERT
		EXPECT_EQ(column.descr().dataType, descr.dataType);
		EXPECT_STREQ(column.descr().name.c_str(), descr.name.c_str());
		EXPECT_EQ(column.cells().size(), 2);
		EXPECT_STREQ(column.cells()[0]->value().c_str(), cells[0]->value().c_str());
		EXPECT_STREQ(column.cells()[1]->value().c_str(), cells[1]->value().c_str());
	}

	TEST(Column_setDescr, no_cells)
	{
		// ARRANGE
		FieldDescr descr(DataType::INTEGER, "Units");
		Column column = Column();
		bool result;

		// ACT
		result = column.setDescr(descr);

		//ASSERT
		EXPECT_EQ(column.descr().dataType, descr.dataType);
		EXPECT_STREQ(column.descr().name.c_str(), descr.name.c_str());
		EXPECT_EQ(column.cells().size(), 0);

		ASSERT_TRUE(result);
	}

	TEST(Column_setDescr, with_cells)
	{
		// ARRANGE
		FieldDescr descr1(DataType::INTEGER, "Units");
		std::vector<Cell*> cells{ new Cell(std::string("1")), new Cell(std::string("2")) };
		Column column(descr1, cells);
		FieldDescr descr2(DataType::DOUBLE, "Temperature");
		bool result;

		// ACT
		result = column.setDescr(descr2);

		//ASSERT
		EXPECT_EQ(column.descr().dataType, descr1.dataType);
		EXPECT_STREQ(column.descr().name.c_str(), descr1.name.c_str());
		EXPECT_EQ(column.cells().size(), 2);

		ASSERT_FALSE(result);
	}

	TEST(Column_addCell, no_descr)
	{
		// ARRANGE
		Cell* cell = new Cell(std::string("1"));
		Column column = Column();
		bool result;

		// ACT
		result = column.addCell(cell);

		//ASSERT
		EXPECT_EQ(column.descr().dataType, DataType::EMPTY);
		EXPECT_STREQ(column.descr().name.c_str(), "");
		EXPECT_EQ(column.cells().size(), 0);

		ASSERT_FALSE(result);
	}

	TEST(Column_addCell, with_descr)
	{
		// ARRANGE
		Cell* cell = new Cell(std::string("1"));
		Column column(FieldDescr(DataType::INTEGER, "Units"));
		bool result;

		// ACT
		result = column.addCell(cell);

		//ASSERT
		EXPECT_EQ(column.cells().size(), 1);

		ASSERT_TRUE(result);
	}

	TEST(Column_ToString, ToString)
	{
		// �������� ������ ToString
		// ARRANGE
		std::vector<Cell*> cells{ new Cell(std::string("1")) , new Cell(std::string("2")) };
		Column column(FieldDescr(DataType::INTEGER, "Units"), cells);
		std::string expectedStr = "Units: 1\t2\t";

		// ACT
		std::string resultStr = column.ToString();

		// ASSERT
		ASSERT_STREQ(resultStr.c_str(), expectedStr.c_str());
	}
}

namespace ROW_TESTS
{
	TEST(Row_Constructor, no_arguments)
	{
		// ARRANGE

		// ACT
		Row row = Row();

		//ASSERT
		ASSERT_EQ(row.cells().size(), 0);
	}

	TEST(Row_Constructor, with_cells)
	{
		// ARRANGE
		std::vector<Cell*> cells{ new Cell(std::string("1")), new Cell(std::string("2")) };
		
		// ACT
		Row row(cells);

		//ASSERT
		EXPECT_STREQ(row.cells()[0]->value().c_str(), cells[0]->value().c_str());
		EXPECT_STREQ(row.cells()[1]->value().c_str(), cells[1]->value().c_str());
		ASSERT_EQ(row.cells().size(), cells.size());
	}

	TEST(Row_addCells, addCells)
	{
		// ARRANGE
		std::vector<Cell*> cells1{ new Cell(std::string("1")), new Cell(std::string("2")) };
		std::vector<Cell*> cells2{ new Cell(std::string("3")), new Cell(std::string("4")) };
		Row row(cells1);

		// ACT
		row.addCells(cells2);

		//ASSERT
		EXPECT_STREQ(row.cells()[0]->value().c_str(), cells1[0]->value().c_str());
		EXPECT_STREQ(row.cells()[1]->value().c_str(), cells1[1]->value().c_str());
		EXPECT_STREQ(row.cells()[2]->value().c_str(), cells2[0]->value().c_str());
		EXPECT_STREQ(row.cells()[3]->value().c_str(), cells2[1]->value().c_str());
		ASSERT_EQ(row.cells().size(), 4);
	}

	TEST(Row_ToString, ToString)
	{
		// ARRANGE
		std::vector<Cell*> cells
		{	
			new Cell(std::string("1")), 
			new Cell(std::string("2")),
			new Cell(std::string("3")), 
			new Cell(std::string("4")) 
		};
		Row row(cells);
		std::string expectedStr = "1\t2\t3\t4\t";

		// ACT
		std::string resultStr = row.ToString();

		//ASSERT
		ASSERT_STREQ(expectedStr.c_str(), resultStr.c_str());
	}
}

namespace CELL_TESTS 
{
	TEST(Cell_Constructor, no_arguments)
	{
		// ARRANGE

		// ACT
		Cell cell = Cell();

		//ASSERT
		EXPECT_EQ(cell.value(), "");
	}

	TEST(Cell_Constructor, with_value)
	{
		// ARRANGE
		std::string value = "123";

		// ACT
		Cell cell(value);

		//ASSERT
		EXPECT_STREQ(cell.value().c_str(), value.c_str());
	}

	TEST(Cell_setValue, setValue)
	{
		// ARRANGE
		std::string value = "123";
		Cell cell(value);
		std::string newValue = "321";

		// ACT
		cell.setValue(newValue);

		//ASSERT
		EXPECT_STREQ(cell.value().c_str(), newValue.c_str());
	}

	TEST(Cell_ToString, ToString)
	{
		// ARRANGE
		std::string value = "123";
		Cell cell(value);

		// ACT
		std::string result = cell.ToString();

		//ASSERT
		EXPECT_STREQ(value.c_str(), result.c_str());
	}
}

namespace DATA_FORMAT_CHECKER_TESTS
{
	TEST(DataFormatChecker_Constructor, no_args)
	{
		// ARRANGE

		// ACT
		DataFormatChecker checker = DataFormatChecker();

		//ASSERT
		EXPECT_EQ(checker.patterns_DATE().size(), 4);
		EXPECT_EQ(checker.patterns_TIME().size(), 4);
		EXPECT_EQ(checker.patterns_DATETIME().size(), 3);
		EXPECT_EQ(checker.patterns_INTEGER().size(), 1);
		EXPECT_EQ(checker.patterns_DOUBLE().size(), 1);
		EXPECT_EQ(checker.patterns_STRING().size(), 1);
		EXPECT_EQ(checker.patterns_EMPTY().size(), 1);
	}

	TEST(DataFormatChecker_PatternsMatch, DATETIME)
	{
		// ARRANGE
		DataFormatChecker checker = DataFormatChecker();
		std::vector<std::string> values{ 
			"20050809T183142",
			"2000-12-28T00:01:00",
			"1999-10-28T10:51",
			"2001-01-01 10:51",
			"2001-01-00T10:51",
			"",
			"321"
		};

		// ACT
		std::vector<bool> results = checker.PatternsMatch(checker.patterns_DATETIME(), values);

		//ASSERT
		EXPECT_TRUE(results[0]);
		EXPECT_TRUE(results[1]);
		EXPECT_TRUE(results[2]);
		EXPECT_FALSE(results[3]);
		EXPECT_FALSE(results[4]);
		EXPECT_FALSE(results[5]);
		EXPECT_FALSE(results[6]);
	}

	TEST(DataFormatChecker_PatternsMatch, DATE)
	{
		// ARRANGE
		DataFormatChecker checker = DataFormatChecker();
		std::vector<std::string> values{
			"2005",
			"1997-03",
			"19601231",
			"1960-12-31",

			"19998",
			"1998-13",
			"19831032",
			"1999-12-00"
		};

		// ACT
		std::vector<bool> results = checker.PatternsMatch(checker.patterns_DATE(), values);

		//ASSERT
		EXPECT_TRUE(results[0]);
		EXPECT_TRUE(results[1]);
		EXPECT_TRUE(results[2]);
		EXPECT_TRUE(results[3]);
		EXPECT_FALSE(results[4]);
		EXPECT_FALSE(results[5]);
		EXPECT_FALSE(results[6]);
		EXPECT_FALSE(results[7]);
	}

	TEST(DataFormatChecker_PatternsMatch, TIME)
	{
		// ARRANGE
		DataFormatChecker checker = DataFormatChecker();
		std::vector<std::string> values{
			"0030",
			"23:03",
			"191919",
			"04:20:00",

			"2431",
			"23-13",
			"024060",
			"04:60:0"
		};

		// ACT
		std::vector<bool> results = checker.PatternsMatch(checker.patterns_TIME(), values);

		//ASSERT
		EXPECT_TRUE(results[0]);
		EXPECT_TRUE(results[1]);
		EXPECT_TRUE(results[2]);
		EXPECT_TRUE(results[3]);
		EXPECT_FALSE(results[4]);
		EXPECT_FALSE(results[5]);
		EXPECT_FALSE(results[6]);
		EXPECT_FALSE(results[7]);
	}

	TEST(DataFormatChecker_PatternsMatch, INTEGER)
	{
		// ARRANGE
		DataFormatChecker checker = DataFormatChecker();
		std::vector<std::string> values{
			"123",
			"1000000",
			"-32",
			"0",

			"-0",
			"0.23",
			"+231",
			"qwerty"
		};

		// ACT
		std::vector<bool> results = checker.PatternsMatch(checker.patterns_INTEGER(), values);

		//ASSERT
		EXPECT_TRUE(results[0]);
		EXPECT_TRUE(results[1]);
		EXPECT_TRUE(results[2]);
		EXPECT_TRUE(results[3]);
		EXPECT_FALSE(results[4]);
		EXPECT_FALSE(results[5]);
		EXPECT_FALSE(results[6]);
		EXPECT_FALSE(results[7]);
	}

	TEST(DataFormatChecker_PatternsMatch, DOUBLE)
	{
		// ARRANGE
		DataFormatChecker checker = DataFormatChecker();
		std::vector<std::string> values{
			"1.23",
			"0.000001",
			"0",
			"-0.543",//

			"00.321",
			"0..23",
			"23.1000",//
			"qwerty"
		};

		// ACT
		std::vector<bool> results = checker.PatternsMatch(checker.patterns_DOUBLE(), values);

		//ASSERT
		EXPECT_TRUE(results[0]);
		EXPECT_TRUE(results[1]);
		EXPECT_TRUE(results[2]);
		EXPECT_TRUE(results[3]);
		EXPECT_FALSE(results[4]);
		EXPECT_FALSE(results[5]);
		EXPECT_FALSE(results[6]);
		EXPECT_FALSE(results[7]);
	}

	TEST(DataFormatChecker_PatternsMatch, STRING)
	{
		// ARRANGE
		DataFormatChecker checker = DataFormatChecker();
		std::vector<std::string> values{
			"1.23",
			"ncs9*NE(*n(#*$R89df9sdhf89WHf9",
			"",
			"������:)"
		};

		// ACT
		std::vector<bool> results = checker.PatternsMatch(checker.patterns_STRING(), values);

		//ASSERT
		EXPECT_TRUE(results[0]);
		EXPECT_TRUE(results[1]);
		EXPECT_TRUE(results[2]);
		EXPECT_TRUE(results[3]);
	}
	
	TEST(DataFormatChecker_PatternsMatch, EMPTY)
	{
		// ARRANGE
		DataFormatChecker checker = DataFormatChecker();
		std::vector<std::string> values{
			"",
			"ncs9*NE(*n(#*$R89df9sdhf89WHf9",
			"0",
			"������:)"
		};

		// ACT
		std::vector<bool> results = checker.PatternsMatch(checker.patterns_EMPTY(), values);

		//ASSERT
		EXPECT_TRUE(results[0]);
		EXPECT_FALSE(results[1]);
		EXPECT_FALSE(results[2]);
		EXPECT_FALSE(results[3]);
	}

	TEST(DataFormatChecker_Check, all_correct)
	{
		// ARRANGE
		FieldDescr descr(DataType::INTEGER, "Units");
		std::vector<Cell*> cells{ 
			new Cell(std::string("1")), 
			new Cell(std::string("2")),
			new Cell(std::string("3"))
		};
		Column column(descr, cells);
		DataFormatChecker checker = DataFormatChecker();

		// ACT
		bool result = checker.Check(column);

		//ASSERT
		ASSERT_TRUE(result);
	}
	
	TEST(DataFormatChecker_Check, one_incorrect)
	{
		// ARRANGE
		FieldDescr descr(DataType::TIME, "Time");
		std::vector<Cell*> cells{
			new Cell(std::string("04:20")),
			new Cell(std::string("24:00")),
			new Cell(std::string("0320"))
		};
		Column column(descr, cells);
		DataFormatChecker checker = DataFormatChecker();

		// ACT
		bool result = checker.Check(column);

		//ASSERT
		ASSERT_FALSE(result);
	}
	
	TEST(DataFormatChecker_Check, all_incorrect)
	{
		// ARRANGE
		FieldDescr descr(DataType::TIME, "Time");
		std::vector<Cell*> cells{
			new Cell(std::string("-=-=-=")),
			new Cell(std::string("dc-==")),
			new Cell(std::string("#$#$#$"))
		};
		Column column(descr, cells);
		DataFormatChecker checker = DataFormatChecker();

		// ACT
		bool result = checker.Check(column);

		//ASSERT
		ASSERT_FALSE(result);
	}

}