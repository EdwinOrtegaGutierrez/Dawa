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

namespace GUI_v0._1._2_b.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para SearchView.xaml
    /// </summary>
    public partial class SearchView : Window
    {
        public string Text { get; private set; }

        public SearchView()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Text = textBox.Text;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Text = "The option was cancelled";
            Close();
        }
    }
}
