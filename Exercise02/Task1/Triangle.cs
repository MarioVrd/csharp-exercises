using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
	public class Triangle : Shape
	{
		private double oneSide;

		public Triangle(double p)
		{
			oneSide = p;
			xPos = DataModel.getNewXPos();
			yPos = DataModel.getNewYPos();
		}

		public override double getArea()
		{
			return (Math.Sqrt(3) / 4) * (oneSide * oneSide);
		}

		public override double getPerimeter()
		{
			return 3 * oneSide;
		}

		public override void printData()
		{
			Console.WriteLine();
			Console.WriteLine("My type: " + this.GetType());
			Console.WriteLine("Side of triangle = " + oneSide);
			Console.WriteLine("X position = " + xPos);
			Console.WriteLine("Y position = " + yPos);
		}
	}
}
