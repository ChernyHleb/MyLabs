#include <iostream>
#include "Table.h"

int main()
{
    setlocale(LC_ALL, "Russian");

    std::vector<Cell*> col1Values
    {
        new Cell("01.01.2020"),
        new Cell("02.01.2020"),
        new Cell("03.01.2020"),
        new Cell("01.02.2020"),
        new Cell("02.02.2020"),
        new Cell("03.02.2020"),
        new Cell("03.03.2020")
    };

    std::vector<Cell*> col2Values
    {
        new Cell("6"),
        new Cell("4"),
        new Cell("2"),
        new Cell("4"),
        new Cell("5"),
        new Cell("2"),
        new Cell("1")
    };

    std::vector<Cell*> col3Values
    {
        new Cell("23"),
        new Cell("43"),
        new Cell("25"),
        new Cell("24"),
        new Cell("64"),
        new Cell("15"),
        new Cell("24")
    };

    std::vector<Cell*> col4Values
    {
        new Cell("Москва"),
        new Cell("Ростов"),
        new Cell("Москва"),
        new Cell("Ростов"),
        new Cell("Подольск"),
        new Cell("Подольск"),
        new Cell("Ростов")
    };

    Column* col1 = new Column("Время", DataType::DATETIME, col1Values);
    Column* col2 = new Column("Температура", DataType::INTEGER, col2Values);
    Column* col3 = new Column("Влажность", DataType::INTEGER, col3Values);
    Column* col4 = new Column("Город", DataType::STRING, col4Values);

    Table* table = new Table("Таблица1", std::vector<Column*>{col1, col2, col3, col4});

    std::cout << table->ToString();

    delete table;
}