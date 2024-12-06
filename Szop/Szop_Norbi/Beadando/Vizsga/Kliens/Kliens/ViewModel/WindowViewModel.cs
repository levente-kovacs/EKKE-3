using Kliens.Core;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;


namespace Kliens
{   
    public class WindowViewModel : BaseViewModel
    {
        private Window window;
        private int outerMarginSize = 10;
        private int windowRadius = 10;       

        public double WindowMinimumWidth { get; set; } = 800;
        public double WindowMinimumHeight { get; set; } = 500;

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        public int ResizeBorder { get; set; } = 6;
        public Thickness InnerContentPadding { get; set; } = new Thickness(0, 0, 0, 0);
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }
        public int OuterMarginSize
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : outerMarginSize;
            }
            set
            {
                outerMarginSize = value;
            }

        }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }
        public int WindowRadius
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : windowRadius;
            }
            set
            {
                windowRadius = value;
            }
        }
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }
        public int TitleHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        

        public WindowViewModel(Window window)
        {
            this.window = window;
            window.StateChanged += (sender,e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));

            var resizer = new WindowResizer(window);
        }
                

        private Point GetMousePosition()
        {
            var pos = Mouse.GetPosition(window);

            return new Point(pos.X + window.Left, pos.Y + window.Top);
        }
      

    }
}
