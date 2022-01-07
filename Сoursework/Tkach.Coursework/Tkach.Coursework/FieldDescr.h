#pragma once
#include <string>
#include "DataType.h"

struct FieldDescr
{
public:
	DataType dataType;
	std::string name;
	FieldDescr(DataType a_dataType, std::string a_name)
	: dataType(a_dataType), name(a_name) { }	
	FieldDescr() { }
};
