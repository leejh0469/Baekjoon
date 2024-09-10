#include <iostream>

using namespace std;

int f(int a, int b) {
    if (a == 0)
        return b;

    if (b == 0)
        return 0;

    return f(a - 1, b) + f(a, b - 1);
}

int main()
{
    int testNum;

    cin >> testNum;

    for (int i = 0; i < testNum; i++) {
        int k, n;
        cin >> k >> n;

        cout << f(k, n) << endl;
    }
}