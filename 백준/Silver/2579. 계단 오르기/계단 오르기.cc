#include <iostream>

using namespace std;

int n, stair[301];
int dp[301];

int main()
{
	cin >> n;

	for (int i = 0; i < n; i++) {
		cin >> stair[i];
	}

	//case 1
	//마지막 계단 전 계단을 밟을 경우
	//dp[n] = dp[n - 1] + dp[n - 3] + stair[n];
	//case 2
	//마지막 계단 전전 계단을 밟을 경우
	//dp[n] = dp[n - 2] + stair[n];

	dp[0] = stair[0];
	dp[1] = max(stair[0] + stair[1], stair[1]);
	dp[2] = max(stair[0] + stair[2], stair[1] + stair[2]);

	for (int i = 3; i < n; i++) {
		dp[i] = max(stair[i - 1] + dp[i - 3] + stair[i], dp[i - 2] + stair[i]);
	}

	cout << dp[n - 1];
}