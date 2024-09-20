#include <iostream>

using namespace std;

int K, N;
unsigned int lines[10001];

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    cin >> K >> N;

    unsigned int max = 0;

    for (int i = 0; i < K; i++) {
        cin >> lines[i];

        if (lines[i] > max)
            max = lines[i];
    }

    long long s = 1;
    long long e = max;
    long long m, sum = 0;

    while (s <= e) {
        m = (s + e) / 2;

        for (int i = 0; i < K; i++) {
            sum += lines[i] / m;
        }

        if (sum >= N) {
            s = m + 1;
        }
        else {
            e = m - 1;
        }

        sum = 0;
    }

    cout << e;
}