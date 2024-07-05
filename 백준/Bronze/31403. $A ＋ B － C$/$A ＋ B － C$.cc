#include <iostream>
#include <string>
using namespace std;

int main()
{
    int A, B, C;

    cin >> A >> B >> C;

    cout << A + B - C << "\n";

    string sAPlusB = to_string(A) + to_string(B);
    int APlusB = stoi(sAPlusB);

    cout << APlusB - C;
}