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

namespace Paint
{
    class ShapeProccessor
    {
        //stack that holds all shapes
        public List<Shape> ShapeList = new List<Shape>();
        //the brush we paint with
        SolidColorBrush myBrush = new SolidColorBrush();
        public void DrawElli(Canvas DrawPanel)
        {
            try
            {
                myBrush.Color = Brushes.Coral.Color;
                Ellipse myShape = new Ellipse();
                myShape.Height = 200;
                myShape.Width = 200;
                myShape.Stroke = Brushes.Coral;
                myShape.StrokeThickness = 2;
                myShape.Fill = myBrush;
                DrawPanel.Children.Add(myShape);
                //Add Shape to the shape list
                ShapeList.Add(myShape);
              
            }

            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }
    }
}
