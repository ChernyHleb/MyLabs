#include <iostream>
#include "Table.h"

int main()
{
    setlocale(LC_ALL, "Russian");

    std::string name = "Таблица 1";

    std::vector<FieldDescr> descrs
    {
        FieldDescr(DataType::DATETIME, "Время"),
        FieldDescr(DataType::INTEGER, "Температура"),
        FieldDescr(DataType::INTEGER, "Влажность"),
        FieldDescr(DataType::STRING, "Город")
    };

    std::vector<std::vector<std::string>> data
    { 
        { "01.01.2020", "6", "23", "Москва" },
        { "02.01.2020", "4", "43", "Ростов" },
        { "03.01.2020", "2", "25", "Москва" },
        { "01.02.2020", "4", "24", "Ростов" },
        { "02.02.2020", "5", "64", "Подольск" },
        { "03.02.2020", "2", "15", "Подольск" },
        { "03.03.2020", "1", "24", "Ростов" }
    };

    Table* table = new Table(name);

    for (auto it = std::begin(descrs); it != std::end(descrs); it++)
    {
        table->addColumn(*it);
    }

    for (auto it = std::begin(data); it != std::end(data); it++)
    {
        table->addRow(*it);
    }

    std::cout << table->ToString();

    delete table;
}