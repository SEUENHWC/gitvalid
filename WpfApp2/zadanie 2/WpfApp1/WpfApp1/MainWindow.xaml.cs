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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing;
        private Point lastPoint;
        private SolidColorBrush currentBrush;
        private int brushSize;
    
        public MainWindow()
        {
            InitializeComponent();
            currentBrush = new SolidColorBrush(Colors.Black);
            brushSize = 5;
        }

        private void BrushColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrushColorComboBox.SelectedItem is System.Windows.Controls.ComboBoxItem selectedItem)
            {
                currentBrush.Color = (Color)ColorConverter.ConvertFromString(selectedItem.Tag.ToString());
            }
        }

        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isDrawing = true;
                lastPoint = e.GetPosition(DrawingCanvas);
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                var currentPoint = e.GetPosition(DrawingCanvas);
                DrawLine(lastPoint, currentPoint);
                lastPoint = currentPoint;
            }
        }

        private void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
        }

        private void Mode_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void DrawLine(Point startPoint, Point endPoint)
        {
            var line = new System.Windows.Shapes.Line
            {
                Stroke = currentBrush,
                StrokeThickness = brushSize,
                X1 = startPoint.X,
                Y1 = startPoint.Y,
                X2 = endPoint.X,
                Y2 = endPoint.Y
            };
            DrawingCanvas.Children.Add(line);
        }
    }
}
