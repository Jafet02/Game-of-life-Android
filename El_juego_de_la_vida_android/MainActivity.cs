using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Threading;

namespace El_juego_de_la_vida_android
{
    [Activity(Label = "El_juego_de_la_vida_android", MainLauncher = true)]
    public class MainActivity : Activity
    {

        ImageView[,] matrix = new ImageView[8, 6];
        int[,] vida = new int[8, 6];
        int[,] sig_gen = new int[8, 6];
        int[,] vecino = new int[8, 6];

        TextView texto;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            


            int i, j;

            matrix[0, 0] = FindViewById<ImageView>(Resource.Id.imageV1);
            matrix[0, 1] = FindViewById<ImageView>(Resource.Id.imageV2);
            matrix[0, 2] = FindViewById<ImageView>(Resource.Id.imageV3);
            matrix[0, 3] = FindViewById<ImageView>(Resource.Id.imageV4);
            matrix[0, 4] = FindViewById<ImageView>(Resource.Id.imageV5);
            matrix[0, 5] = FindViewById<ImageView>(Resource.Id.imageV6);
            matrix[1, 0] = FindViewById<ImageView>(Resource.Id.imageV7);
            matrix[1, 1] = FindViewById<ImageView>(Resource.Id.imageV8);
            matrix[1, 2] = FindViewById<ImageView>(Resource.Id.imageV9);
            matrix[1, 3] = FindViewById<ImageView>(Resource.Id.imageV10);
            matrix[1, 4] = FindViewById<ImageView>(Resource.Id.imageV11);
            matrix[1, 5] = FindViewById<ImageView>(Resource.Id.imageV12);
            matrix[2, 0] = FindViewById<ImageView>(Resource.Id.imageV13);
            matrix[2, 1] = FindViewById<ImageView>(Resource.Id.imageV14);
            matrix[2, 2] = FindViewById<ImageView>(Resource.Id.imageV15);
            matrix[2, 3] = FindViewById<ImageView>(Resource.Id.imageV16);
            matrix[2, 4] = FindViewById<ImageView>(Resource.Id.imageV17);
            matrix[2, 5] = FindViewById<ImageView>(Resource.Id.imageV18);
            matrix[3, 0] = FindViewById<ImageView>(Resource.Id.imageV19);
            matrix[3, 1] = FindViewById<ImageView>(Resource.Id.imageV20);
            matrix[3, 2] = FindViewById<ImageView>(Resource.Id.imageV21);
            matrix[3, 3] = FindViewById<ImageView>(Resource.Id.imageV22);
            matrix[3, 4] = FindViewById<ImageView>(Resource.Id.imageV23);
            matrix[3, 5] = FindViewById<ImageView>(Resource.Id.imageV24);
            matrix[4, 0] = FindViewById<ImageView>(Resource.Id.imageV25);
            matrix[4, 1] = FindViewById<ImageView>(Resource.Id.imageV26);
            matrix[4, 2] = FindViewById<ImageView>(Resource.Id.imageV27);
            matrix[4, 3] = FindViewById<ImageView>(Resource.Id.imageV28);
            matrix[4, 4] = FindViewById<ImageView>(Resource.Id.imageV29);
            matrix[4, 5] = FindViewById<ImageView>(Resource.Id.imageV30);
            matrix[5, 0] = FindViewById<ImageView>(Resource.Id.imageV31);
            matrix[5, 1] = FindViewById<ImageView>(Resource.Id.imageV32);
            matrix[5, 2] = FindViewById<ImageView>(Resource.Id.imageV33);
            matrix[5, 3] = FindViewById<ImageView>(Resource.Id.imageV34);
            matrix[5, 4] = FindViewById<ImageView>(Resource.Id.imageV35);
            matrix[5, 5] = FindViewById<ImageView>(Resource.Id.imageV36);
            matrix[6, 0] = FindViewById<ImageView>(Resource.Id.imageV37);
            matrix[6, 1] = FindViewById<ImageView>(Resource.Id.imageV38);
            matrix[6, 2] = FindViewById<ImageView>(Resource.Id.imageV39);
            matrix[6, 3] = FindViewById<ImageView>(Resource.Id.imageV40);
            matrix[6, 4] = FindViewById<ImageView>(Resource.Id.imageV41);
            matrix[6, 5] = FindViewById<ImageView>(Resource.Id.imageV42);
            matrix[7, 0] = FindViewById<ImageView>(Resource.Id.imageV43);
            matrix[7, 1] = FindViewById<ImageView>(Resource.Id.imageV44);
            matrix[7, 2] = FindViewById<ImageView>(Resource.Id.imageV45);
            matrix[7, 3] = FindViewById<ImageView>(Resource.Id.imageV46);
            matrix[7, 4] = FindViewById<ImageView>(Resource.Id.imageV47);
            matrix[7, 5] = FindViewById<ImageView>(Resource.Id.imageV48);

