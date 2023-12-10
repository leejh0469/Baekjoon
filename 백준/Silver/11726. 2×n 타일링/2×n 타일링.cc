#include <iostream>
using namespace std;


int main()
{
    int n;
    cin >> n;

	int ary[1001]{ 0 };
	ary[0] = 1;
	ary[1] = 1;


	for (int i = 2; i <= n; i++)
	{
		ary[i] = (ary[i - 2] + ary[i - 1]) % 10007;
	}

	cout << ary[n];
}
