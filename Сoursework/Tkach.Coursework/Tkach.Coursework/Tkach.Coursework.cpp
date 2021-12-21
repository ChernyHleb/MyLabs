#include <iostream>
#include "Table.h"

int main()
{
    setlocale(LC_ALL, "Russian");

    std::vector<std::string> colNames
    {
        "Время", "Температура", "Влажность", "Город"
    };

    std::vector<DataType> colTypes
    {
        DataType::DATETIME, DataType::INTEGER, DataType::INTEGER, DataType::STRING
    };

    std::vector<std::string> cellValues
    { 
        "01.01.2020", "6", "23", "Москва",
        "02.01.2020", "4", "43", "Ростов",
        "03.01.2020", "2", "25", "Москва",
        "01.02.2020", "4", "24", "Ростов",
        "02.02.2020", "5", "64", "Подольск",
        "03.02.2020", "2", "15", "Подольск",
        "03.03.2020", "1", "24", "Ростов"
    };

    // TODO перенести в Table,
    std::vector<Row*> rows;
    int rowLen = 4;
    for (auto it = std::begin(cellValues); it != std::end(cellValues);)
    {
        std::vector<Cell*> rowCells;
        for (int i = 0; i < rowLen; i++)
        {
            rowCells.push_back(new Cell(*it));
            it++;
        }
        rows.push_back(new Row(rowCells));
    }

    Table* table = new Table("Таблица1", colNames, colTypes, rows);

    std::cout << table->ToString();

    delete table;
}