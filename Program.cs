﻿using System;
using System.IO;
//Ana Paola Morales Anaya
namespace Semantica
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Lenguaje a = new Lenguaje();//C:\\Users\\HOME\\Documents\\PAOLA TAREAS\\5TO SEMESTRE\\AUTOMATAS II\\UNIDAD 1\\Evalua\\prueba.cpp"
                a.Programa();
                /*while(!a.FinArchivo())
                {
                    a.NextToken();
                }*/
                a.cerrar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}