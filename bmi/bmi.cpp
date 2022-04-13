// bmi.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
using namespace std;

int main()
{
    double weight;  //w
    double height;  //h

    cout << "체중(kg) : ";
    cin >> weight;
    cout << "키(cm) : ";
    cin >> height;

    double bmi = weight / (height/100 * height/100);
    cout << "BMI = " << bmi << endl;
}
