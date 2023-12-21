#include <iostream>
#include <queue>
using namespace std;

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);

    int n, m;
    cin >> n >> m;

    bool** isVisit = new bool* [n];
    int** field = new int* [n];
    int** distance = new int* [n];

    for (int i = 0; i < n; i++)
    {
        isVisit[i] = new bool[m] {false};
        field[i] = new int[m] {0};
        distance[i] = new int[m] {0};
    }

    int x, y;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cin >> field[i][j];
            if (field[i][j] == 2) {
                x = i;
                y = j;
            }
        }
    }

    queue<pair<int, int>> q;
    pair<int, int> destiny = make_pair(x, y);
    q.push(destiny);
    isVisit[x][y] = true;

    int xDirc[4]{ 1, 0, -1, 0 };
    int yDirc[4]{ 0, -1, 0, 1 };

    while (!q.empty()) {
        pair<int, int> p = q.front();
        q.pop();

        for (int i = 0; i < 4; i++)
        {
            int x = p.first + xDirc[i];
            int y = p.second + yDirc[i];

            if (x >= 0 && x < n && y >= 0 && y < m) {
                if (!isVisit[x][y] && field[x][y] != 0) {
                    q.push(make_pair(x, y));
                    isVisit[x][y] = true;
                    distance[x][y] = distance[p.first][p.second] + 1;
                }
            }
        }
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (distance[i][j] > 0) {
                cout << distance[i][j];
            }
            else {
                if (i == destiny.first && j == destiny.second) cout << distance[i][j];
                else {
                    if (field[i][j] == 0) cout << distance[i][j];
                    else cout << "-1";
                }
            }
            cout << " ";
        }
        cout << "\n";
    }
}