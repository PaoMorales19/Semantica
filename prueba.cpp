// Ana Paola Morales Anaya
#include <iostream>
#include <stdio.h>
#include <conio.h>
float area, radio, pi, resultado;
int a, d, altura;
int x;
int i;
int j;
int k,l,y;
// Este programa calcula el volumen de un cilindro.
void main()
{
    for(i = 0; i<10; i++)
    {
        for(j = 0; j<10; j++)
        {
            x = x + 1;
            for(k = 0; k<10; k++)
                for(l = 0; l<10; l++)
                    y = y+2;
        }
    }    

    /*y = 255;
    y++; // Error semantico
    
        // Requerimiento 5.- Levanta una excepcion en el scanf si la captura no es un numero
        printf("Introduce la altura de la piramide: ");
    scanf("altura", &altura);
    // Requerimiento 6.- Ejecutar el for y for anidado
    if (altura > 4)
        for (i = altura; i > 0; i -= 2)
        {
            j = 0;
            while (j < altura - i)
            {
                if (j %= = 0)
                {
                    printf("*");
                }
                else
                {
                    printf("-"); // Requerimiento 4.- evalua nuevamente los else
                }
                j += 1;
            }
            printf("\n");
        }
    else
        printf("\nError: la altura debe de ser mayor que 2\n");
    if (1 != 1)
    {
        printf("Esto no se debe imprimir");
        if (2 == 2)
        {
            printf("Esto tampoco"); // Requerimiento 4.- evalua nuevamente los if respecto al parametro que reciben
        }
    }
    a = 256;
    printf("Valor de variable int a antes del casteo: ");
    printf(a);
    y = (char)(a); // Requerimiento 2 y 3, actualiza el dominante y convierte el valor con una funcion
    printf("\nValor de variable char y despues del casteo de a: ");
    printf(y);
    printf("\nA continuacion se intenta asignar un int a un char sin usar casteo: \n");
    y = a; // Requerimiento 1.- debe marcar error*/
}