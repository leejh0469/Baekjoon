#include <iostream>
#include <queue>

using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);

    int N, K;

    cin >> N >> K;

    bool isVisit[1000001] = { false };
    int dist[1000001]{ 0 };
    queue<int> q;
    q.push(N);
    
    isVisit[N] = true;

    while (!q.empty())
    {
        int pos = q.front();
        q.pop();

        if (pos == K) break;

        for (int i = 0; i < 3; i++)
        {
            if (pos + 1 <= 100000 && !isVisit[pos + 1]) {
                q.push(pos + 1);
                dist[pos + 1] = dist[pos] + 1;
                isVisit[pos + 1] = true;
            }
            if (pos - 1 >= 0 && !isVisit[pos - 1]) {
                q.push(pos - 1);
                dist[pos - 1] = dist[pos] + 1;
                isVisit[pos - 1] = true;
            }
            if (pos * 2 <= 100000 && !isVisit[pos * 2]) {
                q.push(pos * 2);
                dist[pos * 2] = dist[pos] + 1;
                isVisit[pos * 2] = true;
            }
        }
    }

    cout << dist[K];
}
