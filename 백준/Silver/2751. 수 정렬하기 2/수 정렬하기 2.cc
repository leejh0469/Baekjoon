#include <iostream>
#include <vector>
using namespace std;

void Merge(vector<int>& ary, int start, int end, int mid) {
    vector<int> ret;
    int s = start, e = end, m = mid + 1, copy = 0;

    while (s <= mid && m <= end) {
        if (ary[s] < ary[m]) ret.push_back(ary[s++]);
        else if (ary[s] > ary[m]) ret.push_back(ary[m++]);
    }

    while (s <= mid) ret.push_back(ary[s++]);
    while (m <= end) ret.push_back(ary[m++]);

    for (int i = start; i <= end; i++)
    {
        ary[i] = ret[copy++];
    }
}

void MergeSort(vector<int>& ary, int start, int end) {
    if (start < end)
    {
        int mid = (start + end) / 2;

        MergeSort(ary, start, mid);
        MergeSort(ary, mid + 1, end);
        Merge(ary, start, end, mid);
    }
}

int main()
{
    int N;

    cin >> N;

    vector<int> ary;
    for (int i = 0; i < N; i++)
    {
        int n;
        cin >> n;
        ary.push_back(n);
    }

    MergeSort(ary, 0, N-1);

    for (int i = 0; i < N; i++)
    {
        cout << ary[i] << '\n';
    }
}