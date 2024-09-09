#include<iostream>
#include<list>
using namespace std;

int main() {
    int N;

    int a = 0;

    cin >> N;

    int i = 666;

    list<int> intList;

    while (N > 0) {
        int temp = i;

        bool theEnd = false;

        while (temp > 0) {
            /*intList.push_back(temp % 10);
            temp /= 10;*/

            if (temp % 1000 == 666) {
                theEnd = true;
                a = i;
                N--;
                break;
            }

            temp /= 10;
        }
        i++;
    }

    cout << a;
}