#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <stdio.h>
#include <sstream>
#include <map>
using namespace std;
int main(int argc ,char **argv){
    ///原始数据分裂成小数据
    ifstream fin("data.csv");
    //fin.open();
    
    int cnt =0;
    vector<string>first_name;
    vector<string>second_name;
    vector<string>national;
    vector<string>birthday;
    vector<string>Birthplace;
    map<string,string>Belong;
    char buffer[256];
    char str[256];
    while (fin.getline(str,256))
    {
        string s(str);
        if(cnt++==0)continue;   
        stringstream sin;
        sin<<s;
        sin.getline(buffer,256,',');///num
        //cout<<buffer<<'\n';
        sin.getline(buffer,256,',');///ID
        //cout<<buffer<<'\n';
        sin.getline(buffer,256,',');///name
        string name(buffer);
        if(name.length()<=9){
            first_name.push_back( string(name.substr(0,3)));
            second_name.push_back( string(name.substr(3,3)));
            if(name.length()>=6){
                second_name.push_back( string(name.substr(6,3)));
            }
        }
        //cout<<buffer<<'\n';
        sin.getline(buffer,256,',');///gender
        //cout<<buffer<<'\n';
        
        sin.getline(buffer,256,',');///national
        national.emplace_back( string(buffer));
        //cout<<buffer<<'\n';
        sin.getline(buffer,256,',');///birthday
        birthday.emplace_back( string(buffer));
        sin.getline(buffer,256,',');///polit
        //cout<<buffer<<'\n';
        sin.getline(buffer,256,',');///Birthplace
        Birthplace.push_back( string(buffer));
        sin.getline(buffer,256,',');///acaid
        //cout<<buffer<<'\n';
        sin.getline(buffer,256,',');///aca
        string aca(buffer);
        sin.getline(buffer,256,',');///major
        Belong.insert(make_pair(string(buffer),aca));
        //cout<<buffer<<endl;
        sin>>buffer;//class
        
    }
    ofstream Ofname("lastname.txt");
    for(auto s:first_name)Ofname<<s<<'\n';
    ofstream Osname("firstname.txt");
    for(auto s:second_name)Osname<<s<<'\n';
    ofstream Onational("national.txt");
    for(auto s:national)Onational<<s<<'\n';
    ofstream Obirth("birthplace.txt");
    for(auto s:Birthplace)Obirth<<s<<'\n';
    ofstream Obirthday("birthday.txt");
    for(auto s:birthday)Obirthday<<s<<'\n';
    
    ofstream Acainfo("academic.txt");
    for(auto s:Belong){
        Acainfo<<s.first<<' '<<s.second<<'\n';
    }
    cout<<Belong.size();
}