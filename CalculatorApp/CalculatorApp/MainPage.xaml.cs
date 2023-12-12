using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
    public enum Operation
    {
        None,
        Add,
        Subtract,
        Multiply,
        Divide,
        Square,
        SquareRoot,
        Inverse
    }

    public partial class MainPage : ContentPage
    {
        private double a;
        private double b;
        private Operation operation = Operation.None;


        public MainPage()
        {
            InitializeComponent();
        }

        private void NumberClick(object sender, EventArgs e)
        {
            if(operation == Operation.None)
            {
                a = double.Parse(a.ToString() + ((Button)sender).Text);
            }
            else
            {
                b = double.Parse(b.ToString() + ((Button)sender).Text);
            }
        }

        private void OperationClick(object sender, EventArgs e)
        {
            switch(((Button)sender).Text) 
            { 

            }
        }

    }
}
