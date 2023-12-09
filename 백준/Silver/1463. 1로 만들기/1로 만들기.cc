#include <iostream>
using namespace std;

int ary[1000000]{ 0 };

int min(int a, int b) {
    return (a < b)? a : b;
}

void dp(int n) {
    ary[1] = 1;
    ary[2] = 1;
    ary[3] = 1;

    for (int i = 4; i <= n; i++)
    {
        if (i % 6 == 0) {
            ary[i] = min(ary[i / 3], ary[i / 2]) + 1;
        }
        else if (i % 3 == 0) {
            ary[i] = min(ary[i / 3], ary[i - 1]) + 1;
        }
        else if (i % 2 == 0) {
            ary[i] = min(ary[i / 2], ary[i - 1]) + 1;
        }
        else {
            ary[i] = ary[i - 1] + 1;
        }
    }
}

int main()
{
    int x;

    cin >> x;

    int count = 0;

    dp(x);

    if(x == 1) cout << 0;
    else cout << ary[x];
}