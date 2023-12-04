#include <iostream>
using namespace std;

int GCD(int a, int b) {
    return b ? GCD(b, a % b) : a;
}

int main()
{
    int a, b;

    cin >> a >> b;

    int gcd = GCD(a, b);

    cout << gcd << "\n" << a * b / gcd;

}