#pragma once
#include <string>
#include <vector>
#include <stdexcept>
#include <exception>

using namespace std;

class LongInt
{
public:
	LongInt();
	LongInt(const string&);
	LongInt(const vector<int>&);
	LongInt(const int&);
	LongInt(const long long int&);

	vector<int> resVector() const noexcept;

	LongInt(const LongInt&);
	LongInt& operator = (const LongInt&);

	const LongInt operator +() const;
	const LongInt operator -() const;

	bool operator ==(const LongInt&) const noexcept;
	bool operator != (const LongInt&) const noexcept;
	bool operator <(const LongInt&) const noexcept;
	bool operator <= (const LongInt&) const noexcept;
	bool operator >(const LongInt&) const noexcept;
	bool operator >= (const LongInt&) const noexcept;

	LongInt operator +(const LongInt&)const noexcept;
	LongInt operator -(const LongInt&) const noexcept;
	LongInt operator *(const LongInt&)const noexcept;
	LongInt operator /(const LongInt&) const;

	LongInt operator%(const LongInt&)const noexcept;

	LongInt gcd(const LongInt&);
	LongInt random();
	vector<LongInt> factorize();

	///Toom Cook method Multiplication
	LongInt toom_cook(const LongInt& other) const;
	///Katsuba mathod
	LongInt karatsuba(const LongInt& x);
	///Schonhage Strassen Multiplication
	LongInt schonhage_strasen(const LongInt&) noexcept;
	///Module Multiplication Method (Schonhage)
	LongInt shonhage(const LongInt&);
	///Inverse Number
	LongInt inverse_number() const noexcept;
	LongInt integer_divizion_by(const LongInt&);
	///Solovay-Strassen test
	bool solovay_strassen_primality_test();
	///Test Miller-Rabin
	bool miller_rabin_primality_test();
	bool leman_primality_test();

	void print()const noexcept;

private:
	class DivideByZeroException : public exception {};
	vector<int> digits;
	bool is_positive;

	void rm_zeros();
	void shift_right();
	void shift_left();

	bool odd()const noexcept;///checks if the current number is even
	bool even()const noexcept;///checks if the current number is odd

	///karatsuba method's methodes
	void extend_vector(vector<int>& a, int n);
	vector<int> vec_karatsuba(const vector<int>& a, const vector<int>& b);
	void Fourier(vector<int>& a, bool invert);
	///for checken simplicity number
	LongInt legendre_symbol(const LongInt& a, const LongInt& b);
	LongInt jacobi_symbol(LongInt, LongInt, const vector<LongInt>&);

	LongInt pow(LongInt)const;
	LongInt sqrt_bi();
	LongInt to_binary() const noexcept;
	LongInt log2_ceil() const;

	vector<int> mul(const vector<int>& a, const vector<int>& b);
	vector<int> sum(const vector<int>& a, const vector<int>& b);
	vector<int> sub(const vector<int>& a, const vector<int>& b);
	void vect_rm_zeros(vector<int>& a);
	vector<int> to_vec(const string& a);
	vector<int> pow(const vector<int>& a, long long n);
	vector<int> random(const vector<int>& num);

	LongInt schonhage_strassen(const LongInt&) noexcept;
	bool lemman_primality_test();
};