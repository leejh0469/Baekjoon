#include <iostream>
#include <queue>
using namespace std;

int main()
{
	int N, M;
	queue<pair<int, int>> q;

	cin >> M >> N;

	int** tomato = new int* [N];

	for (int i = 0; i < N; i++)
	{
		tomato[i] = new int[M];
	}

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < M; j++)
		{
			cin >> tomato[i][j];
			if (tomato[i][j] == 1)
				q.push(pair<int, int>(i, j));
		}
	}

	int** distance = new int* [N];
	for (int i = 0; i < N; i++)
	{
		distance[i] = new int[M] {0};
	}

	int xDirc[4] = { 1, 0, -1, 0 };
	int yDirc[4] = { 0, 1, 0, -1 };

	int x, y;

	while (!q.empty())
	{
		pair<int, int> coordinate = q.front();
		q.pop();

		x = coordinate.first;
		y = coordinate.second;

		for (int i = 0; i < 4; i++)
		{
			int neighborX = x + xDirc[i];
			int neighborY = y + yDirc[i];

			if ((neighborX >= 0 && neighborX < N) && (neighborY >= 0 && neighborY < M)) {
					if (tomato[neighborX][neighborY] == 0) {
						q.push(pair<int, int>(neighborX, neighborY));
						tomato[neighborX][neighborY] = 1;
						distance[neighborX][neighborY] = distance[x][y] + 1;
					}
			}
		}
	}

	bool isAllChange = true;

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < M; j++)
		{
			if (tomato[i][j] == 0) {
				isAllChange = false;
				i = N;
				break;
			}
		}
	}

	if (isAllChange)
		cout << distance[x][y];
	else
		cout << "-1";
}