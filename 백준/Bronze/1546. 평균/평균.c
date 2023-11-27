#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
int main(void)
{
	int n;
	scanf("%d",&n);
	int i,j,score[1000];
	int max=0;
	float sum=0;
	
	for(i=0;i<n;i++)
	{
		scanf("%d", &score[i]);
		if(max<score[i])
			max=score[i];
	}
	
	for(j=0;j<n;j++)
		sum += ((float)score[j]/max)*100;
	
	printf("%.2f", sum/n);
	
	return 0;
}