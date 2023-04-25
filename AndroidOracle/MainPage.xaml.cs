using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidOracle
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        bool firstStart = true;
        public async void FadeAnswer(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "Text")
            {
                if (firstStart)
                {
                    firstStart = false;
                    return;
                }
                Label cell = ((Label)sender);
                cell.Opacity = 0;
                await cell.FadeTo(1, 2000);
            }
        }
        public async void AnswersAnimate(object sender, EventArgs e)
        {
            View cell = ((ViewCell)sender).View;
            cell.Opacity = 0;
            await cell.FadeTo(1, 1000);
        }
    }
}