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
        private double a = 0;
        private double b = 0;
        private Operation operation = Operation.None;
        private bool comma = false;
        private double result = 0;
        private bool equalsClicked = false;

        private double width = 0;
        private double height = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void NumberClick(object sender, EventArgs e)
        {
            if(operation == Operation.None)
            {
                if(comma)
                {
                    a = double.Parse(a.ToString() + "." + ((Button)sender).Text);
                    comma = false;
                }
                else
                    a = double.Parse(a.ToString() + ((Button)sender).Text);
            }
            else
            {
                if (comma)
                {
                    b = double.Parse(b.ToString() + "." + ((Button)sender).Text);
                    comma = false;
                }
                else
                    b = double.Parse(b.ToString() + ((Button)sender).Text);
            }
        }

        private void OperationClick(object sender, EventArgs e)
        {
            switch(((Button)sender).Text)
            {
                case "+":
                    operation = Operation.Add;
                    break;
                case "-":
                    operation = Operation.Subtract;
                    break;
                case "*":
                    operation = Operation.Multiply;
                    break;
                case "/":
                    operation = Operation.Divide;
                    break;
                case "x^2":
                    result = a * a;
                    operation = Operation.Square;
                    Print();
                    break;
                case "sqrt":
                    result = Math.Sqrt(a);
                    operation = Operation.SquareRoot;
                    Print();
                    break;
                case "1/x":
                    result = 1 / a;
                    operation = Operation.Inverse;
                    Print();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void Equals(object sender, EventArgs e)
        {
            switch(operation)
            {
                case Operation.Add:
                    result = a + b;
                    equalsClicked = true;
                    Print();
                    break;
                case Operation.Subtract:
                    result = a - b;
                    equalsClicked = true;
                    Print();
                    break;
                case Operation.Multiply:
                    result = a * b;
                    equalsClicked = true;
                    Print();
                    break;
                case Operation.Divide:
                    result = a / b;
                    equalsClicked = true;
                    Print();
                    break;
            }
        }

        private void Print()
        {
            if(operation == Operation.None)
            {
                Output_Label.Text = a.ToString();
                OutputEquation_Label.Text = "";
                return;
            }
            switch(operation)
            {
                case Operation.Add:
                case Operation.Subtract:
                case Operation.Multiply:
                case Operation.Divide:
                    if(equalsClicked)
                    {
                        Output_Label.Text = result.ToString();
                        OutputEquation_Label.Text = a.ToString() + " " + OperationToSign(operation) + " " + b.ToString() + " =";
                    }
                    else
                    {
                        Output_Label.Text = b.ToString();
                        OutputEquation_Label.Text = a.ToString() + " " + OperationToSign(operation);
                    }
                    break;
                case Operation.Square:
                    Output_Label.Text = result;
                    OutputEquation_Label.Text = "sqr(" + a + ")";
                    break;
                case Operation.SquareRoot:
                    Output_Label.Text = result;
                    OutputEquation_Label.Text = "sqrt(" + a + ")";
                    break;
                case Operation.Inverse:
                    Output_Label.Text = result;
                    OutputEquation_Label.Text = "1/" + a.ToString();
                    break;
            }
        }

        private string OperationToSign(Operation operation)
        {
            string operationSign = "";
            switch (operation)
            {
                case Operation.Add:
                    operationSign = "+";
                    break;
                case Operation.Subtract:
                    operationSign = "-";
                    break;
                case Operation.Multiply:
                    operationSign = "*";
                    break;
                case Operation.Divide:
                    operationSign = "/";
                    break;
            }
            return operationSign;
        }

        private void ClearClick(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            result = 0;
            comma = false;
            operation = Operation.None;
            equalsClicked = false;
        }
            
        private void CommaClick(object sender, EventArgs e)
        {
            comma = true;
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
