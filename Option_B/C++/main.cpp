
#include <iostream>
using namespace std;


int CruelifeSelection(int n) {
	int* temp1 = new int[n];
	int size = n;

	for (int i = 0, j = 1; i < n; i++, j++) temp1[i] = j;

	while (size > 1) {
		for (int i = 0, j = 0; j < size; i++, j += 2) {
			temp1[i] = move(temp1[j]);
		}
		size = ((size + 1) >> 1);

        if (size < 2) break;
		for (int i = 0, j = 1; j < size; i++, j += 2) {
			temp1[i] = move(temp1[j]);
		}
		size >>= 1;

        if (size < 3) continue;
		for (int i = 0, j = 0, k = 1; j < size; i++, j += 3, k = j + 1) {
			temp1[i] = move(temp1[j]);
            if (k < size) temp1[++i] = move(temp1[k]);
		}
		size -= (size / 3);	
	}

	size = move(temp1[0]);
	delete[] temp1;
	return size;
}


int main() {
    ios_base::sync_with_stdio(0);
    cin.tie(0);
    cout.tie(0);

	int n;
	cin >> n;
	cout << CruelifeSelection(n);
	return 0;
}