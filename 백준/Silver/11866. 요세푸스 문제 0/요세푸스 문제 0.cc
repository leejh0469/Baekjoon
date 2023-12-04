#include <iostream>
#include <queue>

using namespace std;

int main()
{
    int N, K;

    cin >> N >> K;
	queue<int> q, q2;
	for (int i = 0; i < N; i++)
	{
		q.push(i+1);
	}

	int i = 1;

	while (!q.empty()) {
		if (i % K == 0) {
			q2.push(q.front());
			q.pop();
		}
		else {
			int temp = q.front();
			q.pop();
			q.push(temp);
		}
		i++;
	}
	cout << "<";
	for (int i = 0; i < N - 1; i++)
	{
		cout << q2.front() << ", ";
		q2.pop();
	}
	cout << q2.front() << ">";
}
