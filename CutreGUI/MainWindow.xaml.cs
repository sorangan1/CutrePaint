using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public bool dragging = false;
        public int zLayers = 0;
        Point mousePosition;
        public int objectType = 1; // 1 is default cursor, you can move elements etc...
        public int objectColor = 1; // default color is white


        public MainWindow()
        {
            InitializeComponent();
        }

        private void CutreCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (objectType)
            {
                case 1: // default
                    break;
                case 2: // 2 = rectangle
                    Rectangle rectangle = DrawRectangle(Convert.ToDouble(ObjectWidth.Text), Convert.ToDouble(ObjectHeight.Text), ObjectStrokeThickness.Value, Brushes.Black, GetCurrentColor(objectColor));

                    CutreCanvas.Children.Add(rectangle);

                    break;
            }
        }


        private void CutreCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
        }


        #region RECTANGLE OBJECT STUFF

        // God please save me.
        private Rectangle DrawRectangle(double _Width, double _Height, double _StrokeThickness, Brush _Stroke,  Brush _Fill)
        {
            mousePosition = Mouse.GetPosition(CutreCanvas);
            Rectangle rectangle = new Rectangle();

            // Asign Variable
            rectangle.Width = _Width;
            rectangle.Height = _Height;
            rectangle.StrokeThickness = _StrokeThickness;
            rectangle.Stroke = _Stroke;
            rectangle.Fill = _Fill;

            // Event handlers
            rectangle.MouseDown += Object_MouseDown;
            rectangle.MouseUp += Object_MouseUp;
            rectangle.MouseMove += Object_MouseMove;

            // Position where the rectangle is drawn
            Canvas.SetLeft(rectangle, mousePosition.X - (rectangle.Width / 2));
            Canvas.SetTop(rectangle, mousePosition.Y - (rectangle.Height / 2));

            Canvas.SetZIndex(rectangle, zLayers + 1); //When we create an object we want to get the zLayers and add 1 so the new created object is on top

            zLayers++;

            return rectangle;
        }

        #endregion

        private void SelectCursor_Click(object sender, RoutedEventArgs e)
        {
            CutreCanvas.Cursor = Cursors.Arrow;
            objectType = 1;
        }

        private void SelectRectangle_Click(object sender, RoutedEventArgs e)
        {
            CutreCanvas.Cursor = Cursors.Cross;
            objectType = 2;
        }

        // All this Object_*whatever stuff makes no sense, but it works i guess.
        private void Object_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragging = true; // dragging bool set to true

            mousePosition = Mouse.GetPosition(CutreCanvas);

            zLayers++; // I dont know why I had to add this but if I delete it, it wont work.
        }

        private void Object_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {  
        }

        private void Object_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dragging = false;
            CutreCanvas.Cursor = GetCurrentCursorType(objectType); // Set the last cursor type when you stop dragging
        }

        private void Object_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && objectType == 1) // you only can move things when the cursor is an arrow
            {
                // all this works

                CutreCanvas.Cursor = Cursors.Hand;
                Rectangle draggedRectangle = sender as Rectangle;
                Point newPosition = Mouse.GetPosition(CutreCanvas);

                Canvas.SetZIndex(draggedRectangle, zLayers + 1);

                double rectLeft = Canvas.GetLeft(draggedRectangle);
                double rectTop = Canvas.GetTop(draggedRectangle);

                Canvas.SetLeft(draggedRectangle, rectLeft + (newPosition.X - mousePosition.X));
                Canvas.SetTop(draggedRectangle, rectTop + (newPosition.Y - mousePosition.Y));

                mousePosition = newPosition;
            }
        }

        // clear the canvas and set zLayers to 0
        private void ClearCanvas_Click(object sender, RoutedEventArgs e)
        {
            CutreCanvas.Children.Clear();
            zLayers = 0;
        }

        // yes
        private Cursor GetCurrentCursorType(int objectType)
        {
            switch (objectType)
            {
                case 1:
                    CutreCanvas.Cursor = Cursors.Arrow;
                 
                    break;
                case 2:
                    CutreCanvas.Cursor = Cursors.Cross;

                    break;
            }

            return CutreCanvas.Cursor;
        }

        private Brush GetCurrentColor(int objectColor)
        {
            Brush myBrush = Brushes.Red;

            if (objectColor == 1)
            {
                myBrush = Brushes.White;
            }
            else if (objectColor == 2)
            {
                myBrush = Brushes.Red;
            }
            else if (objectColor == 3)
            {
                myBrush = Brushes.Lime;
            }
            else if (objectColor == 4)
            {
                myBrush = Brushes.DodgerBlue;
            }
            else if (objectColor == 5)
            {
                myBrush = Brushes.Yellow;
            }
            else if (objectColor == 6)
            {
                myBrush = Brushes.MediumPurple;
            }
            else if (objectColor == 7)
            {
                myBrush = Brushes.Orange;
            }
            else if (objectColor == 8)
            {
                myBrush = Brushes.Cyan;
            }

            return myBrush;
        }

        private void ObjectColorWhite_Click(object sender, RoutedEventArgs e)
        {
            objectColor = 1;
            GetCurrentColor(objectColor);
        }

        private void ObjectColorRed_Click(object sender, RoutedEventArgs e)
        {
            objectColor = 2;
        }

        private void ObjectColorGreen_Click(object sender, RoutedEventArgs e)
        {
            objectColor = 3;
            GetCurrentColor(objectColor);
        }

        private void ObjectColorBlue_Click(object sender, RoutedEventArgs e)
        {
            objectColor = 4;
            GetCurrentColor(objectColor);
        }

        private void ObjectColorYellow_Click(object sender, RoutedEventArgs e)
        {
            objectColor = 5;
            GetCurrentColor(objectColor);
        }

        private void ObjectColorPurple_Click(object sender, RoutedEventArgs e)
        {
            objectColor = 6;
            GetCurrentColor(objectColor);
        }

        private void ObjectColorOrange_Click(object sender, RoutedEventArgs e)
        {
            objectColor = 7;
            GetCurrentColor(objectColor);
        }

        private void ObjectColorCyan_Click(object sender, RoutedEventArgs e)
        {
            objectColor = 8;
            GetCurrentColor(objectColor);
        }
    }
}
