using System;
using System.Collections.Generic;
using System.Text;

namespace aprendizado_com_perceptron.Entities
{
    public class Entrada
    {
		public Entrada(double x, double y, int classe)
		{
			X = x;
			Y = y;
			Classe = classe;
		}

		public Entrada(double x, double y)
        {
			X = x;
			Y = y;
        }

		public double X { get; private set; }
		public double Y { get; private set; }
		public int Classe { get; private set; }
	}
}
