#include <iostream>

using namespace std;

int N, M;
int trees[1000001];

int main()
{
	ios::sync_with_stdio(false);
	cin.tie(nullptr);
	cout.tie(nullptr);

	cin >> N >> M;

	int max = 0;

	for (int i = 0; i < N; i++) {
		cin >> trees[i];

		if (max <= trees[i])
			max = trees[i];
	}

	long long s = 1, e = max;
	long long resualt = 0;

	long long total = 0;
	while (s <= e) {
		long long m = (s + e) / 2;


		for (int i = 0; i <  N; i++) {
			if (m < trees[i])
				total += trees[i] - m;
		}
		
		if (total >= M) {
			resualt = m;
			s = m + 1;
		}
		else if (total < M) {
			e = m - 1;
		}
		total = 0;
	}

	cout << e;
}