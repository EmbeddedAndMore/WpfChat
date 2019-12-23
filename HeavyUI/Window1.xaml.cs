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
using System.Windows.Shapes;


namespace HeavyUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if (A.Length == 1)
                return A[0];
            int[] founded = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                var res = findValue(founded, A[i]);
                if (res == -1)
                {
                    founded[i] = A[i];
                }
                else
                {
                    founded[res] = -1;
                }
            }
            for (int i = 0; i < founded.Length; i++)
            {
                if (founded[i] != -1)
                    return founded[i];
            }
            return 0;
        }

        private int findValue(int[] values, int value)
        {
            for(int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                    return i;
            }
            return -1;
        }

            private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Delay(2000).ContinueWith(x =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    for (int i = 0; i < 50; i++)
                    {
                        TreeViewItem item = new TreeViewItem();

                        item.Header = $"This is the text for test this treeview {i}";
                        tree.Items.Add(item);
                        for(int j = 0; j < 5; j++)
                        {
                            item.Items.Add($"This is subitem test this treeview {j}");
                        }
                    }
                });
                
            }); 
        }
    }
}
