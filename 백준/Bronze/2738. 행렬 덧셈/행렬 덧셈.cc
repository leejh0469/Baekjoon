#include <iostream>
using namespace std;
int main()
{
    int n, m;
    cin >> n >> m;

    int** ary1 = new int*[n];
    int** ary2 = new int* [n];

    for (int i = 0; i < n; i++)
    {
        ary1[i] = new int[m];
        ary2[i] = new int[m];
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cin >> ary1[i][j];
        }
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cin >> ary2[i][j];

            ary1[i][j] += ary2[i][j];
        }
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << ary1[i][j] << " ";
        }
        cout << "\n";
    }
}