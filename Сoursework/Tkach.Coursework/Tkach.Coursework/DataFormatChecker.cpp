#include "DataFormatChecker.h"

DataFormatChecker::DataFormatChecker() 
{
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
	*/
#pragma endregion
#pragma region regex manual
	/*
		abcЕ		Letters
		123Е		Digits
		\d			Any Digit
		\D			Any Non-digit character
		.			Any Character
		\.			Period
		[abc]		Only a, b, or c
		[^abc]		Not a, b, nor c
		[a-z]		Characters a to z
		[0-9]		Numbers 0 to 9
		\w			Any Alphanumeric character
		\W			Any Non-alphanumeric character
		{m}	m		Repetitions
		{m,n}		m to n Repetitions
		*			Zero or more repetitions
		+			One or more repetitions
		?			Optional character
		\s			Any Whitespace
		\S			Any Non-whitespace character
		^Е$			Starts and ends
		(Е)			Capture Group
		(a(bc))		Capture Sub-group
		(.*)		Capture all
		(abc|def)	Matches abc or def
	*/
#pragma endregion
	// YYYY
	m_patterns_DATE.push_back(std::regex("[[:digit:]]{4}"));
	// YYYY-MM
	m_patterns_DATE.push_back(std::regex("([[:digit:]]{4})-(([0][1-9])|([1][012]))"));
	// YYYYMMDD
	m_patterns_DATE.push_back(std::regex("([[:digit:]]{4})(([0][1-9])|([1][012]))(([12][[:digit:]])|(3[01])|([0][1-9]))"));
	// YYYY-MM-DD
	m_patterns_DATE.push_back(std::regex("([[:digit:]]{4})-(([0][1-9])|([1][012]))-(([12][[:digit:]])|(3[01])|([0][1-9]))"));

	// hhmm
	m_patterns_TIME.push_back(std::regex("(([01][[:digit:]])|(2[0-3]))(([0-4][[:digit:]])|(5[0-9]))"));
	// hh:mm
	m_patterns_TIME.push_back(std::regex("(([01][[:digit:]])|(2[0-3])):(([0-4][[:digit:]])|(5[0-9]))"));
	// hhmmss
	m_patterns_TIME.push_back(std::regex("(([01][[:digit:]])|(2[0-3]))(([0-4][[:digit:]])|(5[0-9]))(([0-4][[:digit:]])|(5[0-9]))"));
	// hh:mm:ss
	m_patterns_TIME.push_back(std::regex("(([01][[:digit:]])|(2[0-3])):(([0-4][[:digit:]])|(5[0-9])):(([0-4][[:digit:]])|(5[0-9]))"));

	// YYYYMMDDThhmmss
	m_patterns_DATETIME.push_back(std::regex("([[:digit:]]{4})(([0][1-9])|([1][012]))(([12][[:digit:]])|(3[01])|([0][1-9]))T(([01][[:digit:]])|(2[0-3]))(([0-4][[:digit:]])|(5[0-9]))(([0-4][[:digit:]])|(5[0-9]))"));
	// YYYY-MM-DDThh:mm
	m_patterns_DATETIME.push_back(std::regex("([[:digit:]]{4})-(([0][1-9])|([1][012]))-(([12][[:digit:]])|(3[01])|([0][1-9]))T(([01][[:digit:]])|(2[0-3])):(([0-4][[:digit:]])|(5[0-9]))"));
	// YYYY-MM-DDThh:mm:ss
	m_patterns_DATETIME.push_back(std::regex("([[:digit:]]{4})-(([0][1-9])|([1][012]))-(([12][[:digit:]])|(3[01])|([0][1-9]))T(([01][[:digit:]])|(2[0-3])):(([0-4][[:digit:]])|(5[0-9])):(([0-4][[:digit:]])|(5[0-9]))"));
	
	// целое число
	m_patterns_INTEGER.push_back(std::regex("(-?[1-9][0-9]*)|0"));
	
	// число с плавающей точкой
	m_patterns_DOUBLE.push_back(std::regex("-?([1-9][0-9]*[.]?[0-9]+)|(0[.][0-9]+)|([0-9])"));

	// строка
	m_patterns_STRING.push_back(std::regex("[\w\W]*"));
	
	// пустой тип
	m_patterns_EMPTY.push_back(std::regex("^$"));
}

DataFormatChecker::~DataFormatChecker() { }

bool DataFormatChecker::Check(const Column& a_column)
{
	DataType dataType = a_column.descr().dataType;
	std::vector<std::string> values;

	for (auto cell = std::begin(a_column.cells()); cell != std::end(a_column.cells()); cell++)
	{
		values.push_back((*cell)->value());
	}

	std::vector<bool> results;

	switch (dataType)
	{
	case DataType::DATETIME:
		results = PatternsMatch(m_patterns_DATETIME, values);
		break;
	case DataType::DATE:
		results = PatternsMatch(m_patterns_DATE, values);
		break;
	case DataType::TIME:
		results = PatternsMatch(m_patterns_TIME, values);
		break;
	case DataType::INTEGER:
		results = PatternsMatch(m_patterns_INTEGER, values);
		break;
	case DataType::DOUBLE:
		results = PatternsMatch(m_patterns_DOUBLE, values);
		break;
	case DataType::STRING:
		results = PatternsMatch(m_patterns_STRING, values);
		break;
	case DataType::EMPTY:
		results = PatternsMatch(m_patterns_EMPTY, values);
		break;
	}

	if(results.size() == 0)
		return false;

	bool result = true;

	for (auto res = std::begin(results); res != std::end(results); res++)
		result = result && (*res);

	return result;
}

std::vector<bool> DataFormatChecker::PatternsMatch(
	const std::vector<std::regex>& a_patterns,
	const std::vector<std::string>& a_values
)
{
	std::vector<bool> results;
	
	for (auto value = std::begin(a_values); value != std::end(a_values); value++)
	{
		bool result = false;
		for (auto pattern = std::begin(a_patterns); pattern != std::end(a_patterns); pattern++)
		{
			if (std::regex_match(*value, *pattern))
			{
				result = true;
				break;
			}
		}
		results.push_back(result);
	}

	return results;
}

const std::vector<std::regex>& DataFormatChecker::patterns_DATETIME() const
{
	return m_patterns_DATETIME; 
}

const std::vector<std::regex>& DataFormatChecker::patterns_DATE() const
{
	return m_patterns_DATE;
}

const std::vector<std::regex>& DataFormatChecker::patterns_TIME() const
{
	return m_patterns_TIME;
}

const std::vector<std::regex>& DataFormatChecker::patterns_INTEGER() const
{
	return m_patterns_INTEGER;
}

const std::vector<std::regex>& DataFormatChecker::patterns_DOUBLE() const
{
	return m_patterns_DOUBLE;
}

const std::vector<std::regex>& DataFormatChecker::patterns_STRING() const
{
	return m_patterns_STRING;
}

const std::vector<std::regex>& DataFormatChecker::patterns_EMPTY() const
{
	return m_patterns_EMPTY;
}