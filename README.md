# AplicacionesDeConsolaVs
Aplicacion de consola por modulos
public static void JuegoAhorcado()
        {
            bool juegoActivo = true;
            string palabra = "" ;
            int vidas = 3;
            string letra = "";
            int correctas = 0;
            int contador = 0;
            char letraPorCaracter = ' ';
            string volverAjugar = "";
            string[] numeros = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            mensajeBienvenida();
            while (juegoActivo == true)
            {
                int contador2 = 1, contador3 = 0;//Contador2 inicia en uno porque es el tamaño del vector de las letras usadas
                //contador3 es la pocision de las letras usadas
                char[] matrizLetrasUsadas,valoresUsados= { };//Estas son las matrices para poner las letras usadas
                valoresUsados = new char[20];//Creo la matriz valoresUsados con 20 posiciones
                palabra = PalabraAleatoria(palabra);
                char[] PalabraEnVector = palabra.ToCharArray();
                LimpiarPantalla();
                char[] EspaciosConGuiones = new char[palabra.Length];
                for (int i = 0; i < palabra.Length; i++)//Este for rellena el vector con '_' y deja un espacio entre ellos
                    if (palabra[i]==' ')
                    {
                        EspaciosConGuiones[i] = ' ';
                    }
                    else
                    EspaciosConGuiones[i] = '_';
                correctas = 0;
                //Momento repetitivo while
                while (vidas >= 1)//Mientras las vidas sean mayores o iguales a uno
                {
                    matrizLetrasUsadas = new char[contador2];//se crea la matriz donde se pontran las letras usadas
                    bool siLaLetraEsMayorAuno = true;//Este valor cambiara cuando el usuario introdusca mas de un caracter
                    Console.WriteLine("LETRAS USADAS:                VIDAS ACTUALES: {0}            CORRECTAS: {1}",vidas,correctas);
                    for (int i = 0; i < contador3; i++) //Marcador de informacion de las letras usadas
                    {
                        
                        matrizLetrasUsadas[i] = valoresUsados[i];
                        Console.WriteLine("Letra numero {0} ", i + "= " + "'" + matrizLetrasUsadas[i] + "'");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Palabra a encontrar: ");
                    MostrarEspaciosEnBlanco(EspaciosConGuiones);
                    while (siLaLetraEsMayorAuno == true)//Empieza el while en true
                    {
                        Console.Write("\n ");
                        Console.Write("Escribe una letra: ");
                        letra = Console.ReadLine();
                        LimpiarPantalla();
                        for (int i = 0; i < numeros.Length; i++)
                        {
                            //letraPorCaracter = Convert.ToChar(letra);//Se guarda en letrasPorCaracter
                            if (letra==numeros[i])
                            {
                                Console.WriteLine("!!!No puedes usar numeros solo letras¡¡¡ (Pon un espacio para continuar)");
                                VolverAempezarWhile(siLaLetraEsMayorAuno);
                            }
                        }
                        if (letra=="" || letra == "")
                        {
                            Console.WriteLine("!!!No escribio nada¡¡¡ (Pon un espacio para continuar)");
                            VolverAempezarWhile(siLaLetraEsMayorAuno);
                        }
                        if (letra.Length > 1)//si el usuario introduce mas de un caracter, sale un mensaje de error
                        {
                            Console.WriteLine("!!!Solo debes poner una letra a la vez intenta denuevo¡¡¡ (Pon un espacio para continuar)");
                            VolverAempezarWhile(siLaLetraEsMayorAuno);
                        }
                        else//Si introdujo un caracter (una letra) 
                        {
                            letraPorCaracter = Convert.ToChar(letra);//Se guarda en letrasPorCaracter
                            valoresUsados[contador3] = letraPorCaracter;//Se guarda en el vectorUsados en la pocion del contador3
                            siLaLetraEsMayorAuno = false; //Se deja de ejecutar el while
                        }
                    }
                    for (int i = 0; i < EspaciosConGuiones.Length; i++)//For que analiza si ya esta la letra que se coloco
                    {
                        if (letraPorCaracter == EspaciosConGuiones[i])
                        {
                            Console.WriteLine("Esa letra ya esta!! Escribe otra  (Pon un espacio para continuar)");
                            Console.ReadKey();
                            contador++;//el contador suma una para no restar una vida
                        }
                        else
                        {
                            if (letraPorCaracter == PalabraEnVector[i])//si no esta repetida la letra ponerla en su posicion
                            {
                                EspaciosConGuiones[i] = letraPorCaracter;
                                contador++; //Contador suma una para no restar una vida 
                                correctas++;//Correctas suma la cantidad de veces que hay de cada letra
                            }
                        }
                    }
                    if (contador == 0)//Para quitar la vida
                    {
                        vidas--;
                    }
                    if (correctas == palabra.Length) //Si la cantidad de correctas es la cantidad de letras que hay en la palabra
                        break; //No hacer nada
                    else 
                        contador = 0;//Pero ponerme el valor de contador en cero para continuar jugando
                    contador2++;
                    contador3++;
                }
                if (correctas == palabra.Length)//Si son iguales la cantidad de letras de la palabra y la cantidad de letras correctas
                {
                    MostrarEspaciosEnBlanco(EspaciosConGuiones);//se muestra la palabra oculta
                    Console.WriteLine();//Ganastes el juego
                    Console.WriteLine("Lo lograste la palabra es {0} ganaste!! quieres volver a jugar : S / N", palabra);
                    volverAjugar = Console.ReadLine();
                    if (volverAjugar == "n" || volverAjugar == "N") 
                        juegoActivo = false;
                    else 
                        vidas = 3;//Si el usuario dice que si vidas es igual a 3 y el while reinicia
                }
                else
                {
                    Console.WriteLine("Ya no tines mas intentos el juego TERMINO la palabra era {0} quieres juegar de nuevo : S /  N", palabra);
                    volverAjugar = Console.ReadLine();
                    if (volverAjugar == "n" || volverAjugar == "N") 
                        juegoActivo = false;
                    else 
                        vidas = 3;//Si el usuario dice que si vidas es igual a 3 y el while reinicia
                }
            }
            static void LimpiarPantalla()
            {
                Console.Clear();
                mensajeBienvenida();
                Console.WriteLine();
            }//Modulo que limpia y pone el menu
            static void mensajeBienvenida()
            {
                Console.Write("\n***************BIENVENIDO AL JUEGO EL AHORCADO POR CONSOLA***************\n\n" +
                "\n************REGLAS DEL JUEGO************" +
                "\n***1.Escribir solo una letra por intento***" +
                "\n***2.Solo tienes TRES vidas             ***\n\n" +
                "\n-------PALABRA GENERADA 'A JUGAAAAR'-------\n");
            }//Menu de bienvenida
            static string PalabraAleatoria(string palabra)
            {
                string[] palabras = new string[16] { "camion", "computador", "leche", "jhohann", "vaca", "juan", "santiago", "universidad", "hermoza", "novia", "tarro", "perro", "daniela", "internet", "codigo", "programacion" };
                Random NumeroAleatorio = new Random();
                palabra = palabras[NumeroAleatorio.Next(16)];
                return palabra;
            }//Modulo que escoje la palabra aleatoria
            static void MostrarEspaciosEnBlanco(char[] Espacios)
            {
                for (int i = 0; i < Espacios.Length; i++)
                {
                    Console.Write(Espacios[i] + " ");
                }
            }//Modulo que pones los espacios en blanco entre guines
            static void VolverAempezarWhile(bool siLaLetraEsMayorAuno)
            {
                Console.ReadKey();
                siLaLetraEsMayorAuno = true;//Se deja de ejecutar el while
            }//Modulo para volver a empesar el while de la validacion de la letra
        }
