#include <iostream>
#include <cmath>
using namespace std;

int main()
{
	while (true)
	{
		int a, b, c;

		cin >> a >> b >> c;

		if (a == 0 && b == 0 && c == 0) break;

		int tmp = a;

		if (a < b) {
			tmp = b;
			if (tmp < c) {
				tmp = c;
				c = a;
			}
			else {
				b = a;
			}
		}

		if (pow(tmp, 2) != pow(b, 2) + pow(c, 2)) cout << "wrong" << "\n";
		else cout << "right" << "\n";
	}
}