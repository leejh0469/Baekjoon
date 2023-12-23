#include <iostream>
using namespace std;
int main()
{
	int ary[31]{ 0 };

	for (int i = 0; i < 30; i++)
	{
		int n;
		cin >> n;
		ary[n] = 1;
	}

	for (int i = 1; i < 31; i++)
	{
		if (ary[i] != 1) cout << i << "\n";
	}
}