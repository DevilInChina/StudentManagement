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
using StudentManagement.MainPageDesign;
namespace StudentManagement.MainPageDesign.CourseChoosenPage
{
    /// <summary>
    /// CurrentYearPage.xaml 的交互逻辑
    /// </summary>
    public partial class CurrentYearPage : UserControl,ThirdPage
    {
        public CurrentYearPage()
        {
            InitializeComponent();
            MessageBox.Show("Cur");
        }

        public void ReClick()
        {
            throw new NotImplementedException();
        }

        public void ReClick(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }
    }
}
