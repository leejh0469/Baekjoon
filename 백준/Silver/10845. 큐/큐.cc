#include <iostream>
#include <string>

using namespace std;


int main()
{
    int N;
    cin >> N;
    cin >> ws;

    int queue[10001]{ 0 };
    int head = 0;
    int tail = 0;

    for (int i = 0; i < N; i++)
    {
        string order;

        getline(cin, order);

        if (order == "pop")
        {
            if (head == tail) cout << "-1" << "\n";
            else cout << queue[head++] << "\n";
        }
        else if (order == "size") cout << tail - head << "\n";
        else if (order == "empty")
        {
            if (head == tail) cout << "1" << "\n";
            else cout << "0" << "\n";
        }
        else if (order == "front") {
            if (head == tail)
            {
                cout << "-1" << "\n";
            }
            else
            {
                cout << queue[head] << "\n";
            }
        }
        else if (order == "back") {
            if (head == tail)
            {
                cout << "-1" << "\n";
            }
            else
            {
                cout << queue[tail-1] << "\n";
            }
        }
        else {
            int val = 0, time = 1;

            for (int i = order.length() - 1; i >= 5; i--)
            {
                val += (order[i] - '0') * time;
                time *= 10;
            }

            queue[tail++] = val;
        }
    }

}