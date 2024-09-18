#include <iostream>

using namespace std;

int n;
int main()
{
	cin >> n;

	for (int i = 0; i < n; i++) {
		int a, b;

		cin >> a >> b;

		cout << "Case #" << i +1 << ": " << a + b << "\n";
	}
}