#include <iostream>
#include <queue>

using namespace std;

int main()
{
    int N;

    cin >> N;

	queue<int> cards;

	for (size_t i = 0; i < N; i++)
	{
		cards.push(i);
	}
	

	int lastCard;
	int x = 0;

	while (!cards.empty()) {
		if (x == 0) {
			lastCard = cards.front();
			cards.pop();
			x = 1;
		}
		else {
			lastCard = cards.front();
			cards.pop();
			cards.push(lastCard);
			x = 0;
		}
	}

	cout << lastCard + 1;
}