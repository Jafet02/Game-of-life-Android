using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace El_juego_de_la_vida_android
{
    class Juego_Jaff
    {
        ImageView[,] matrix = new ImageView[T, T];
        int[,] vida = new int[T, T];
        int[,] sig_gen = new int[T, T];
        int[,] vecino = new int[T, T];

        public void Inicializar_tablero()
        {
            int i, j;
            for (i = 0; i <= 15; i++)
            {
                for (j = 0; j <= 15; j++)
                {
                    
                    matrix[i, j] = new ImageView();

                    matrix[i, j].Add();

                    
                }
            }
        }
    }
}