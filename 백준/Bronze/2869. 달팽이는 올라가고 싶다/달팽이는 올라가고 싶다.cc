#include <iostream>
using namespace std;

int main()
{
	long A, B, V;

	cin >> A >> B >> V;

	int count = (V - A) / (A - B);

	if ((V - A) % (A - B) > 0) cout << count + 2;
	else cout << count + 1;
}
