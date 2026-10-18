using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tic_tac_toe
{
    // Eén vakje van het speelbord. Toont een X, een O of niets.
    public partial class XOcell : UserControl
    {
        // Wordt afgevuurd als er op het vakje geklikt wordt (MainWindow luistert hiernaar)
        public event RoutedEventHandler CellClicked;

        private String _Value = "";

        public String Value
        {
            get { return _Value; }
            set
            {
                _Value = value;

                if (value == "X")
                {
                    Button1.Content = CreateXShape();
                }
                else if (value == "O")
                {
                    Button1.Content = CreateOShape();
                }
                else
                {
                    Button1.Content = null;
                }
            }
        }

        public XOcell()
        {
            InitializeComponent();
            Button1.Click += (sender, e) => CellClicked?.Invoke(this, e);
        }

        private Path CreateXShape()
        {
            return new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Data = Geometry.Parse("M 10,10 L 90,90 M 90,10 L 10,90")
            };
        }

        private Path CreateOShape()
        {
            return new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Data = Geometry.Parse("M 50,10 A 40,40 0 1 1 49.9,10")
            };
        }
    }
}
