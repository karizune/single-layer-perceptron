using System;
using System.Collections.Generic;
using System.Text;

namespace aprendizado_com_perceptron.Entities
{
    public static class ConsoleEx
    {
        public static void ColoredWriteLine(string Text, ConsoleColor TextColor = ConsoleColor.White, ConsoleColor BackgroundColor = ConsoleColor.Black)
        {
            if(TextColor != ConsoleColor.White)
            {
                Console.ForegroundColor = TextColor;
            }

            if(BackgroundColor != ConsoleColor.Black)
            {
                Console.BackgroundColor = BackgroundColor;
            }

            Console.WriteLine(Text);
            Console.ResetColor();
        }
    }

}
