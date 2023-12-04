#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

bool compare(pair<int, int> a, pair<int, int> b) {
    if (a.first == b.first) return a.second < b.second;
    return a.first < b.first;
}

int main()
{
    vector<pair<int, int>> cooldi;

    int N;

    cin >> N;

    for (int i = 0; i < N; i++)
    {
        int first, second;
        cin >> first >> second;

        pair<int, int> p = make_pair(first, second);
        cooldi.push_back(p);
    }

    sort(cooldi.begin(), cooldi.end(), compare);

    for (int i = 0; i < N; i++)
    {
        cout << cooldi[i].first << " " << cooldi[i].second << "\n";
    }
}