#include <iostream>
#include <queue>
using namespace std;

int main()
{
	int N, M;

	cin >> N >> M;

	string* maze = new string[N];

	for (int i = 0; i < N; i++)
	{
		cin >> maze[i];
	}

	queue<int> q;

	bool** isVisit = new bool* [N];
	for (int i = 0; i < N; i++)
	{
		isVisit[i] = new bool[M] {false};
	}

	int** distance = new int* [N];
	for (int i = 0; i < N; i++)
	{
		distance[i] = new int[M] {1};
	}


	q.push(0);
	int goal = N * M - 1;

	int xDirc[4] = { 1, 0, -1, 0 };
	int yDirc[4] = { 0, 1, 0, -1 };

	while (true)
	{
		int n = q.front();
		q.pop();

		if (n == goal) break;

		int x = n / M;
		int y = n % M;

		for (int i = 0; i < 4; i++)
		{
			int neighborX = x + xDirc[i];
			int neighborY = y + yDirc[i];

			if ((neighborX >= 0 && neighborX < N) && (neighborY >= 0 && neighborY < M)) {
				if (!isVisit[neighborX][neighborY])
					if (maze[neighborX][neighborY] == '1')
					{
						q.push(M * neighborX + neighborY);
						isVisit[neighborX][neighborY] = true;
						distance[neighborX][neighborY] = distance[x][y] + 1;
					}
			}
		}
	}

	cout << distance[N - 1][M - 1];
}
