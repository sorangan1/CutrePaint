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

namespace CutreGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CutreCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = DrawRectangle(Convert.ToDouble(RectangleWidth.Text), Convert.ToDouble(RectangleHeight.Text), RectangleStrokeThickness.Value, Brushes.Black, Brushes.Cyan);

            CutreCanvas.Children.Add(rectangle);
        }

        private Rectangle DrawRectangle(double _Width, double _Height, double _StrokeThickness, Brush _Stroke,  Brush _Fill)
        {
            Point position = Mouse.GetPosition(CutreCanvas);
            Rectangle rectangle = new Rectangle();

            rectangle.Width = _Width;
            rectangle.Height = _Height;
            rectangle.StrokeThickness = _StrokeThickness;
            rectangle.Stroke = _Stroke;
            rectangle.Fill = _Fill;

            Canvas.SetLeft(rectangle, position.X - (rectangle.Width / 2));
            Canvas.SetTop(rectangle, position.Y - (rectangle.Height / 2));

            return rectangle;
        }
    }
}
