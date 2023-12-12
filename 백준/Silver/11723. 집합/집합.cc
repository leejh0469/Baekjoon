#include <iostream>
#include <string>
using namespace std;
int get(int e, string order) {
	int value = 0;
	int time = 1;
	for (int i = order.length() - 1; i >=e; i--)
	{
		value += (order[i] - '0')* time;
		time *= 10;
	}
	return value;
}
int main()
{
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);
	int ary[20]{ 0 };

	int n, x;

	cin >> n;
	cin.ignore();
	for (int i = 0; i < n; i++)
	{
		string order;
		getline(cin, order);

		char o = order[1];

		switch (o)
		{
		case 'd':
			x = get(4, order);
			ary[x - 1] = x;
			break;
		case 'e':
			x = get(7, order);
			ary[x - 1] = 0;
			break;
		case 'h':
			x = get(6, order);
			if (ary[x - 1] != 0) cout << 1 << "\n";
			else cout << 0 << "\n";
			break;
		case 'o':
			x = get(7, order);
			if (ary[x - 1] != 0) ary[x - 1] = 0;
			else ary[x - 1] = x;
			break;
		case 'l':
			for (int i = 0; i < 20; i++)
			{
				ary[i] = i + 1;
			}
			break;
		case 'm':
			for (int i = 0; i < 20; i++)
			{
				ary[i] = 0;
			}
			break;
		}
	}
}