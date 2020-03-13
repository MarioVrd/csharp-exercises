using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
	public abstract class Shape
	{
		protected double xPos;
		protected double yPos;

		public abstract double getArea();
		public abstract double getPerimeter();
		public abstract void printData();

		public double getXPos()
		{
			return xPos;
		}

		public double getYPos()
		{
			return yPos;
		}
	}
}
