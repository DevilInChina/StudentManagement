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

namespace StudentManagement.Controls
{
    /// <summary>
    /// CourseTable.xaml 的交互逻辑
    /// </summary>
    public partial class CourseTable : UserControl
    {
        public int Row { get; }
        public int Column { get; }
        protected DockPanel[,] dockPanels;
        public Label[] head_labels;
        public Label[] side_labels;
        String[] header =
        {
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六",
            "星期日"
        };
        String[] sider =
        {
            "08:00-09:45",
            "10:05-11:50",
            "13:30-15:15",
            "15:30-17:15",
            "18:30-20:15",
            "20:30-22:15"
        };
        public CourseTable()
        {
            InitializeComponent();
            Row = 6;
            Column = 7;
            DockPanel[] dockPanels1 = new DockPanel[Row];
            dockPanels = new DockPanel[Row, Column];
            outer.Width = 805;
            outer.Height = 600;
            head_labels = new Label[Column];
            side_labels = new Label[Row];
            for(int i = 0; i <Column; ++i)
            {
                head_labels[i] = new Label();
                head_labels[i].Content = header[i];
                head_labels[i].Width = outer.Width / Column;
                
                headPanel.Children.Add(head_labels[i]);
            }
            for (int i = 0; i < Row; ++i)
            {
                side_labels[i] = new Label();
                side_labels[i].Content = sider[i];
                side_labels[i].Height = outer.Height / Row;

                DockPanel.SetDock(side_labels[i], Dock.Top);
                sidePanel.Children.Add(side_labels[i]);
            }
            for (int i = 0; i < Row; ++i)
            {   
                dockPanels1[i] = new DockPanel();
                outer.Children.Add(dockPanels1[i]);
                DockPanel.SetDock(dockPanels1[i], Dock.Top);
                dockPanels1[i].Visibility = Visibility.Visible;
                for (int j = 0; j < Column; ++j)
                {
                    dockPanels[i, j] = new DockPanel();
                    dockPanels[i, j].Width = outer.Width / Column;
                    dockPanels[i, j].Height = outer.Height / Row;
                    dockPanels1[i].Children.Add(dockPanels[i, j]);
                    Button s = new Button();
                    s.Width = outer.Width / Column;
                    s.Height = outer.Height / Row;
                    s.Content = i.ToString() + " " + j.ToString();
                    dockPanels[i, j].Children.Add(s);
                    DockPanel.SetDock(dockPanels[i, j], Dock.Left);
                    dockPanels[i, j].Visibility = Visibility.Visible;
                }
            }
        }
        protected void setHeader(String S)
        {
            header_label.Content = S;
        }
    }
    public partial class CourseTableSelect : CourseTable
    {
        public Button[,] btn;
        public int[,] pres;
        private long ret;
        DependencyProperty Dp;
        Brush brush_defau;
        Brush brush_chose;
        public CourseTableSelect() : base()
        {
            btn = new Button[Row, Column];
            pres = new int[Row, Column];
            BrushConverter brushConverter = new BrushConverter();
            brush_defau = (Brush)brushConverter.ConvertFromString("#FF2196F3");
            brush_chose = (Brush)brushConverter.ConvertFromString("#FF32CD32");
            ret = 0;

        }
        public void init(DependencyProperty Dp,String info)
        {
            this.Dp = Dp;
            for (int i = 0; i < Row; ++i)
            {

                for (int j = 0; j < Column; ++j)
                {
                    btn[i, j] = (Button)(dockPanels[i, j].Children[0]);
                    btn[i,j].SetValue(Dp, i * Column + j);
                    pres[i, j] = 0;
                    btn[i, j].Click += button_Click;
                }
            }
            this.setHeader(info);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int pos = (int)button.GetValue(Dp);
            int i = pos / Column;
            int j = pos % Column;
            if ((pres[i,j] & 1) == 0)
            {
                ++pres[i, j];
                button.Background = brush_chose;
            }
            else
            {
                --pres[i, j];

                button.Background = brush_defau;
            }
            ret ^= (1L << pos);
        }
        public long GetSelectInfo()
        {
            return ret;
        }

    }

}
