#pragma once
#include "Column.h"
#include <string>
#include <vector>
#include <regex>

class DataFormatChecker
{
public:
	DataFormatChecker();
	virtual ~DataFormatChecker();

	bool Check(const Column& a_column);
	// вспомогательна€ функци€ Check
	std::vector<bool> PatternsMatch(
		const std::vector<std::regex>& a_patterns,
		const std::vector<std::string>& a_values
	);

	const std::vector<std::regex>& patterns_DATETIME() const;
	const std::vector<std::regex>& patterns_DATE() const;
	const std::vector<std::regex>& patterns_TIME() const;
	const std::vector<std::regex>& patterns_INTEGER() const;
	const std::vector<std::regex>& patterns_DOUBLE() const;
	const std::vector<std::regex>& patterns_STRING() const;
	const std::vector<std::regex>& patterns_EMPTY() const;

private:
	// коллекции регул€рных выражений  
	// дл€ каждого типа данных
	std::vector<std::regex> m_patterns_DATETIME;
	std::vector<std::regex> m_patterns_DATE;
	std::vector<std::regex> m_patterns_TIME;
	std::vector<std::regex> m_patterns_INTEGER;
	std::vector<std::regex> m_patterns_DOUBLE;
	std::vector<std::regex> m_patterns_STRING;
	std::vector<std::regex> m_patterns_EMPTY;
};

#pragma region ISO 8601
/* 
	Dates:

	YYYY
	YYYY-MM
	YYYYMMDD
	YYYY-MM-DD

	Time:

	hhmm
	hh:mm
	hhmmss
	hh:mm:ss

	Date and Time:

	YYYYMMDDThhmmss
	YYYY-MM-DDThh:mm
	YYYY-MM-DDThh:mm:ss

	where:

	YYYY = four-digit year
	MM   = two-digit month (01=January, etc.)
	DD   = two-digit day of month (01 through 31)
	hh   = two digits of hour (00 through 23) (am/pm NOT allowed)
	mm   = two digits of minute (00 through 59)
	ss   = two digits of second (00 through 59)
	s    = one or more digits representing a decimal fraction of a second
	TZD  = time zone designator (Z or +hh:mm or -hh:mm)
*/
#pragma endregion