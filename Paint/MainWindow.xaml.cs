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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Global Variables
        //Global variable for our painter
        ShapeProccessor ShapeProcessor = new ShapeProccessor();
        //isDraggable
        bool isDraggable = false;
        //draggingElement variable
        UIElement draggingElement = new UIElement();

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ShapeProcessor.DrawElli(DrawCanvas);
            
            
        }


      

        /// <summary>
        /// Disable dragging + probbably other stuff later
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDraggable = false;
        }

        /// <summary>
        /// Disable dragging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDraggable = true;
        }

        

        private void DrawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDraggable = true;
            //UIElement draggingElement = Mouse.DirectlyOver as Shape;
            //MessageBox.Show(draggingElement.ToString());

        }

        private void DrawCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDraggable = false;
            MessageBox.Show(draggingElement.ToString());
        }

        private void DrawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                draggingElement = Mouse.DirectlyOver as UIElement;
                if (isDraggable && draggingElement.GetType() == typeof(Ellipse))
                {
                    Point mousepos = e.GetPosition(DrawCanvas);
                    
                    Canvas.SetTop(draggingElement, mousepos.Y - 85);
                    Canvas.SetLeft(draggingElement, mousepos.X - 85);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