            //Vida inicio
            Vida_inicio();
            //Evento touch
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 5; j++)
                {
                    matrix[i, j].Click += MainActivity_Click;
                }
            }


            texto = FindViewById<TextView>(Resource.Id.textView1);

            //Botones
            Button b_reiniciar = FindViewById<Button>(Resource.Id.btnreiniciar);
            b_reiniciar.Click += B_reiniciar_Click;

            Button b_n_generacion = FindViewById<Button>(Resource.Id.btnn_gen);
            b_n_generacion.Click += B_n_generacion_Click;

            Button b_gen_susecivas = FindViewById<Button>(Resource.Id.btngen_sus);
            b_gen_susecivas.Click += B_gen_susecivas_Click;




        }

        private void B_gen_susecivas_Click(object sender, System.EventArgs e)
        {



        }

        private void B_n_generacion_Click(object sender, System.EventArgs e)
        {
            Evaluar_estado();
            Evaluar_vecinos();
            Nueva_generacion();
        }

        public void Nueva_generacion()
        {
            int i, j;
            int listo = 0;
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 5; j++)
                {

                    //Regla 1
                    if (vida[i, j] == 0 && vecino[i, j] == 3 && listo == 0)
                    {
                        vida[i, j] = 1;
                        matrix[i, j].ContentDescription = "vivo";
                        matrix[i, j].SetImageResource(Resource.Drawable.vivo);
                        listo = 1;
                    }

                    //Regla 2
                    //Si esta feliz permanece vivo a la siguiente
                    if (vida[i, j] == 1 && (vecino[i, j] == 2 || vecino[i, j] == 3) && listo == 0)
                    {
                        vida[i, j] = 2;
                        matrix[i, j].ContentDescription = "feliz";
                        matrix[i, j].SetImageResource(Resource.Drawable.feliz);
                        listo = 1;
                    }
                    if (vida[i, j] == 2 && listo == 0)
                    {
                        vida[i, j] = 1;
                        matrix[i, j].ContentDescription = "vivo";
                        matrix[i, j].SetImageResource(Resource.Drawable.vivo);
                        listo = 1;
                    }
                    //Regla 3
                    if (vida[i, j] == 1 && vecino[i, j] < 2 && listo == 0)
                    {
                        vida[i, j] = 0;
                        matrix[i, j].ContentDescription = "muerto";
                        matrix[i, j].SetImageResource(Resource.Drawable.muerto);
                        listo = 1;
                    }

                    //Regla 4
                    if (vida[i, j] == 1 && vecino[i, j] > 3 && listo == 0)
                    {
                        vida[i, j] = 0;
                        matrix[i, j].ContentDescription = "muerto";
                        matrix[i, j].SetImageResource(Resource.Drawable.muerto);
                        listo = 1;
                    }
                    listo = 0;
                }
            }
        }







        private void B_reiniciar_Click(object sender, System.EventArgs e)
        {
            Vida_inicio();
            //timer1.Enabled = false;
        }

        private void MainActivity_Click(object sender, System.EventArgs e)
        {
            ImageView touched = (ImageView)sender;

            string index;

            index = touched.ContentDescription.ToString();
            switch(index)
            {
                case "muerto":
                    touched.ContentDescription = "vivo";
                    touched.SetImageResource(Resource.Drawable.vivo);
                    //vida[i, j] = 0;
                    break;

                case "vivo":
                    touched.ContentDescription = "feliz";
                    touched.SetImageResource(Resource.Drawable.feliz);
                    //vida[i, j] = 0;
                    break;

                case "feliz":
                    touched.ContentDescription = "muerto";
                    touched.SetImageResource(Resource.Drawable.muerto);
                    //vida[i, j] = 0;
                    break;

                default:
                    break;
            }


            index = touched.ContentDescription.ToString();
            texto.Text = index;


        }

        
        public void Evaluar_vecinos()
        {
            int indicer, indicec;
            int i, j;
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 5; j++)
                {
                    //4 reglas
                    indicer = i;
                    indicec = j;

                    //8 vecinos a evaluar
                    vecino[i, j] = 0;

                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            //5, 7, 8
                            //5
                            if (vida[indicer, indicec + 1] == 1 || vida[indicer, indicec + 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //7
                            if (vida[indicer + 1, indicec] == 1 || vida[indicer + 1, indicec] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //8
                            if (vida[indicer + 1, indicec + 1] == 1 || vida[indicer + 1, indicec + 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                        }
                        if (j == 5)
                        {
                            //4, 6, 7
                            //4
                            if (vida[indicer, indicec - 1] == 1 || vida[indicer, indicec - 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //6
                            if (vida[indicer + 1, indicec - 1] == 1 || vida[indicer + 1, indicec - 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //7
                            if (vida[indicer + 1, indicec] == 1 || vida[indicer + 1, indicec] == 2)
                            {
                                vecino[i, j]++;
                            }

                        }
                        if (j != 0 && j != 5)
                        {
                            ////4, 5, 6, 7, 8
                            //4
                            if (vida[indicer, indicec - 1] == 1 || vida[indicer, indicec - 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //5
                            if (vida[indicer, indicec + 1] == 1 || vida[indicer, indicec + 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //6
                            if (vida[indicer + 1, indicec - 1] == 1 || vida[indicer + 1, indicec - 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //7
                            if (vida[indicer + 1, indicec] == 1 || vida[indicer + 1, indicec] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //8
                            if (vida[indicer + 1, indicec + 1] == 1 || vida[indicer + 1, indicec + 1] == 2)
                            {
                                vecino[i, j]++;
                            }

                        }
                    }
                    if (i == 7)
                    {
                        if (j == 0)
                        {
                            //2, 3, 5
                            //2
                            if (vida[indicer - 1, indicec] == 1 || vida[indicer - 1, indicec] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //3
                            if (vida[indicer - 1, indicec + 1] == 1 || vida[indicer - 1, indicec + 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //5
                            if (vida[indicer, indicec + 1] == 1 || vida[indicer, indicec + 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                        }
                        if (j == 5)
                        {
                            //1, 2, 4
                            //1
                            if (vida[indicer - 1, indicec - 1] == 1 || vida[indicer - 1, indicec - 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //2
                            if (vida[indicer - 1, indicec] == 1 || vida[indicer - 1, indicec] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //4
                            if (vida[indicer, indicec - 1] == 1 || vida[indicer, indicec - 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                        }
                        if (j != 0 && j != 5)
                        {
                            ////1, 2, 3, 4, 5
                            //1
                            if (vida[indicer - 1, indicec - 1] == 1 || vida[indicer - 1, indicec - 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //2
                            if (vida[indicer - 1, indicec] == 1 || vida[indicer - 1, indicec] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //3
                            if (vida[indicer - 1, indicec + 1] == 1 || vida[indicer - 1, indicec + 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //4
                            if (vida[indicer, indicec - 1] == 1 || vida[indicer, indicec - 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                            //5
                            if (vida[indicer, indicec + 1] == 1 || vida[indicer, indicec + 1] == 2)
                            {
                                vecino[i, j]++;
                            }
                        }
                    }

                    if (j == 0 && i != 0 && i != 7)
                    {
                        //2, 3, 5, 7, 8
                        //2
                        if (vida[indicer - 1, indicec] == 1 || vida[indicer - 1, indicec] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //3
                        if (vida[indicer - 1, indicec + 1] == 1 || vida[indicer - 1, indicec + 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //5
                        if (vida[indicer, indicec + 1] == 1 || vida[indicer, indicec + 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //7
                        if (vida[indicer + 1, indicec] == 1 || vida[indicer + 1, indicec] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //8
                        if (vida[indicer + 1, indicec + 1] == 1 || vida[indicer + 1, indicec + 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                    }

                    if (j == 5 && i != 0 && i != 7)
                    {
                        //1, 2, 4, 6, 7
                        //1
                        if (vida[indicer - 1, indicec - 1] == 1 || vida[indicer - 1, indicec - 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //2
                        if (vida[indicer - 1, indicec] == 1 || vida[indicer - 1, indicec] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //4
                        if (vida[indicer, indicec - 1] == 1 || vida[indicer, indicec - 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //6
                        if (vida[indicer + 1, indicec - 1] == 1 || vida[indicer + 1, indicec - 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //7
                        if (vida[indicer + 1, indicec] == 1 || vida[indicer + 1, indicec] == 2)
                        {
                            vecino[i, j]++;
                        }
                    }

                    if (i != 0 && i != 7 && j != 0 && j != 5)
                    {
                        //todas
                        //1
                        if (vida[indicer - 1, indicec - 1] == 1 || vida[indicer - 1, indicec - 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //2
                        if (vida[indicer - 1, indicec] == 1 || vida[indicer - 1, indicec] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //3
                        if (vida[indicer - 1, indicec + 1] == 1 || vida[indicer - 1, indicec + 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //4
                        if (vida[indicer, indicec - 1] == 1 || vida[indicer, indicec - 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //5
                        if (vida[indicer, indicec + 1] == 1 || vida[indicer, indicec + 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //6
                        if (vida[indicer + 1, indicec - 1] == 1 || vida[indicer + 1, indicec - 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //7
                        if (vida[indicer + 1, indicec] == 1 || vida[indicer + 1, indicec] == 2)
                        {
                            vecino[i, j]++;
                        }
                        //8
                        if (vida[indicer + 1, indicec + 1] == 1 || vida[indicer + 1, indicec + 1] == 2)
                        {
                            vecino[i, j]++;
                        }
                    }
                }//for j
            }//For i

        }


        public void Vida_inicio()
        {
            int i, j;


            //3 estados     0-muerto    1-vivo  2-feliz
            //Background    black       white   green
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 5; j++)
                {
                    matrix[i, j].ContentDescription = "muerto";
                    matrix[i, j].SetImageResource(Resource.Drawable.muerto);
                    vida[i, j] = 0;
                }
            }
        }

        public void Evaluar_estado()
        {
            string index;
            int i, j;
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 5; j++)
                {
                    index = matrix[i, j].ContentDescription.ToString();
                    switch (index)
                    {
                        case "muerto":
                            vida[i, j] = 0;
                            break;

                        case "vivo":    
                            vida[i, j] = 1;
                            break;

                        case "feliz":
                            vida[i, j] = 2;
                            break;
                        default:
                            vida[i, j] = 0;
                            break;
                    }

                }
            }
        }

    }
}

