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

/// TABLE CLASS TESTS
TEST(Test_Table_AddColumn, When_table_with_NO_rows) 
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
	EXPECT_STREQ(table.columns().back()->descr().name.c_str(), "�����");
	EXPECT_EQ(table.columns().back()->descr().dataType, DataType::DATETIME);
	ASSERT_TRUE(result);
}

TEST(Test_Table_AddColumn, When_table_with_rows)
{
	// ���������� ������� ����� ������� ����� ����
	// ARRANGE
	bool result;
	Table table;

	FieldDescr descr1 = FieldDescr(DataType::DATETIME, "�����");
	table.addColumn(descr1);
	
	std::vector<std::string> rowData { "01.01.2020" };
	table.addRow(rowData);

	FieldDescr descr2 = FieldDescr(DataType::STRING, "�����");

	// ACT
	result = tableMock.addColumn(descr2);

	//ASSERT
	ASSERT_FALSE(result);
}

TEST(Test_Table_AddRow, When_table_with_columns)
{
	// ���������� ���� � ������� � ���������
	// ARRANGE
	bool result;
	Table tableMock;
	FieldDescr descr = FieldDescr(DataType::STRING, "�����");
	tableMock.addColumn(descr);
	std::vector<std::string> rowData{ "������" };

	// ACT
	result = tableMock.addRow(rowData);

	//ASSERT
	// �������� �������� ���� ��� ������ ���� ��������� � �������, ��������� ��� ���� ������
	ASSERT_TRUE(result);
}

TEST(Test_Table_AddRow, When_table_with_NO_columns) 
{
	// ���������� ���� � ������� ��� �������
	// ARRANGE
	bool result;
	Table tableMock;
	std::vector<std::string> rowData { "01.01.2020", "6", "23", "������" };

	// ACT
	result = tableMock.addRow(rowData);

	//ASSERT
	// �������� �������� ���� ��� ������ �� ���� ��������� � �������, ��������� ��� ���� ������
	ASSERT_FALSE(result);
}

TEST(Test_Table_AddRow, When_row_size_not_equal_columns_size)
{
	// ���������� ����, ���������� ����� ���� �� ������������� ��������� ������� �������
	// ARRANGE
	bool result;
	Table tableMock;
	FieldDescr descr = FieldDescr(DataType::DATETIME, "�����");
	tableMock.addColumn(descr);
	std::vector<std::string> rowData { "01.01.2020", "6", "23", "������" };

	// ACT
	result = tableMock.addRow(rowData);

	//ASSERT
	ASSERT_FALSE(result);
}

TEST(Test_Table_Constructor, Constructor_with_name)
{
	// �������� �������� ������ �����

	// �������� ������������ � a_name
	// ARRANGE
	std::string testName = "testTable";

	// ACT
	Table tableMock(testName);

	//ASSERT
	ASSERT_STREQ(testName.c_str(), tableMock.name().c_str());
}

TEST(Test_Table_setName, Table_name_setter)
{
	// �������� ������ ������� �����
	// ARRANGE
	Table tableMock(std::string("initialName"));
	std::string testName = "testName";

	// ACT
	tableMock.setName(testName);

	//ASSERT
	ASSERT_STREQ(testName.c_str(), tableMock.name().c_str());
}

TEST(Test_Table_ToString, Table_ToString)
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