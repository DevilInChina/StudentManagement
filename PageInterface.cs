﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentManagement.MainPageDesign.SystemManagementPage;
namespace StudentManagement
{
    interface SecondPage
    {
        void init(MainWindow curWindow);
    }
    interface ThirdPage
    {
        void ReClick(MainWindow curWindow);
        void ReClick();
    }
}
