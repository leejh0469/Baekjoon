#include <iostream>
#include <string>

using namespace std;


int main()
{
    int N;
    cin >> N;
    cin >> ws;

    int stack[10001]{0};
    int ptr = 0;

    for (int i = 0; i < N; i++)
    {
        string order;

        getline(cin, order);

        if (order == "pop")
        {
            if (ptr == 0) cout << "-1" << "\n";
            else cout << stack[--ptr] << "\n";
        }
        else if (order == "size") cout << ptr << "\n";
        else if (order == "empty")
        {
            if (ptr == 0) cout << "1" << "\n";
            else cout << "0" << "\n";
        }
        else if (order == "top") {
            if (ptr > 0)
            {
                cout << stack[ptr - 1] << "\n";
            }
            else 
            {
                cout << "-1" << "\n";
            }
        }
        else {
            int val = 0, time = 1;

            for (int i = order.length() - 1; i >=  5; i--)
            {
                val += (order[i] - '0') * time;
                time *= 10;
            }

            stack[ptr++] = val;
        }
    }
    
}