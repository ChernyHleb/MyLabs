#include "Row.h"

Row::Row() { }

Row::Row(std::vector<Cell*>& a_cells) : m_cells(a_cells) { }

Row::~Row() { }

void Row::addCells(const std::vector<Cell*>& a_cells) 
{ 
	for (auto it = std::begin(a_cells); it != std::end(a_cells); it++)
	{
		m_cells.push_back(*it);
	}
}

const std::vector<Cell*>& Row::cells() const 
{ 
	return m_cells; 
}

/// \brief ���������� ����� ��� ������ ������ � ���� ������
/// \param ���������� ���
/// \return ����� ���������� ������ std::string, ���������� ���������� � ������� 
std::string Row::ToString()
{
	std::string output;///< ���������� ��� �������� ������������� ���������� 

	for (auto it = std::begin(m_cells); it != std::end(m_cells); it ++)
	{
		output += (*it)->ToString() + "\t";
	}

	return output;
}