#include <iostream>
#include <map>
#include <string>
using namespace std;


int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);

    int n, m;

    cin >> n >> m;

    map<string, string> poketDogam;
    map<string, string> poketDogam1;

    for (int i = 0; i < n; i++)
    {
        string name;

        cin >> name;

        poketDogam.insert({ to_string(i+1), name});
        poketDogam1.insert({ name, to_string(i + 1) });
    }

    for (int i = 0; i < m; i++)
    {
        string s;
        cin >> s;

        auto item = poketDogam.find(s);
        if (item != poketDogam.end() )
        {
            cout << item->second << "\n";
        }
        else {
            item = poketDogam1.find(s);
            cout << item->second << "\n";
        }
    }
}
