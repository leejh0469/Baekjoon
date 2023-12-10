#include <iostream>
using namespace std;
int f(int x) {
	if (x == 3) return 4;
	else if (x == 2) return 2;
	else if (x == 1) return 1;

	int sum = f(x - 1) + f(x - 2) + f(x - 3);
	return sum;
}

int main()
{
    int n;
    cin >> n;

	for (int i = 0; i < n; i++)
	{
		int x;
		cin >> x;

		cout << f(x) << "\n";
	}
}