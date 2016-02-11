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
            
        }

        private void DrawCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDraggable = false;
        }

        private void DrawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
               
                if (isDraggable)
                {
                    Point mousepos = e.GetPosition((UIElement)sender);
                    Canvas.SetTop(ShapeProcessor.ShapeList[0], mousepos.Y);
                    Canvas.SetLeft(ShapeProcessor.ShapeList[0], mousepos.X);
                    
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
