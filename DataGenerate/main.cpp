#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <stdio.h>
#include <sstream>
#include <map>
#include <random>
#include <time.h>
#include <set>
using namespace std;
const string& getRand(const vector<string> & a){
    return a[rand()%a.size()];
}
int main(int argc ,char **argv){
   // int cnt = atoi(argv[1]);
    srand(time(nullptr));
    ifstream Acainfo("academic.txt");
    map<string,string>ss;
    string s1,s2;
    while (Acainfo>>s1>>s2)
    {
        ss.insert(make_pair(s1,s2));
    }
    set<string>s;
    for(auto it:ss){
        s.insert(it.second);
    }
    map<string,int>ini;
    int cnt = 1;
    for(auto it:s){
        cout<<"call AddAcademy(\'"<<it<<"\');\n";
        ini[it] = cnt++;
    }
    for(auto it:ss){
        cout<<"call AddMajor("<<ini[it.second]<<",\'"<<it.first<<"\');\n";
    }

}