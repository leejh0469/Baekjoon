#include <iostream>
#include <string>

using namespace std;

#define SIZE 10000


int main()
{
    int N;
    cin >> N;
    cin >> ws;

    int deque[SIZE]{ 0 };
    int head = 0;
    int tail = 0;

    for (int i = 0; i < N; i++)
    {
        string order;

        getline(cin, order);

        if (order == "pop_front")
        {
            if (head == tail) cout << "-1" << "\n";
            else{
                cout << deque[head] << "\n";
                head = (SIZE + (head + 1)) % SIZE;
            }
        }
        else if (order == "pop_back")
        {
            if (head == tail) cout << "-1" << "\n";
            else {
                tail = (SIZE + (tail - 1)) % SIZE;
                cout << deque[tail] << "\n";
            }
        }
        else if (order == "size") {
            if (head > tail) cout << SIZE - (head - tail) << "\n";
            else cout << tail - head << "\n";
        }
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
                cout << deque[head] << "\n";
            }
        }
        else if (order == "back") {
            if (head == tail)
            {
                cout << "-1" << "\n";
            }
            else
            {
                cout << deque[(SIZE + (tail - 1)) % SIZE] << "\n";
            }
        }
        else {
            int val = 0, time = 1;

            if (order[5] == 'f') {

                for (int i = order.length() - 1; i >= 11; i--)
                {
                    val += (order[i] - '0') * time;
                    time *= 10;
                }

                head = (SIZE + (head - 1)) % SIZE;
                deque[head] = val;
            }
            else {

                for (int i = order.length() - 1; i >= 10; i--)
                {
                    val += (order[i] - '0') * time;
                    time *= 10;
                }

                deque[tail] = val;
                tail = (SIZE + (tail + 1)) % SIZE;
            }
        }
    }

}