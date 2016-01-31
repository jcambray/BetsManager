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

namespace BetManager.Core
{
    /// <summary>
    /// Logique d'interaction pour MenuItem.xaml
    /// </summary>
    public partial class MenuItem : UserControl
    {



        public SolidColorBrush FontColor
        {
            get { return (SolidColorBrush)GetValue(FontColorProperty); }
            set { SetValue(FontColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontColorProperty =
            DependencyProperty.Register("FontColor", typeof(SolidColorBrush), typeof(MenuItem));




        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MenuItem));




        public MenuItem()
        {
            InitializeComponent();
        }
    }
}
