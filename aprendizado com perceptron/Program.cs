using System;
using System.Collections.Generic;
using aprendizado_com_perceptron.Entities;
using System.Globalization;
using System.Threading;

namespace aprendizado_com_perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entrada> baseTreinamento = new List<Entrada>
            {
                new Entrada(113, 6.8, 0),
                new Entrada(122, 4.7, 1),
                new Entrada(107, 5.2, 0),
                new Entrada(98,  3.6, 0),
                new Entrada(115, 2.9, 1),
                new Entrada(120, 4.2, 1)
            };

            //declarar o neuronio
            Perceptron p1 = new Perceptron(0.1);
            decimal epocas = 30000000;

            Thread thread1 = new Thread(() => Treino(p1, baseTreinamento, epocas, 1));
            Thread thread2 = new Thread(() => Treino(p1, baseTreinamento, epocas, 2));
            Thread thread3 = new Thread(() => Treino(p1, baseTreinamento, epocas, 3));
            Thread thread4 = new Thread(() => Treino(p1, baseTreinamento, epocas, 4));
            Thread thread5 = new Thread(() => Treino(p1, baseTreinamento, epocas, 5));
            Thread thread6 = new Thread(() => Treino(p1, baseTreinamento, epocas, 6));
            Thread thread7 = new Thread(() => Treino(p1, baseTreinamento, epocas, 7));
            Thread thread8 = new Thread(() => Treino(p1, baseTreinamento, epocas, 8));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();
            thread7.Start();
            thread8.Start();

            Console.WriteLine(thread1.ThreadState);
            bool finalizado = false;

            while (!finalizado)
            {
                finalizado = thread1.ThreadState != ThreadState.Running
                                && thread2.ThreadState != ThreadState.Running
                                && thread3.ThreadState != ThreadState.Running
                                && thread4.ThreadState != ThreadState.Running
                                && thread5.ThreadState != ThreadState.Running
                                && thread6.ThreadState != ThreadState.Running
                                && thread7.ThreadState != ThreadState.Running
                                && thread8.ThreadState != ThreadState.Running;
            }

            Console.WriteLine("pressione enter para continuar");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Qtde treinos feitos {p1.QtdeTreinosFeitos}");
            Console.WriteLine("Resultados:\n");
            MostraResultado(p1);
        }


        static void Treino(in Perceptron perceptron, List<Entrada> entradas, decimal epocas, int index)
        {
            for (int i = 0; i < (epocas / 8); i++)
            {
                perceptron.Treinamento(entradas);
            }
            //Console.WriteLine($"Thread {index} finalizou");
        }

        static void MostraResultado(in Perceptron perceptron)
        {
            Console.WriteLine(perceptron.Classificador(113, 6.8));
            Console.WriteLine(perceptron.Classificador(122, 4.7));
            Console.WriteLine(perceptron.Classificador(107, 5.2));
            Console.WriteLine(perceptron.Classificador(98, 3.6));
            Console.WriteLine(perceptron.Classificador(115, 2.9));
            Console.WriteLine(perceptron.Classificador(120, 4.2));
        }
    }
}
