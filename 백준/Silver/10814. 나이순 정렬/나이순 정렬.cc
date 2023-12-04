#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

bool compare(pair<int, string> a, pair<int, string> b) {
	return a.first < b.first;
}

int main()
{
    int N;

    cin >> N;

	vector<pair<int, string>> member;

	for (int i = 0; i < N; i++)
	{
		int age;
		string name;

		cin >> age >> name;

		pair<int, string> p = make_pair(age, name);

		member.push_back(p);
	}

	stable_sort(member.begin(), member.end(), compare);

	for (int i = 0; i < N; i++)
	{
		cout << member[i].first << " " << member[i].second << "\n";
	}
}