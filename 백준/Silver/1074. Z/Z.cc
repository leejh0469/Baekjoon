#include <iostream>
#include <cmath>
using namespace std;

int k = 0;
int r, c;
int sum = 0;
void f(int n, int x, int y, int r, int c) {
    if (n == 1) {
        sum += (r - x) * 2 + (c - y) % 2;
        return;
    }

    if (r < (x + pow(2, n - 1))) {
        if (c < (y + pow(2, n - 1))) {
            f(n - 1, x, y, r, c);
        }
        else {
            sum += pow(2, (n-1)*2);
            f(n - 1, x, y + pow(2, n - 1), r, c);
        }
    }
    if (r >= (x + pow(2, n - 1))) {
        if (c < (y + pow(2, n - 1))) {
            sum += pow(2, (n - 1) * 2) * 2;
            f(n - 1, x + pow(2, n-1), y, r, c);
        }
        else {
            sum += pow(2, (n - 1)*2) * 3;
            f(n - 1, x + pow(2, n-1), y + pow(2, n - 1), r, c);
        }
    }
}
int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int n;

    cin >> n >> r >> c;

    f(n, 0, 0, r, c);

    cout << sum;
}