#include <iostream>
#define MAX_SIZE 100000
using namespace std;

typedef struct heap {
	int ary[MAX_SIZE]{ 0 };
	int size;
}Heap;

void swap(int* a, int *b) {
	int temp = *a;
	*a = *b;
	*b = temp;
}

void InitHeap(Heap* h) {
	h->size = 0;
}

void insert(Heap* h, int value) {
	int head = ++h->size;

	while ((head != 1) && (value < h->ary[head/2]))
	{
		h->ary[head] = h->ary[head/2];
		head /= 2;
	}

	h->ary[head] = value;
}

int deleteData(Heap* h) {
	if (h->size == 0) return 0;
	int ret = h->ary[1];
	h->ary[1] = h->ary[h->size--];
	int parent = 1;
	int child;


	while (1) {
		child = parent * 2;
		if (child + 1 <= h->size && h->ary[child + 1] < h->ary[child])
			child++;
		
		if(child > h->size || (h->ary[parent] < h->ary[child]))
			break;

		swap(&h->ary[parent], &h->ary[child]);
		parent = child;
	}
	return ret;
}

int main()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);

    int n;

	Heap h;
	InitHeap(&h);

	cin >> n;

	for (int i = 0; i < n; i++)
	{
		int x;
		cin >> x;

		switch (x) {
		case 0:
			cout << deleteData(&h) << "\n";
			break;
		default:
			insert(&h, x);
			break;
		}
	}
}