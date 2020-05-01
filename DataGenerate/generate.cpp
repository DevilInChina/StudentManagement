#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <stdio.h>
#include <sstream>
#include <map>
#include <random>
#include <time.h>
using namespace std;
const string& getRand(const vector<string> & a){
    return a[rand()%a.size()];
}
int main(int argc ,char **argv){
    int cnt = atoi(argv[1]);
    srand(time(nullptr));
    ofstream fin("data.csv");
    
    ifstream Olname("lastname.txt");
    ifstream Ofname("firstname.txt");
    ifstream Onational("national.txt");
    ifstream Obirth("birthplace.txt");
    ifstream Obirthday("birthday.txt");
    ifstream Acainfo("academic.txt");
    vector<string> last_name;
    vector<string> first_name;
    vector<string>national;
    vector<string>birthplace;
    vector<string>birthday;
    vector<string>Aca;
    string str;
    while (Olname>>str)
    {
        last_name.push_back(str);
    }
    while (Ofname>>str)
    {
        first_name.push_back(str);
    }
    while (Onational>>str)
    {
        national.push_back(str);
    }
    while (Obirth>>str)
    {
        birthplace.push_back(str);
    }
    while (Obirthday>>str)
    {
        birthday.push_back(str);
    }
    string s;
    while (Acainfo>>str>>s)
    {
        Aca.push_back(str);
    }
    for(int i = 0 ; i < cnt ; ++i){
        fin<<last_name[rand()%last_name.size()]+first_name[rand()%first_name.size()];
        int l = rand()%5;
        if(l){
            fin<<first_name[rand()%first_name.size()];
        }
        fin<<','<<getRand(national);
        string k = getRand(birthday);
        int num = atoi(k.c_str());
        int dd = num%100;
        num/=100;
        int mm = num%100;
        num/=100;
        int yy = num;
        int G = rand()%4-2;
        yy+=G;
        if(mm==2 && dd==29) --dd;
        fin<<','<<yy;
        fin.fill('0');
        fin.width(2);
        fin<<mm;
        fin.fill('0');
        fin.width(2);
        fin<<dd;

        fin<<','<<G+2018;
        fin<<','<<getRand(birthplace);
        fin<<','<<getRand(Aca)<<'\n';
        
    }
}