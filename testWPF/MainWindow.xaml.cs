﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var browser = new System.Windows.Forms.WebBrowser();
            browser.Navigate("https://www.betclic.fr/football/ligue-1-e4");
            var elements = browser.Document.GetElementsByTagName("match-entry clearfix CompetitionEvtSpe");
            HtmlElement myElement;
            foreach (HtmlElement elemnt in elements)
            {
                var attr = elemnt.GetAttribute("data - track -event-name");
                if (string.IsNullOrEmpty(attr))
                    if (attr == "Nice - Lyon")
                        myElement = elemnt;

            }
        }
    }
}
