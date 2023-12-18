#include <iostream>
using namespace std;

int main()
{
    int n;
    cin >> n;

    int* ary = new int[n];

    for (int i = 0; i < n; i++)
    {
        cin >> ary[i];
    }
    int x;
    int count = 0;
    cin >> x;

    for (int i = 0; i < n; i++)
    {
        if (ary[i] == x) count++;
    }
    cout << count;
}