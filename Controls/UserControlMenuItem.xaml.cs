using System;
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
using StudentManagement.Controls;
namespace StudentManagement
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>

    public partial class UserControlMenuItem : UserControl
    {
        MainWindow _context;
        public UserControlMenuItem(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(_context.CurListView != (ListView)sender&& _context.CurListView!=null)
            {
                //MessageBox.Show("Clear");
                _context.CurListView.SelectedItems.Clear();
                //MessageBox.Show(((SubItem)(_context.CurListView).SelectedItem).Name);
                _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
            }
            else
            {
                if ((SubItem)((ListView)sender).SelectedItem != null)
                {
                    _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
                }
            }
            _context.CurListView = (ListView)sender;
        }
    }
}
