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
using System.Data;
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

        public Brush brush_defau;
        public Brush brush_chose;
        public Brush brush_Cannot;
        public CourseTable()
        {
            InitializeComponent();

            BrushConverter brushConverter = new BrushConverter();
            brush_defau = (Brush)brushConverter.ConvertFromString("#FF2196F3");
            brush_chose = (Brush)brushConverter.ConvertFromString("#FF32CD32");
            brush_Cannot = (Brush)brushConverter.ConvertFromString("#FFB22222");
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
                    s.Content = "";
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
        public CourseTableSelect() : base()
        {
            btn = new Button[Row, Column];
            pres = new int[Row, Column];
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
                    Label s = new Label();
                    TextBlock S = new TextBlock();
                    S.TextWrapping = TextWrapping.WrapWithOverflow;
                    S.Text = "";
                    S.Width = btn[i, j].Width/2;
                    S.Height = btn[i, j].Height;
                    btn[i, j].Content = S;
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
            if (pres[i,j]  == 0)
            {
                ++pres[i, j];
                button.Background = brush_chose;
                ret ^= (1L << pos);
            }
            else if(pres[i, j]==1)
            {
                --pres[i, j];

                button.Background = brush_defau;

                ret ^= (1L << pos);
            }
            else
            {

            }
        }
        public long GetSelectInfo()
        {
            return ret;
        }

        public void PanelClear()
        {
            int tot = Column * Row;
            ret = 0;
            for (int i = 0; i < tot; ++i)
            {
                pres[i / Column, i % Column] = 0;
                btn[i / Column, i % Column].Background = brush_defau;
                ((TextBlock)(btn[i / Column, i % Column].Content)).Text = "";
            }
        }
        private void SetButton(int i,String info)
        {
            pres[i / Column, i % Column] = 2;
            btn[i / Column, i % Column].Background = brush_Cannot;
            ((TextBlock)btn[i / Column, i % Column].Content) .Text= info;
        }
        private int log2(long s)
        {
            int cnt = 0;
            while (s > 1)
            {
                s >>= 1;
                ++cnt;
            }
            return cnt;
        }
        public void PanelSetCannot(DataTable Course)
        {
            for(int i = 0; i < Course.Rows.Count; ++i)
            {
                long TimeD =(long) Course.Rows[i]["Class_Time"];
                String Info = Course.Rows[i]["teacher_name"].ToString() + ",\n" + Course.Rows[i]["course_name"] + ",\n" +
                    Course.Rows[i]["classroom_name"];

                while (TimeD != 0)
                {
                    long k = (-TimeD) & (TimeD);
                    SetButton(log2(k), Info);
                    TimeD -= k;
                }
            }
        }
        public void RefreshButtionInfo(DataTable courseInfo)
        {
            
            PanelClear();
            PanelSetCannot(courseInfo);
        }
    }

}
