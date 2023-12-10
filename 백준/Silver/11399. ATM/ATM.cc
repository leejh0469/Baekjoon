#include <iostream>
#include <algorithm>
using namespace std;

int main()
{
    int N;

	cin >> N;

    int* ary = new int[N];

	for (int i = 0; i < N; i++)
	{
		cin >> ary[i];
	}

	sort(ary, ary + N);
	int previous = ary[0];
	int sum = ary[0];

	for (int i = 1; i < N; i++)
	{
		ary[i] += previous;
		previous = ary[i];
		sum += ary[i];
	}

	cout << sum;
}