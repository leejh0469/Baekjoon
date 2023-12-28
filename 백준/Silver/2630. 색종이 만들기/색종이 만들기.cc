#include <iostream>
using namespace std;

int xDir[4] = { 0, 1, 0, 1 };
int yDir[4] = { 0, 0, 1, 1 };

bool check(int** paper, int x, int y, int N, int WB) {
    for (int i = x; i < x + N; i++)
    {
        for (int j = y; j < y + N; j++)
        {
            if (paper[i][j] != WB) return false;
        }
    }
    return true;
}

void cut(int** paper, int x, int y, int N, int* w, int* b) {
    if (N < 1) return;
    
    if (check(paper, x, y , N , 0)) {
        *w += 1;
    }
    else if (check(paper, x, y, N , 1)) {
        *b += 1;
    }
    else {
        for (int i = 0; i < 4; i++)
        {
            cut(paper, x + ((N / 2) * xDir[i]), y + ((N / 2) * yDir[i]), N / 2, w, b);
        }
    }
    
}

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);

    int n;

    cin >> n;
    int** paper = new int* [n];
    for (int i = 0; i < n; i++)
    {
        paper[i] = new int[n];
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            cin >> paper[i][j];
        }
    }

    int white = 0;
    int blue = 0;
    int* w = &white;
    int* b = &blue;

    cut(paper, 0, 0, n, w, b);

    cout << *w << "\n";
    cout << *b << "\n";
}