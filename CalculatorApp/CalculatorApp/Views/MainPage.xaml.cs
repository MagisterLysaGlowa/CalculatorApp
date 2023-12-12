using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        private double width = 0;
        private double height = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void OperationClick(object sender, EventArgs e)
        {

        }

        private void NumberClick(object sender, EventArgs e)
        {

        }

        private void EqualsClick(object sender, EventArgs e)
        {

        }

        private void CommaClick(object sender, EventArgs e)
        {

        }

        private void ClearClick(object sender, EventArgs e)
        {

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                if(this.width > this.height)
                {
                    GridLayout.Children.Remove(VerticalGridControll);
                    GridLayout.Children.Add(HorizontalGridControll);
                    DisplayAlert("teraz", "teraz", "teraz");
                }
                else
                {
                    GridLayout.Children.Remove(HorizontalGridControll);
                    GridLayout.Children.Add(VerticalGridControll);
                }
            }
        }
    }
}
