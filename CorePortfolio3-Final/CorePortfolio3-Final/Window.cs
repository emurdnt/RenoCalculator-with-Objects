using System;
namespace CorePortfolio3Final
{
    public class Window
    {
        
		public double Width { get; set; }
        public double Height { get; set; }

		public Window()
		{

		}

		public Window(double width, double height)
		{

			Width = width;
			Height = height;
		}

		public double Area()
		{
			double area;
			area = Width * Height;
			return area;

		}

		public double Perimeter()
		{
			double perimeter;

			perimeter = (2 * Width) + (2 * Height);

			return perimeter;
		}

        
    }
}
