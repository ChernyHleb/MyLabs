#pragma once
#include <vector>
#include <complex>
using namespace std;

vector<complex<double>> Fourier(const vector<complex<double>>& vec);
vector<complex<double>> ifft(const vector<complex<double>>& vec);
vector<int> round(const vector<complex<double>>& vec);
vector<double> real(const vector<complex<double>>& vec);
