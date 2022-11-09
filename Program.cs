using System;
using System.IO;
//Ana Paola Morales Anaya
namespace Semantica
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (Lenguaje a = new Lenguaje())
            {
                try
                {
                    a.Programa();

                    //a.cerrar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}