#include <iostream>

using namespace std;

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int n, m, i, j;

    cin >> n >> m;
    int* ary = new int[n];
    int* s = new int[n + 1] {0};

    for (int i = 0; i < n; i++)
    {
        cin >> ary[i];
    }

    for (int i = 1; i < n + 1; i++)
    {
        s[i] = s[i - 1] + ary[i - 1];
    }

    for (int k = 0; k < m; k++)
    {
        cin >> i >> j;
        cout << s[j] - s[i - 1] << "\n";
    }
}
