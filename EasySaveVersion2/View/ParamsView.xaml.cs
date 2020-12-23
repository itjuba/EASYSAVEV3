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

namespace EasySaveVersion2.View
{
    /// <summary>
    /// Logique d'interaction pour ParamsView.xaml
    /// </summary>
    public partial class ParamsView : UserControl
    {
        public ParamsView()
        {
            InitializeComponent();
        }

        public void Lang(object sender, RoutedEventArgs e)
        {
            string _fr = RdBtnFr.IsChecked==true ? "Fr": null;
            string _en = RdBtnEn.IsChecked == true ? "En" : null;

        }
    }
}
