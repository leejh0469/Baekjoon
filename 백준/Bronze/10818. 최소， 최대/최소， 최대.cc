#include <iostream>
#include <algorithm>

using namespace std;

int main()
{
    int N;

    cin >> N;

    int* ary = new int[N];

    for (int i = 0; i < N; i++)
    {
        int x;
        cin >> x;
        ary[i] = x;
    }

    sort(ary, ary + N);

    cout << ary[0] << " " << ary[N - 1];
}