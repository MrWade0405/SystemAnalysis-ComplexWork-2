using System;
using System.Linq;

namespace CA_K3_2
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;
			double[][] matrix;

			Console.Write("n = ");
			n = Convert.ToInt32(Console.ReadLine());

			matrix = new double[n][];

			for(int i = 0; i < n; ++i)
			{
				matrix[i] = new double[n];
			}

			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[i].Length; j++)
				{
					matrix[i][j] = Convert.ToDouble(Console.ReadLine());
				}
			}

			double[] Xs = new double[n];

			for (int i = 0; i < n; ++i)
			{
				Xs[i] = GetXi(matrix[i]);
			}

			double sumXs = Xs.Sum();

			double[] vectorsOfPriorities = new double[n];

			for (int i = 0; i < n; ++i)
			{
				vectorsOfPriorities[i] = Xs[i] / sumXs;
			}

			Console.WriteLine("VectorsOfPriorities: ");

			for (int i = 0; i < n; ++i)
			{
				Console.WriteLine(vectorsOfPriorities[i]);
			}

			double Lmax = GetLmax(matrix, vectorsOfPriorities);
			double Iy = (Lmax - n) / (n - 1);

			Console.WriteLine("Iy: ");
			Console.WriteLine(Iy);

			double I0 = Iy /
				1.12; // n == 5

			Console.WriteLine("I0: ");
			Console.WriteLine(I0);

			Console.ReadKey();
		}

		private static double GetXi(double[] array)
		{
			double sum = 1;

			for (int i = 0; i < array.Length; i++)
			{
				sum *= array[i];
			}

			return Math.Pow(sum, (double)1 / array.Length);
		}

		private static double GetLmax(double[][] array, double[] vectorsOfPriorities)
		{
			double Lmax = 0;
			
			for (int i = 0; i < array.Length; i++)
			{
				double sum = 0;

				for (int j = 0; j < array[i].Length; j++)
				{
					sum += array[j][i];
				}

				Lmax += vectorsOfPriorities[i] * sum;
			}

			return Lmax;
		}
	}
}
