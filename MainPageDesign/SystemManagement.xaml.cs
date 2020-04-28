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

namespace StudentManagement.MainPageDesign
{
    /// <summary>
    /// SystemManagement.xaml 的交互逻辑
    /// </summary>
    public partial class SystemManagement : UserControl
    {

        private UserControl[]BufferStore;
        private int curIndex = 0;
        public SystemManagement(MainWindow prev)
        {
            InitializeComponent();
            int size = 1;
            Menu1.Background = new SolidColorBrush(prev.MainThemeColor);
            BufferStore = new UserControl[size];
            for(int i = 0; i < size; ++i)
            {
                BufferStore[i] = null;
            }
            curIndex = -1;
        }
        

        private void SysJump(object sender, RoutedEventArgs e)
        {
            int Id = 0;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new DownloadFilePage();
               
            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }
    }
}
