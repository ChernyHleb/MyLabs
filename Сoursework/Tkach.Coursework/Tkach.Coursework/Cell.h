#pragma once
#include <string>

class Cell
{
public:
	Cell();
	Cell(std::string& a_value);
	virtual ~Cell();

	void setValue(const std::string& a_value);
	const std::string& value() const;

	std::string ToString();

private:
	std::string m_value;
};

