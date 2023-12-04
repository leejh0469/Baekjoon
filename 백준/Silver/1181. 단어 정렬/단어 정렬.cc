#include <iostream>
#include <algorithm>

using namespace std;

bool compare(string a, string b){
    if (a.length() == b.length()) {
        for (int i = 0; i < a.length(); i++)
        {
            if (a[i] != b[i]) return a[i] < b[i];
        }
        return a < b;
    }
    else {
        return a.length() < b.length();
    }
}

int main()
{
    int N;
    
    cin >> N;

    string* words = new string[N];

    for (int i = 0; i < N; i++)
    {
        cin >> words[i];
    }

    sort(words, words + N, compare);

    for (int i = 0; i < N; i++)
    {
        if (i != 0 && words[i - 1] == words[i]) continue;
        cout << words[i] << "\n";
    }
}