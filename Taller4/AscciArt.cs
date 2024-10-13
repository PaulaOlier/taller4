using System;
using Taller4;

namespace Taller4
{
    // Clase que contiene métodos para mostrar arte ASCII
    public class AsciiArt
    {
        // Método que imprime el arte ASCII
        public void ImprimirBienvenido()
        {
            Console.WriteLine(" ____  _                           _     _           ");
            Console.WriteLine("| __ )(_) ___ _ ____   _____ _ __ (_) __| | ___  ___ ");
            Console.WriteLine("|  _ \\| |/ _ \\ '_ \\ \\ / / _ \\ '_ \\| |/ _` |/ _ \\/ __|");
            Console.WriteLine("| |_) | |  __/ | | \\ V /  __/ | | | | (_| | (_) \\__ \\");
            Console.WriteLine("|____/|_|\\___|_| |_|\\_/ \\___|_| |_|_|\\__,_|\\___/|___/");
            Console.WriteLine();
        }

         public static void ImprimirFacturaASCII()
        {
            Console.WriteLine("  _____          _                   ");
            Console.WriteLine(" |  ___|_ _  ___| |_ _   _ _ __ __ _ ");
            Console.WriteLine(" | |_ / _` |/ __| __| | | | '__/ _` |");
            Console.WriteLine(" |  _| (_| | (__| |_| |_| | | | (_| |");
            Console.WriteLine(" |_| |__,_ |___|__| |_,_|_| | |___,_| ");          
                  
        }
    }
}
