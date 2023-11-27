#include<stdio.h>

int main(){
	int n=0;
	int cnt=0;
	scanf("%d", &n);
	
	cnt = n/5;
	if(n%5 != 0){
		for(; cnt>=0; cnt--){
			if((n-5*cnt)%3 == 0){
				cnt += (n-5*cnt)/3;
				break;
			}
		}
	}
	printf("%d", cnt);
	return 0;
}