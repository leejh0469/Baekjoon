#include <iostream>
#include <queue>
#include <vector>
using namespace std;

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);

    int testCaseNum;

    cin >> testCaseNum;

    for (int i = 0; i < testCaseNum; i++)
    {
        int n, m, beachuNum;

        cin >> n >> m >> beachuNum;
        vector<pair<int, int>> vec;

        bool** isVisit = new bool* [n];
        int** field = new int* [n];
        for (int j = 0; j < n; j++)
        {
            isVisit[j] = new bool[m] {false};
            field[j] = new int[m] {0};
        }
        for (int j = 0; j < beachuNum; j++)
        {
            int x, y;

            cin >> x >> y;
            field[x][y] = 1;
            pair<int, int> p = make_pair(x, y);
            vec.push_back(p);
        }

        int count = 0;

        int xDir[4] = { 1, 0, -1, 0 };
        int yDir[4] = { 0, -1, 0, 1 };

        for (int j = 0; j < beachuNum; j++)
        {
            pair<int, int> p = vec.back();
            vec.pop_back();

            if (!isVisit[p.first][p.second]) {
                queue<pair<int, int>> q;
                q.push(p);
                count++;

                while (!q.empty())
                {
                    pair<int, int> p2 = q.front();
                    q.pop();

                    for (int k = 0; k < 4; k++)
                    {
                        int x = p2.first + xDir[k];
                        int y = p2.second + yDir[k];

                        if (x >= 0 && x < n && y >= 0 && y < m) {
                            if (!isVisit[x][y] && field[x][y] == 1) {
                                pair<int, int> temp = make_pair(x, y);
                                q.push(temp);
                                isVisit[x][y] = true;
                            }
                        }
                    }
                }
            }
        }

        cout << count << "\n";
    }
}