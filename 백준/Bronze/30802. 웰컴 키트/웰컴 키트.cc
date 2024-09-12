#include <iostream>
using namespace std;

int main()
{
	int n;

	cin >> n;

	int* size = new int[6];

	for (int i = 0; i < 6; i++) {
		cin >> size[i];
	}

	int T, P;

	cin >> T >> P;

	int tShirtN = 0;

	for (int i = 0; i < 6; i++) {
		tShirtN += size[i] / T;
		if (size[i] % T != 0)
			tShirtN++;
	}

	cout << tShirtN << endl;

	int pN;

	int count = 0;

	for (int i = 0; i < 6; i++) {
		count += size[i];
	}

	cout << count / P << " " << count % P << endl;

}
