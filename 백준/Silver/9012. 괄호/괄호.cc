#include <iostream>
using namespace std;

int main()
{
	int n;

	cin >> n;

	for (int i = 0; i < n; i++)
	{
		string VPS;
		int stack = 0;

		cin >> VPS;

		for (int j = 0; j < VPS.length(); j++)
		{
			if (VPS[j] == '(') stack++;
			else if (VPS[j] == ')' && stack > 0) stack--;
			else
			{
				stack = 100;
				break;
			}
		}

		if (stack == 0) cout << "YES" << endl;
		else cout << "NO" << endl;
	}
}