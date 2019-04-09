#include<iostream>
#include <string>
#include <sstream>
#include <cstdlib>
#include <ctime>
#include <algorithm>

using namespace std;

string twodigit(int);
string genLotteryNum(int, int);
bool exist(int[], int, int);

int main()
{
	ios_base::sync_with_stdio(false);
	cin.tie(0);

	srand(time(0));

	int type = 0, times = 0;
	cin >> type >> times;
	cout << genLotteryNum(type, times);

	system("pause");
}

//��J���O
string genLotteryNum(int type, int times)
{
	int number1, count, number2, biggestNum;
	bool flag;
	int lotteryNum[6] = {0};
	string result;

	//�P�q�j�ֳz�٬O�¤O�m
	if (type == 0)
	{
		biggestNum = 49;
		stringstream ss;
		ss << times;
		result = "�j�ֳz" + ss.str() + "�ո��X:\r\n";
	}
	else
	{
		biggestNum = 38;
		stringstream ss;
		ss << times;
		result = "�¤O�m" + ss.str() + "�ո��X:\r\n";
		result += "              �Ĥ@��           �ĤG��\r\n";
	}


	//���ͼƦr
	for (int i = 0; i < times; i++)
	{
		int count = 0;

		for (int j = 0; j < 6; j++) lotteryNum[j] = 0;

		do
		{
			number1 = rand() % biggestNum + 1;
			flag = exist(lotteryNum, count, number1);
			if (flag==false)
			{
				lotteryNum[count] = number1;
				count++;
			}

		} while (count<6);

		//�ƦC�Ʀr
		sort(lotteryNum, lotteryNum + 6);
		//�Ʀr�x�s�ۦr��
		for (int k = 0; k < 6; k++)	result += twodigit(lotteryNum[k]) + "    ";
		
		if (type == 0) result += "\r\n";
		else
		{
			number2 = rand() % 8 + 1;
			stringstream ss;
			ss << number2;
			result += "      " + ss.str() + "\r\n";
		}
	}
	return result;
}

//�X��
bool exist(int numArrary[], int count, int number)
{
	bool status = false;
	for (int i = 0; i < count; i++)
	{
		if (numArrary[i] == number)
		{
			status = true;
			break;
		}
	}
	return status;
}

//��r��
string twodigit(int number)
{
	int digit2 = number / 10;
	int digit1 = number % 10;

	stringstream ss;
	ss << digit2 << digit1;

	return ss.str();
}