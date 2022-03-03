using System;
using System.Collections.Generic;
using System.Text;

namespace aprendizado_com_perceptron.Entities
{
    public class Perceptron
    {
		public List<Entrada> Entradas { get; private set; }
		public Double Bias { get; private set; }
		public double Peso1 { get; private set; }
		public double Peso2 { get; private set; }
		public double TaxaErro { get; private set; }
		public double TaxaAprendizado { get; private set; }
        public decimal QtdeTreinosFeitos { get; set; }


        public Perceptron(double taxaAprendizado)
		{
			Entradas = new List<Entrada>();
			GeraPesos();
			TaxaAprendizado = taxaAprendizado;
			QtdeTreinosFeitos = 0;
		}

		private void GeraPesos()
        {
			Random r = new Random();
			Peso1 = r.NextDouble();
			Peso2 = r.NextDouble();
        }

		public double AtualizaPeso(double pesoAntigo, double erro, double entrada)
		{
			return pesoAntigo + TaxaAprendizado * erro * entrada;
		}

		public void Treinamento(List<Entrada> listaEntradas)
		{
			QtdeTreinosFeitos++;
			double somatorio = 0;
			int resultado;
			foreach (var item in listaEntradas)
			{
				somatorio = (item.X * Peso1) + (item.Y * Peso2);
				resultado = FuncaoDegrau(somatorio);
				if (resultado != item.Classe)
				{
					//calcular erro e atualizar os pesos
					int erro = CalcularErro(item.Classe, resultado);
					Peso1 = AtualizaPeso(Peso1, erro, item.X);
					Peso2 = AtualizaPeso(Peso2, erro, item.Y);

				}
			}

		}

		public int FuncaoDegrau(double valor)
		{
			return valor >= 0 ? 1 : 0;
		}

		public int CalcularErro(int valorEnsinado, int valorCalculado)
		{
			return valorEnsinado - valorCalculado;
		}

		public int Teste(double x, double y)
		{
			return FuncaoDegrau((x * Peso1) + (y * Peso2));
		}

		public string Classificador(double x, double y)
        {
			var resposta = new StringBuilder();
			resposta.Append($"X: {x} | Y: {y} | ");
			if(Teste(x, y) > 0)
            {
				resposta.Append("Laranja");
            }
            else
            {
				resposta.Append("Maçã");
            }

			return resposta.ToString();
        }
	}
}