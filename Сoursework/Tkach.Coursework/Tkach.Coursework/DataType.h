#pragma once
/// Набор возможных типов данных колонки
enum class DataType
{
    DATETIME, ///< дата и время
    INTEGER, ///< целочисленный тип
    DOUBLE, ///< числа с плавающей запятой
    STRING, ///< строковый тип
    EMPTY ///< пустой тип или NULL
};