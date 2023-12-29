#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

bool compare(pair<int, int> p1, pair<int, int> p2) {
	if (p1.second == p2.second) {
		return p1.first < p2.first;
	}
	else
		return p1.second < p2.second;
}

int main()
{
    int n;
    cin >> n;

	vector<pair<int, int>> v;
	for (int i = 0; i < n; i++)
	{
		int x;
		cin >> x;
		v.push_back(make_pair(i, x));
	}

	sort(v.begin(), v.end(), compare);

	int previousValue = v[0].second;
	int coordi = 0;
	v[0].second = coordi;

	for (int i = 1; i < n; i++)
	{
		if (v[i].second == previousValue) {
			v[i].second = coordi;
		}
		else {
			previousValue = v[i].second;
			v[i].second = ++coordi;
		}
	}
	sort(v.begin(), v.end());
	for (int i = 0; i < n; i++)
	{
		cout << v[i].second << " ";
	}
}