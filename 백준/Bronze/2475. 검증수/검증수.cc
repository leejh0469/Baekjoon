#include <iostream>
using namespace std;
int main(){
    int sum = 0;
    for(int i = 0; i < 5; i++){
        int x;
        cin >> x;
        sum += (x*x);
    }
    cout << sum%10;
}