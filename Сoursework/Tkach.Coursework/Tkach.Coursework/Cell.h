#pragma once
#include <string>

class Cell
{
public:
	std::string value;

	Cell();
	Cell(std::string);
	virtual ~Cell();

	std::string ToString();
};

