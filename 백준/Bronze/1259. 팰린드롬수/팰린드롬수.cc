#include <iostream>
using namespace std;

int main()
{
    while (true)
    {
        string Palindrome;
        cin >> Palindrome;

        if (Palindrome == "0") break;

        int start = 0, end = Palindrome.length() - 1;
        
        bool isPalindrome = true;

        while (start < end)
        {
            if (Palindrome[start++] != Palindrome[end--]) {
                isPalindrome = false;
                break;
            }
            
        }

        if (isPalindrome) cout << "yes" << "\n";
        else cout << "no" << "\n";
    }
}