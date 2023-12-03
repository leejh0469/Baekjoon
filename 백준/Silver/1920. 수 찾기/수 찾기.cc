#include <iostream>
#include <algorithm>

using namespace std;

bool find(int* arrayN, int val, int N)
{
	int s = 0, e = N;
	int m = (s + e) / 2;
	bool findNum = false;
	while (s <= e)
	{
		if (val == arrayN[m]) {
			findNum = true;
			break;
		}

		if (val > arrayN[m]) s = m + 1;
		if (val < arrayN[m]) e = m - 1;


		m = (s + e) / 2;
	}

	return findNum;
}

int main()
{
    int N, M;

    cin >> N;

	int* arrayN = new int[N];

	for (int i = 0; i < N; i++)
	{
		cin >> arrayN[i];
	}

	cin >> M;

	int* arrayM = new int[M];

	for (int i = 0; i < M; i++)
	{
		cin >> arrayM[i];
	}

	sort(arrayN, arrayN + N);

	for (int i = 0; i < M; i++)
	{
		if (find(arrayN, arrayM[i], N-1))
			cout << '1' << "\n";
		else
			cout << '0' << "\n";
	}
}