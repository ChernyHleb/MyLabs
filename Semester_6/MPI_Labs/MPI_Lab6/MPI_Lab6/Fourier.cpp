#pragma once
#include "Fourier.h"
#include <algorithm>
#include <iostream>
using namespace std;

static double constexpr pi = 3.14159265358979323846;
int upper_log2(const int x)
{
	for (int i = 0; i < 30; ++i)
	{
		const int temp = 1 << i;
		if (temp >= x)
			return i;
	}
	return 30;
}

const vector<complex<double>> phase_vec(const int len)
{
	vector<complex<double>> res(len);
	const double radius = 1;
	for (int i = 0; i < len; ++i)
	{
		const double phase = -2 * pi * i / len;
		res[i] = polar(radius, phase);
	}
	return res;
}

void forward(vector<complex<double>>& prev, vector<complex<double>>& temp, const vector<complex<double>>& phases, const int turn, const int n_bits)
{
	if (turn == n_bits)
		return;

	const int group_size = 1 << (turn + 1); // size of butterfly group
	const int num_groups = prev.size() / group_size;
	const int phase_angular_freq = num_groups;
	for (int i_group = 0; i_group < num_groups; ++i_group)
	{
		const int base_index = i_group * group_size;
		// iterate through within the butterfly group
		for (int j = 0; j < group_size / 2; ++j)
		{
			const int x0_index = base_index + j;
			const int x1_index = base_index + group_size / 2 + j;
			prev[x1_index] *= phases[j * phase_angular_freq];
			temp[x0_index] = prev[x0_index] + prev[x1_index];
			temp[x1_index] = prev[x0_index] - prev[x1_index];
		}
	}
	forward(temp, prev, phases, turn + 1, n_bits);
}

void bit_reversal_permutation(vector<complex<double>>& vec, const int n_bits)
{
	if (vec.size() <= 2)
		return;
	if (vec.size() == 4)
	{
		swap(vec[1], vec[3]);
		return;
	}
	vector<int> bit_rerversal(vec.size());
	// инициализируем первые 4 элемента
	bit_rerversal[0] = 0;
	bit_rerversal[1] = 1 << (n_bits - 1);
	bit_rerversal[2] = 1 << (n_bits - 2);
	bit_rerversal[3] = bit_rerversal[1] + bit_rerversal[2];

	for (int k = 3; k <= n_bits; ++k)
	{
		const int nk = (1 << k) - 1;          // n_k = 2^k - 1
		const int n_km1 = (1 << (k - 1)) - 1; // n_(k-1) = 2^(k-1) - 1
		bit_rerversal[nk] = bit_rerversal[n_km1] + (1 << (n_bits - k));
		for (int i = 1; i <= n_km1; ++i)
			bit_rerversal[nk - i] = bit_rerversal[nk] - bit_rerversal[i];
	}

	// перестановка входного вектора в соответствии с bit_rerversal[]
	for (int i = 0; i < vec.size(); ++i)
		if (bit_rerversal[i] > i)
			swap(vec[i], vec[bit_rerversal[i]]);
}

vector<complex<double>> Fourier(const vector<complex<double>>& inputs)
{
	const int n_bits = upper_log2(inputs.size()); // минимальное к-во битов
	const int len = 1 << n_bits;
	const vector<complex<double>> phases = phase_vec(len);
	vector<complex<double>> prev(len);
	vector<complex<double>> temp(len);
	copy(inputs.begin(), inputs.end(), prev.begin());
	bit_reversal_permutation(prev, n_bits);
	// Алгоритм Кули-Тьюки
	forward(prev, temp, phases, 0, n_bits);
	return (n_bits % 2 == 1) ? temp : prev;
}
vector<complex<double>> ifft(const vector<complex<double>>& inputs)
{
	// flip the order of frequency spectrum
	vector<complex<double>> reverse_freq_spectrum(inputs);
	reverse(next(reverse_freq_spectrum.begin()), reverse_freq_spectrum.end());

	// умножение 1/n на каждый элемент
	const double len = reverse_freq_spectrum.size();
	transform(reverse_freq_spectrum.begin(), reverse_freq_spectrum.end(), reverse_freq_spectrum.begin(),
		[len](const complex<double>& num) { return num / len; });
	return Fourier(reverse_freq_spectrum);
}
vector<int> round(const vector<complex<double>>& vec)
{
	vector<int> res(vec.size());
	transform(vec.begin(), vec.end(), res.begin(), [](const complex<double>& num) -> int { return std::round(num.real()); });
	return res;
}
vector<double> real(const std::vector<std::complex<double>>& vec)
{
	vector<double> res(vec.size());
	transform(vec.begin(), vec.end(), res.begin(), [](const complex<double>& num) -> double { return num.real(); });
	return res;
}
