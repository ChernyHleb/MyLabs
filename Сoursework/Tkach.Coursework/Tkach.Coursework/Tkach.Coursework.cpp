#include <iostream>
#include <regex>
#include "Table.h"
#include "DataFormatChecker.h"
#include "Cell.h"

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

    //std::cout << table->ToString();

    //delete table;

    /*std::regex reg = std::regex("([[:digit:]]{4})(([0][1-9])|([1][012]))(([12][[:digit:]])|(3[01])|([0][1-9]))T(([01][[:digit:]])|(2[0-3]))(([0-4][[:digit:]])|(5[0-9]))(([0-4][[:digit:]])|(5[0-9]))");
    std::string str = "20050809T183142";

    std::cout << std::regex_match(str, reg);*/

    
}