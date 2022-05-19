using System;
using System.Collections;


namespace ConsoleApp1
{
    class Simple
    {


        static void Main(string[] args)
        {
            colores();
            JuegoAhorcado();
            Console.ReadKey();
        }

        public static string CadenaMasGrandeBiologist(string ADN1, string ADN2)
        {
            /*
             * bool iniciarJuego = true;
            do
            {
                Console.Clear();
                string volverAjugar;
                Console.Write("\n***************BIENVENIDO A LA APLICACIÓN EL BIOLOGO***************\n" +
                "\n************REGLAS DEL JUEGO************" +
                "\n***1.Eres un biólogo que examina secuencias de ADN de formas de vida diferentes. ***" +
                "\n***Debes escribir dos secuencias de ADN, y el objetivo es encontrar el conjunto ***" +
                "\n***ordenado de bases adyacentes de mayor tamaño que es común en ambos ADNs.***\n" +
                "\n***2.Las secuencias de ADN se darán como conjuntos ordenados de bases de nucleótidos: adenina (abreviado A), citosina (C), guanina (G) y timina (T)***\n" +
                "\n***ATGTCTTCCTCGA TGCTTCCTATGAC***" +
                "\n-------Para el ejemplo anterior, el resultado es CTTCCT porque que es el conjunto ordenado de bases adyacentes de mayor tamaño que se encuentra en ambas formas de vida.-------   \n\n");
                Console.WriteLine("**EMPECEMOS**\n");
                Console.WriteLine("__Ingresa la primer cadena__");
                string ADN1 = Console.ReadLine();
                Console.WriteLine("__Ingresa la segunda cadena__");
                string ADN2 = Console.ReadLine();
                Console.WriteLine("__La cadena encontrada mas grande es: __");
                Console.WriteLine(CadenaMasGrandeBiologist(ADN1,ADN2));
                //string ADN1 = "ctgggccttgaggaaaactg";
                //string ADN2 = "gtaccagtactgatagt";
                Console.WriteLine("Quieres juegar de nuevo : S /  N");
                volverAjugar = Console.ReadLine();
                 if (volverAjugar == "n" || volverAjugar == "N") iniciarJuego = false;
            } while (iniciarJuego == true);
            */
            string mayor = "", menor = "";
            if (ADN1.Length > ADN2.Length)
            {
                mayor = ADN1;
                menor = ADN2;
            }
            else
            {
                mayor = ADN2;
                menor = ADN1;
            }
            int Empezar = 0;
            int Maximo = 0;
            for (int i = 0; i < menor.Length; i++)
            {
                for (int j = 0; j < mayor.Length; j++)
                {
                    int posicionAnterior = 0;
                    while (menor[i + posicionAnterior] == mayor[j + posicionAnterior])
                    {
                        posicionAnterior++;
                        if ((i + posicionAnterior >= menor.Length) || (j + posicionAnterior >= mayor.Length)) break;
                    }
                    if (posicionAnterior > Maximo)
                    {
                        Maximo = posicionAnterior;
                        Empezar = i;
                    }
                }
            }
            return menor.Substring(Empezar, Maximo);
        }
        public static void ELBiologo()
        {
            //string ADN1 = "ctgactga";
            //string ADN2 = "actgagc";
            //string ADN1 = "cgtaattgcgat";
            //string ADN2 = "cgtacagtagc";
            string ADN1 = "ctgggccttgaggaaaactg";
            string ADN2 = "gtaccagtactgatagt";
            string mayor = "", menor = "";
            string analizar = "";
            char[] salida = { };
            int contador = 1;
            bool encontrado = true;
            ArrayList cadenasEncontradas;
            cadenasEncontradas = new ArrayList();
            if (ADN1.Length > ADN2.Length)
            {
                mayor = ADN1;
                menor = ADN2;
            }
            else
            {
                mayor = ADN2;
                menor = ADN1;
            }
            do
            {
                for (int i = 0; i < menor.Length; i++)
                {
                    char[] comparacion = new char[contador];
                    if (contador != 1)
                    {
                        for (int j = 0; j < contador - 1; j++)
                        {
                            comparacion[j] = analizar[j];
                        }
                    }
                    comparacion[i] = menor[i];
                    analizar = new string(comparacion);
                    if (encontrado == mayor.Contains(analizar))
                    {
                        Console.WriteLine(analizar);
                        cadenasEncontradas.Add(analizar);
                    }
                    contador++;
                }

            } while (contador == menor.Length);

            Console.WriteLine("hoal");
            for (int p = 0; p < cadenasEncontradas.Count; p++)
            {
                analizar = (string)cadenasEncontradas[p];
                cadenasEncontradas[p] = analizar;
                Console.WriteLine(cadenasEncontradas[p]);
            }



        }
        public static void JuegoAhorcado()
        {
            bool juegoActivo = true;
            string palabra = "";
            int vidas = 3;
            string letra = "";
            int correctas = 0;
            int contador = 0;
            char letraPorCaracter = ' ';
            string volverAjugar = "";
            string[] numeros = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            mensajeBienvenida();
            while (juegoActivo == true)
            {
                int contador2 = 1, contador3 = 0;//Contador2 inicia en uno porque es el tamaño del vector de las letras usadas
                //contador3 es la pocision de las letras usadas
                char[] matrizLetrasUsadas, valoresUsados = { };//Estas son las matrices para poner las letras usadas
                valoresUsados = new char[20];//Creo la matriz valoresUsados con 20 posiciones
                palabra = PalabraAleatoria(palabra);
                char[] PalabraEnVector = palabra.ToCharArray();
                LimpiarPantalla();
                char[] EspaciosConGuiones = new char[palabra.Length];
                for (int i = 0; i < palabra.Length; i++)//Este for rellena el vector con '_' y deja un espacio entre ellos
                    if (palabra[i] == ' ')
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
                    Console.WriteLine("LETRAS USADAS:                VIDAS ACTUALES: {0}            CORRECTAS: {1}", vidas, correctas);
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
                            if (letra == numeros[i])
                            {
                                Console.WriteLine("!!!No puedes usar numeros solo letras¡¡¡ (Pon un espacio para continuar)");
                                VolverAempezarWhile(siLaLetraEsMayorAuno);
                            }
                        }
                        if (letra == "" || letra == "")
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
        public static void MenuQueOperaArreglos()
        {
            string letra, letra2;
            int[] A = { }, B = { }, C = { };
            int tamaño = 0, opcion = 0;
            Console.Write("\nPrograma que hace operaciones entre las posiones de los arreglos: ");
            Console.Write("\nIndique el Tamaño de los arreglos en general: ");
            tamaño = int.Parse(Console.ReadLine());

            menu();
            opcion = int.Parse(Console.ReadLine());
            do
            {
                if (opcion == 1)
                {
                    Console.Clear();
                    string letra3 = "A";
                    A = vertorRandom(tamaño);
                    asignarLetraAlVector(A, letra3, tamaño);
                    menu();
                    opcion = int.Parse(Console.ReadLine());
                }
                if (opcion == 2)
                {
                    Console.Clear();
                    string letra3 = "B";
                    B = vertorRandom(tamaño);
                    asignarLetraAlVector(B, letra3, tamaño);
                    menu();
                    opcion = int.Parse(Console.ReadLine());
                    do
                    {
                        if (opcion == 3)
                        {
                            Console.Clear();
                            letra3 = "C";
                            string operador = "+";
                            C = new int[tamaño];
                            sumaYimpresionVectorC(A, B, C, operador, letra3, tamaño);
                            menu();
                            opcion = int.Parse(Console.ReadLine());
                        }
                        if (opcion == 4)
                        {
                            Console.Clear();
                            letra3 = "C";
                            string operador = "-";
                            C = new int[tamaño];
                            sumaYimpresionVectorC(A, B, C, operador, letra3, tamaño);
                            menu();
                            opcion = int.Parse(Console.ReadLine());
                        }
                    } while (opcion == 3 || opcion == 4);
                }
                if (opcion == 5)
                {
                    menu2();
                    letra = Console.ReadLine();
                    letra2 = letra.ToUpper();
                    do
                    {
                        switch (letra2)
                        {
                            case "A":
                                Console.Clear();
                                Console.WriteLine("Vector A");
                                MostarVectores(A, tamaño);
                                Console.WriteLine("\n\n");
                                menu2();
                                letra = Console.ReadLine();
                                letra2 = letra.ToUpper();
                                break;
                            case "B":
                                Console.Clear();
                                Console.WriteLine("Vector B");
                                MostarVectores(B, tamaño);
                                Console.WriteLine("\n\n");
                                menu2();
                                letra = Console.ReadLine();
                                letra2 = letra.ToUpper();
                                break;
                            case "C":
                                Console.Clear();
                                Console.WriteLine("Vector C");
                                MostarVectores(C, tamaño);
                                Console.WriteLine("\n\n");
                                menu2();
                                letra = Console.ReadLine();
                                letra2 = letra.ToUpper();
                                break;
                            case "D":
                                Console.Clear();
                                Console.WriteLine("Vector A");
                                MostarVectores(A, tamaño);
                                Console.WriteLine("\n\nVector B");
                                MostarVectores(B, tamaño);
                                Console.WriteLine("\n\nVector C");
                                MostarVectores(C, tamaño);
                                Console.WriteLine("\n\n");
                                menu2();
                                letra = Console.ReadLine();
                                letra2 = letra.ToUpper();
                                break;
                            case "E":

                                Console.Clear();
                                menu();
                                opcion = int.Parse(Console.ReadLine());
                                break;
                            default:
                                break;
                        }
                    } while (letra2 == "A" || letra2 == "B" || letra2 == "C" || letra2 == "D");

                }
                if (opcion == 6)
                {
                    Environment.Exit(0);
                }
            } while (opcion == 1 || opcion == 2 || opcion == 5 || opcion == 6);
            static void menu()
            {
                Console.Write("ESCOGE UNA OPCION************" +
                "\n1. Llenar Vector A de manera aleatoria." +
                "\n2.Llenar Vector B de manera aleatoria." +
                "\n3.Realizar C = A + B." +
                "\n4.Realizar C = B - A." +
                "\n5.Mostrar(Permitiendo al usuario elegir entre el Vector A, B, o C)." +
                "\n6.Salir.\n\n" +
                "\nQue opcion eliges ? ..... ");
            }
            static void menu2()
            {
                Console.Write("\nELIGE CUAL VECTOR QUIERES VER !!!" +
                "\nA.Escribe la letra 'A' si quieres ver el vector A." +
                "\nB.Escribe la letra 'B' si quieres ver el vector B." +
                "\nC.Escribe la letra 'C' si quieres ver el vector C." +
                "\nD.Mostrar(los vectores juntos A, B, o C)" +
                "\nE.Regresar al menu principal....\n\n");
            }
            static int[] vertorRandom(int tamaño)
            {
                int[] Vect = new int[tamaño];
                for (int i = 0; i < tamaño; i++)
                {
                    Random rnd = new Random();
                    int NumerosAleatorios = rnd.Next(-100, 100);
                    Vect[i] = NumerosAleatorios;
                }
                return Vect;
            }
            static void asignarLetraAlVector(int[] A, string letra, int tamaño)
            {
                Console.Write($"El arreglo '{letra}' ya se creo, Queda asi: ");
                for (int i = 0; i < tamaño; i++)
                {
                    Console.Write(A[i] + " ");
                }
                Console.Write("\n\n\n\n");
            }
            static void sumaYimpresionVectorC(int[] A, int[] B, int[] C, string operador, string letra, int tamaño)
            {
                if (operador == "+")
                {
                    for (int i = 0; i < tamaño; i++)
                    {
                        C[i] = A[i] + B[i];
                    }
                    Console.Write($"El arreglo '{letra}' = 'A' + 'B' ya se creo, Queda asi: ");
                    for (int i = 0; i < tamaño; i++)
                    {
                        Console.Write(C[i] + " ");
                    }
                    Console.Write("\n\n\n\n");
                }
                if (operador == "-")
                {
                    for (int i = 0; i < tamaño; i++)
                    {
                        C[i] = A[i] - B[i];
                    }
                    Console.Write($"El arreglo '{letra}' = 'A' - 'B' ya se creo, Queda asi: ");
                    for (int i = 0; i < tamaño; i++)
                    {
                        Console.Write(C[i] + " ");
                    }
                    Console.Write("\n\n\n\n");
                }
            }
            static void MostarVectores(int[] vector, int tamaño)
            {
                for (int i = 0; i < tamaño; i++)
                {
                    Console.Write(vector[i] + " ");
                }
            }
        }
        public static void CreacionDEarreglosConMultiplos(int tamaño, int numeroM, int[] miarreglo)
        {
            /*
            int tamaño = 0,numeroM = 0;
            Console.Write("\nIndique el numero al cual le encontraremos los multiplos: ");
            numeroM = int.Parse(Console.ReadLine());
            Console.Write("\nIndique el Tamaño del Arreglo que tendra la cantidad de multiplos del numero: ");
            tamaño = int.Parse(Console.ReadLine());
            Console.WriteLine();
            //declarar y crear el arreglo
            int[] miarreglo = new int[tamaño];
            //asignar datos
            CreacionDEarreglosConMultiplos(tamaño, numeroM, miarreglo);
            */
            int numeroAmultiplicar = 1;
            for (int i = 0; i < tamaño; i++)
            {
                int multiplo;
                multiplo = numeroM * numeroAmultiplicar;
                miarreglo[i] = multiplo;
                numeroAmultiplicar++;
            }
            //visualizar los elementos del arreglo
            Console.Write("\nElementos del arreglo de multiplos\n");
            Console.WriteLine();
            for (int i = 0; i < tamaño; i++)
            {
                Console.Write(miarreglo[i] + " ");
            }
        }
        public static void CreacionDEarreglos(int tamaño, int[] miarreglo)
        {
            /*
            int tamaño = 0;
            Console.Write("\nIndique el Tamaño del Arreglo: ");
            tamaño = int.Parse(Console.ReadLine());
            Console.WriteLine();
            //declarar y crear el arreglo
            int[] miarreglo = new int[tamaño];
            //asignar datos
            CreacionDEarreglos(tamaño, miarreglo);
            */
            for (int i = 0; i < tamaño; i++)
            {
                Console.Write("miarreglo[" + i + "] = ");
                miarreglo[i] = int.Parse(Console.ReadLine());
            }
            //visualizar los elementos del arreglo
            Console.Write("\nElementos del arreglo\n");
            Console.WriteLine();
            for (int i = 0; i < tamaño; i++)
            {
                Console.Write(miarreglo[i] + " ");
            }
        }
        public static long SumaDesendente(long nn1)
        {
            /*
             * //Declaro Variables
            long n1, cantidad, numero, p1, p2, p3, p4, p5, p6, p7, p8, p9, resultado;
            //ingreso el numero
            n1 = long.Parse(Console.ReadLine());
            numero = n1;
            //Metodo para contar las cifras del numero y cantidad es igual a la cantidad de cifras
            cantidad = SumaDesendente(n1);
            if (cantidad == 3)
            {
                p1 = numero % 100;
                p2 = p1 % 10;
                resultado = numero + p1 + p2;
                Console.WriteLine(resultado);
            }
            if (cantidad == 4)
            {
                p1 = numero % 1000;
                p2 = p1 % 100;
                p3 = p2 % 10;
                resultado = numero + p1 + p2 + p3;
                Console.WriteLine(resultado);
            } else if (cantidad == 5)
            {
                p1 = numero % 10000;
                p2 = p1 % 1000;
                p3 = p2 % 100;
                p4 = p3 % 10;
                resultado = numero + p1 + p2 + p3 + p4;
                Console.WriteLine(resultado);
            } else if (cantidad == 6)
            {
                p1 = numero % 100000;
                p2 = p1 % 10000;
                p3 = p2 % 1000;
                p4 = p3 % 100;
                p5 = p4 % 10;
                resultado = numero + p1 + p2 + p3 + p4 + p5;
                Console.WriteLine(resultado);
            } else if (cantidad == 7)
            {
                p1 = numero % 1000000;
                p2 = p1 % 100000;
                p3 = p2 % 10000;
                p4 = p3 % 1000;
                p5 = p4 % 100;
                p6 = p5 % 10;
                resultado = numero + p1 + p2 + p3 + p4 + p5 + p6;
                Console.WriteLine(resultado);
            } else if (cantidad == 8)
            {
                p1 = numero % 10000000;
                p2 = p1 % 1000000;
                p3 = p2 % 100000;
                p4 = p3 % 10000;
                p5 = p4 % 1000;
                p6 = p5 % 100;
                p7 = p6 % 10;
                resultado = numero + p1 + p2 + p3 + p4 + p5 + p6 + p7;
                Console.WriteLine(resultado);
            } else if (cantidad == 9)
            {
                p1 = numero % 100000000;
                p2 = p1 % 10000000;
                p3 = p2 % 1000000;
                p4 = p3 % 100000;
                p5 = p4 % 10000;
                p6 = p5 % 1000;
                p7 = p6 % 100;
                p8 = p7 % 10;
                resultado = numero + p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8;
                Console.WriteLine(resultado);
            } else if (cantidad == 9)
            {
                p1 = numero % 1000000000;
                p2 = p1 % 100000000;
                p3 = p2 % 10000000;
                p4 = p3 % 1000000;
                p5 = p4 % 100000;
                p6 = p5 % 10000;
                p7 = p6 % 1000;
                p8 = p7 % 100;
                p9 = p8 % 100;
                resultado = numero + p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9;
                Console.WriteLine(resultado);
            }
            */
            long contador;
            contador = 0;
            while (nn1 > 0)
            {
                nn1 = nn1 / 10;
                contador = contador + 1;
            }
            return contador;
        }
        public static void colores()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

        }
        public class calculadora
        {
            /*
             * //Declaro variables
            int resultado,A,B,opcion;
            //encabezado
            Console.WriteLine("CALCULADORA DE CONSOLA");
            //Leo los datos
            Console.WriteLine("MENU:\n" +
                "1. Suma\n2. Resta\n3. Multiplicaciòn\n4. Diviciòn");
            //nro1 = int.Parse(Console.ReadLine());
            Console.WriteLine("QUE OPERACIÒN VAS HACER?");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine("PON EL PRIMER NUMERO");
            A = int.Parse(Console.ReadLine());
            Console.WriteLine("PON EL SEGUNDO NUMERO");
            B = int.Parse(Console.ReadLine());
            resultado = 0;
            //Ejecuto el modulo segun la opciòn
            switch (opcion)
            {
                case 1:
                    {
                        resultado = calculadora.suma(A,B);
                        break;
                    }
                case 2:
                    {
                        resultado = calculadora.resta(A, B);
                        break;
                    }
                case 3:
                    {
                        resultado = calculadora.multiplicacion(A, B);
                        break;
                    }
                case 4:
                    {
                        resultado = calculadora.division(A, B);
                        break;
                    }
            }
            //Salida
            Console.WriteLine("LA OPERACIÒN QUE ESTAS HACIENDO ENTRE " + A + " Y " + B + " DA COMO RESULTADO " + resultado);
            */
            public static int suma(int n1, int n2)
            {
                return n1 + n2;
            }
            public static int resta(int n1, int n2)
            {
                return n1 - n2;
            }
            public static int multiplicacion(int n1, int n2)
            {
                return n1 * n2;
            }
            public static int division(int n1, int n2)
            {
                return n1 / n2;
            }

            /*
            //encabezado
            Console.WriteLine("CALCULADORA DE CONSOLA");
            //declarar variables
            int A, B, opcion, resultado;
            //leer datos
            Console.WriteLine("MENU:\n" +
                "1. Suma\n2. Resta\n3. Multiplicaciòn\n4. Diviciòn");
            //nro1 = int.Parse(Console.ReadLine());
            Console.WriteLine("QUE OPERACIÒN VAS HACER?");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine("PON EL PRIMER NUMERO");
            A = int.Parse(Console.ReadLine());
            Console.WriteLine("PON EL SEGUNDO NUMERO");
            B = int.Parse(Console.ReadLine());
            resultado = 0;
            switch (opcion)
            {
                case 1:
                    {
                        resultado = A + B;
                        break;
                    }
                case 2:
                    {
                        resultado = A - B;
                        break;
                    }
                case 3:
                    {
                        resultado = A * B;
                        break;
                    }
                case 4:
                    {
                        resultado = A / B;
                        break;
                    }
            }
            Console.WriteLine("LA OPREACION QUE ESTAS HACIENDO ES " + A + " Y " + B + " DA COMO RESULTADO " + resultado);
            */
        }
        public static void invertirNumero()
        {
            //declarar variables
            int nro1, A, B, C, nroIV;
            //leer datos
            Console.WriteLine("PON UN NUMERO DE TRES CIFRAS");
            nro1 = int.Parse(Console.ReadLine());

            A = nro1 / 100;
            nro1 = nro1 % 100;
            B = nro1 / 10;
            C = nro1 % 10;
            nroIV = ((C * 100) + (B * 10) + (A));
            string p1 = ("ahora si\n");
            string p2 = (@"estoy haciendo una\\pequeña pueba");

            Console.WriteLine("FELICIDADES EL NUMERO INVERTIDO ES " + nroIV);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
        public static void buscarMayor()
        {
            //encabezado
            Console.WriteLine("ESTA APLICACIÒN ENCUENTRA EL NUMERO MAYOR ENTRE TRES NUMEROS");
            //declarar variables
            int nro1, nro2, nro3;
            //leer datos
            Console.WriteLine("PON EL PRIMER NUMERO");
            nro1 = int.Parse(Console.ReadLine());
            Console.WriteLine("PON EL SEGUNDO NUMERO");
            nro2 = int.Parse(Console.ReadLine());
            Console.WriteLine("PON EL TERCER NUMERO");
            nro3 = int.Parse(Console.ReadLine());
            //procesos
            if (nro1 > nro2 && nro1 > nro3)
            {
                Console.WriteLine("EL NUMERO MAYOR ES " + nro1);
            }
            if (nro2 > nro1 && nro2 > nro3)
            {
                Console.WriteLine("EL NUMERO MAYOR ES " + nro2);
            }
            if (nro3 > nro1 && nro3 > nro2)
            {
                Console.WriteLine("EL NUMERO MAYOR ES " + nro3);
            }

        }
        public static void mayorAmenor()
        {
            //encabezado
            Console.WriteLine("ESTA APLICACIÒN ORDENA TRES NUMERO DE MAYOR A MENOR");
            //declarar variables
            int nro1, nro2, nro3, Myor, Mdio, Mnor;
            //leer datos
            Console.WriteLine("PON EL PRIMER NUMERO");
            nro1 = int.Parse(Console.ReadLine());
            Console.WriteLine("PON EL SEGUNDO NUMERO");
            nro2 = int.Parse(Console.ReadLine());
            Console.WriteLine("PON EL TERCER NUMERO");
            nro3 = int.Parse(Console.ReadLine());
            Myor = 0;
            Mdio = 0;
            Mnor = 0;
            //procesos
            if (nro1 > nro2 && nro1 > nro3)
            {
                Myor = nro1;
            }
            else
            {
                if (nro2 > nro1 && nro2 > nro3)
                {
                    Myor = nro2;
                }
                else
                {
                    if (nro3 > nro1 && nro3 > nro2)
                    {
                        Myor = nro3;
                    }
                }
            }

            if (nro1 < nro2 && nro1 < nro3)
            {
                Mnor = nro1;
            }
            else
            {
                if (nro2 < nro1 && nro2 < nro3)
                {
                    Mnor = nro2;
                }
                else
                {
                    if (nro3 < nro1 && nro3 < nro2)
                    {
                        Mnor = nro3;
                    }
                }
            }

            if (nro1 != Myor && nro1 != Mnor)
            {
                Mdio = nro1;
            }
            else
            {
                if (nro2 != Myor && nro2 != Mnor)
                {
                    Mdio = nro2;
                }
                else
                {
                    if (nro3 != Myor && nro3 != Mnor)
                    {
                        Mdio = nro3;
                    }
                }
            }

            Console.WriteLine("EL ORDEN ADECUADO DE LOS TRES NUMEROS ES " + Myor + Mdio + Mnor);


        }
        public static void try1()
        {
            Console.WriteLine("ESCRIBE UN NUMERO");
            string valorIngresado = Console.ReadLine();
            //Este condigo es para tener presente los errores del usurio para que nuestro programa cargue bien
            try
            {
                int valorComoInt = int.Parse(valorIngresado);
            }
            catch (FormatException)
            {
                Console.WriteLine("EL CARACTER O EL VALOR INGRESADO ES INCORRECTO");
            }
            catch (OverflowException)
            {
                Console.WriteLine("EL TAMAÑO DEL NUMERO INGRESADO ES DEMACIODO GRANDE O DEMACIADO CORTO");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("NO HAS INGRESADO NINGUN VALOR");
            }
            finally
            {
                Console.WriteLine("ESTE MENSAJE SE MOSTRARA SIEMPRE COMO PRUEBA");
            }
        }
        public static void AhorInt()
        {
            string[,] matriz = new string[8, 6];
            string palabra = "null";
            bool jugar = true;
            int intentos = 0;
            string letra = " ";
            char Letrachar = ' ';
            string volverjugar = " ";
            int Gano = 0;
            int contador = 0; // para saber si la letra que se escrivio si estaba en la palabra
            while (jugar == true)
            {
                palabra = escojerPalabra(palabra);
                char[] palabravector = palabra.ToCharArray();
                char[] espaciosEnBlanco = new char[palabra.Length];
                for (int i = 0; i < palabra.Length; i++) espaciosEnBlanco[i] = '_';
                Gano = 0;
                while (intentos <= 6)
                {
                    bool letraMayorQueUno = true; // para saber si la letra ingresadda fue solo una y si se puede convertir en char
                    tablero(matriz, intentos);
                    MostrarMatriz(matriz);
                    Console.WriteLine();
                    MostrarEpaciosEnBlanco(espaciosEnBlanco);
                    Console.WriteLine();
                    while (letraMayorQueUno == true)
                    {
                        Console.Write("dijite la letra: ");
                        letra = Console.ReadLine();
                        if (letra.Length == 1)
                        {
                            Letrachar = Convert.ToChar(letra);
                            letraMayorQueUno = false;
                        }
                    }

                    for (int i = 0; i < espaciosEnBlanco.Length; i++)
                    {
                        if (Letrachar == espaciosEnBlanco[i])
                        {
                            Console.WriteLine("esa letra ya estaba escrivir otra");
                            Console.ReadKey();
                            contador++;
                        }
                        else
                        {
                            if (Letrachar == palabravector[i])
                            {
                                espaciosEnBlanco[i] = Letrachar;
                                contador++;
                                Gano++;
                            }
                        }
                    }
                    if (contador == 0)
                    {
                        intentos++;
                    }
                    if (Gano == palabra.Length) break;
                    else contador = 0;
                }
                if (Gano == palabra.Length)
                {
                    tablero(matriz, intentos);
                    MostrarMatriz(matriz);
                    Console.WriteLine();
                    MostrarEpaciosEnBlanco(espaciosEnBlanco);
                    Console.WriteLine();
                    Console.WriteLine("Si la palabra era {0} ganaste!! quieres volver a jugar : S / N", palabra);
                    volverjugar = Console.ReadLine();
                    if (volverjugar == "n") jugar = false;
                    else intentos = 0;

                }
                else
                {
                    Console.WriteLine("se te acabaron los intentos la palabra era {0} quieres juegar de nuevo : S /  N", palabra);
                    volverjugar = Console.ReadLine();
                    if (volverjugar == "n") jugar = false;

                    else intentos = 0;
                }

            }
            static void MostrarEpaciosEnBlanco(char[] Espacios)
            {
                for (int i = 0; i < Espacios.Length; i++)
                {
                    Console.Write(Espacios[i] + " ");
                }
            }
            static string[,] tablero(string[,] matriz, int intentos)
            {
                Console.Clear();
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int k = 0; k < matriz.GetLength(1); k++)
                    {
                        matriz[i, k] = " ";
                    }
                }
                for (int i = 0; i < 6; i++) matriz[0, i] = "_";
                for (int k = 1; k < 7; k++) matriz[k, 1] = "|";
                for (int j = 0; j < 6; j++) matriz[7, j] = "_";
                if (intentos >= 1) matriz[3, 4] = "O";
                if (intentos >= 2) matriz[4, 4] = "|";
                if (intentos >= 3) matriz[5, 3] = "/";
                if (intentos >= 4) matriz[5, 5] = "l";
                if (intentos >= 5) matriz[4, 3] = "-";
                if (intentos >= 6) matriz[4, 5] = "-";
                matriz[1, 4] = "|";
                matriz[2, 4] = "|";
                return matriz;
            }
            static void MostrarMatriz(string[,] matriz)
            {
                int pasarcolumnna = 0;
                int pasarfila = 0;
                while (pasarfila <= 7)
                {
                    while (pasarcolumnna <= 5)
                    {
                        Console.Write(matriz[pasarfila, pasarcolumnna]);
                        pasarcolumnna++;
                        if (pasarcolumnna > 5) Console.WriteLine();
                    }
                    pasarcolumnna = 0;
                    pasarfila++;
                }

            }
            static string escojerPalabra(string palabra)
            {
                string[] palabras = new string[16] { "camion", "computador", "leche", "vino", "vaca", "mula", "lis", "quiero", "hermoza", "novia", "tarro", "perro", "uva", "internet", "codigo", "programacion" };
                Random nroaleatorio = new Random();
                palabra = palabras[nroaleatorio.Next(10)];
                return palabra;
            }
        }
        public static void mcmTresNumeros()
        {
            int M1, M2, M3, mcd, c, mcm;
            M1 = int.Parse(Console.ReadLine());
            M2 = int.Parse(Console.ReadLine());
            M3 = int.Parse(Console.ReadLine());

            c = 2;
            mcd = 1;

            while (c <= M1 && c <= M2 && c <= M3)
            {
                while (M1 % c == 0 && M2 % c == 0 && M3 % c == 0)
                {
                    mcd = mcd * c;
                    M1 = M1 * c;
                    M2 = M2 * c;
                    M3 = M3 * c;

                }
                c = c + 1;
            }
            mcm = (M1 * M2 * M3) / mcd;
            Console.WriteLine(mcd.ToString() + mcm);
        }
        public static void MCMtresNumeros()
        {
            //Entradas
            int m1, m2, m3, a, b, c;
            int mayor, Mcm;
            m1 = Convert.ToInt32(Console.ReadLine());
            m2 = Convert.ToInt32(Console.ReadLine());
            m3 = Convert.ToInt32(Console.ReadLine());
            //Proceso
            mayor = m1;
            if (m2 > mayor)
                mayor = m2;
            if (m3 > mayor)
                mayor = m3;
            Mcm = mayor;
            a = Mcm % m1;
            b = Mcm % m2;
            c = Mcm % m3;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            while ((Mcm % m1 != 0) || (Mcm % m2 != 0) || (Mcm % m3 != 0))
            {
                Console.WriteLine(Mcm);
                Mcm = Mcm + 1;
            }

            //Salida

            Console.WriteLine(Mcm);
        }
        public static int Mayor(int n1, int n2)
        {
            /*
             * Este codigo hay que pegarlo en el main
             * //Declaro Variables
            int Numero1, Numero2, resultado;
            //Leo los datos
            Console.WriteLine("PON EL PRIMER NUMERO");
            Numero1=int.Parse(Console.ReadLine());
            Console.WriteLine("PON EL SEGUNDO NUMERO");
            Numero2 = int.Parse(Console.ReadLine());
            //Ejecuto el modulo
            resultado = Mayor(Numero1,Numero2);
            Console.WriteLine("EL NUMERO MAYOR ES EL "+resultado);
            */
            if (n1 > n2)
                return n1;
            else
                return n2;
            /*
            if (n1 > n2)
                Console.WriteLine("El numero mayor es {0}", n1);
            else
                Console.WriteLine("El numero mayor es {0}", n2);
            */
        }
        public static int IfMasCorto(int N1, int N2)
        {
            int Resultado;
            /*
             * **
             * int A, B,R;
            A = int.Parse(Console.ReadLine());
            B = int.Parse(Console.ReadLine());
            R = IfMasCorto(A, B);
            Console.WriteLine(R);
            ****
            if (N1 > N2)
            {
                Resultado = N1 + N2;
                return Resultado;
            }
            else
                return N1 - N2;
            */
            Resultado = N1 > N2 ? N1 + N2 : N1 - N2;
            return Resultado;
        }
        public class hola
        {
            public static void while1al10()
            {
                int a, b;
                a = 1;
                b = 11;
                while (a < b)
                {
                    Console.WriteLine(a);
                    a = a + 1;
                }
            }
            public static void Pares26al10()
            {
                int a, b;
                a = 26;
                b = 8;
                while (a > b)
                {
                    Console.WriteLine(a);
                    a = a - 2;
                }
            }
            public static void DoWhile1al10()
            {
                int a, b;
                a = 1;
                b = 11;
                do
                {
                    Console.WriteLine(a);
                    a = a + 1;
                } while (a < b);
            }
            public static void del15al5Desen()
            {
                for (int i = 15; i > 4; i--)
                {
                    Console.WriteLine(i);
                }
            }
            public static void Primeros8pares()
            {
                for (int i = 2; i <= 16; i = i + 2)
                {
                    int p = 1;
                    Console.WriteLine("Numero " + p + "es el " + i);


                }
            }
        }
        public static String decimalHexadecimal(int numero)
        {

            char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F' };

            String hexadecimal = "";

            const int DIVISOR = 16;
            long resto = 0;

            for (int i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
            {
                resto = i % DIVISOR;
                Console.WriteLine(i);
                if (resto >= 10)
                {
                    hexadecimal = letras[resto - 10] + hexadecimal;

                }
                else
                {
                    hexadecimal = resto + hexadecimal;
                }
            }
            return hexadecimal;
        }
        public static int hexadecimalDecimal(String hexadecimal)
        {

            int numero = 0;

            const int DIVISOR = 16;

            for (int i = 0, j = hexadecimal.Length - 1; i < hexadecimal.Length; i++, j--)
            {

                if (hexadecimal[i] >= '0' && hexadecimal[i] <= '9')
                {
                    numero += (int)Math.Pow(DIVISOR, j) * Convert.ToInt32(hexadecimal[i] + "");
                }
                else if (hexadecimal[i] >= 'A' && hexadecimal[i] <= 'F')
                {
                    numero += (int)Math.Pow(DIVISOR, j) * Convert.ToInt32((hexadecimal[i] - 'A' + 10) + "");
                }
                else
                {
                    return -1;
                }

            }

            return numero;

        }
        public static long decimalBinario(int numero)
        {

            long binario = 0;

            const int DIVISOR = 2;
            long digito = 0;

            for (int i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
            {
                digito = i % DIVISOR;
                binario += digito * (long)Math.Pow(10, j);
            }


            return binario;
        }
        public static void lecturaDeCaracter(string letras)
        {
            for (int i = 0; i < letras.Length; i++)
            {
                int a = letras[i];
                Console.WriteLine(a);
                //Console.WriteLine(letras.Length);
                //Console.WriteLine(letras[i]);
            }
        }
        public static string BinarioaHexadecimal(long binario)
        {
            int numero = 0;
            int digito = 0;
            const int DIVISOR = 10;
            for (long i = binario, j = 0; i > 0; i /= DIVISOR, j++)
            {
                digito = (int)i % DIVISOR;
                if (digito != 1 && digito != 0)
                {
                    numero = numero - 1;
                }
                numero += digito * (int)Math.Pow(2, j);
            }
            //La variable numero hasta aqui es un numero decimal entero
            //return numero;
            char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F' };

            String hexadecimal = "";

            const int DIVISOR2 = 16;
            long resto = 0;

            for (int i = numero % DIVISOR2, j = 0; numero > 0; numero /= DIVISOR2, i = numero % DIVISOR2, j++)
            {
                resto = i % DIVISOR2;
                if (resto >= 10)
                {
                    hexadecimal = letras[resto - 10] + hexadecimal;

                }
                else
                {
                    hexadecimal = resto + hexadecimal;
                }
            }
            return hexadecimal;
        }
        public static long DecimalaOctal(long Decimal)
        {
            long p, q, Octal = 0;
            long DecimalNumero = Decimal;
            p = 1;
            for (q = DecimalNumero; q > 0; q = q / 8)
            {
                Octal = Octal + (q % 8) * p;
                p *= 10;
                DecimalNumero /= 8;
            }
            return Octal;
        }
        public static string DecimalaHexadecimal(long Decimal)
        {
            char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F' };
            String hexadecimal = "";
            const int DIVISOR2 = 16;
            long resto = 0;
            for (long i = Decimal % DIVISOR2, j = 0; Decimal > 0; Decimal /= DIVISOR2, i = Decimal % DIVISOR2, j++)
            {
                resto = i % DIVISOR2;
                if (resto >= 10)
                {
                    hexadecimal = letras[resto - 10] + hexadecimal;
                }
                else
                {
                    hexadecimal = resto + hexadecimal;
                }
            }
            return hexadecimal;
        }
        public static long OctalaBinario(long octal)
        {
            long numero = 0;
            long digito = 0;
            const int DIVISOR = 10;
            for (long i = octal, j = 0; i > 0; i /= DIVISOR, j++)
            {
                digito = (long)i % DIVISOR;
                if (!(digito >= 0 && digito <= 7))
                {
                    return -1;
                }
                numero += digito * (long)Math.Pow(8, j);
            }
            //return numero;
            //La variable numero es un decimal
            long binario = 0;
            const int DIVISOR2 = 2;
            long digito2 = 0;
            for (long i = numero % DIVISOR2, j = 0; numero > 0; numero /= DIVISOR2, i = numero % DIVISOR2, j++)
            {
                digito2 = i % DIVISOR2;
                binario += digito2 * (long)Math.Pow(10, j);
            }
            return binario;
        }
        public static long OctalaDecimal(long octal)
        {
            long numero = 0;
            long digito = 0;
            const int DIVISOR = 10;
            for (long i = octal, j = 0; i > 0; i /= DIVISOR, j++)
            {
                digito = (long)i % DIVISOR;
                if (!(digito >= 0 && digito <= 7))
                {
                    return -1;
                }
                numero += digito * (long)Math.Pow(8, j);
            }
            return numero;
        }
        public static string OctalaHexadecimal(long octal)
        {
            long numero = 0;
            long digito = 0;
            const int DIVISOR = 10;
            for (long i = octal, j = 0; i > 0; i /= DIVISOR, j++)
            {
                digito = (long)i % DIVISOR;
                if (!(digito >= 0 && digito <= 7))
                {
                    numero = numero - 1;
                }
                numero += digito * (long)Math.Pow(8, j);
            }
            //return numero;
            //La varible numero es el valor de octal a decimal
            //Ahora sigue cambiar el decimal a hexadecimal
            char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F' };
            String hexadecimal = "";
            const int DIVISOR2 = 16;
            long resto = 0;
            for (long i = numero % DIVISOR2, j = 0; numero > 0; numero /= DIVISOR2, i = numero % DIVISOR2, j++)
            {
                resto = i % DIVISOR2;
                if (resto >= 10)
                {
                    hexadecimal = letras[resto - 10] + hexadecimal;
                }
                else
                {
                    hexadecimal = resto + hexadecimal;
                }
            }
            return hexadecimal;
        }
        public static long HexadecimalaBinario(string hex)
        {
            long numero = 0;
            const int DIVISOR = 16;
            for (int i = 0, j = hex.Length - 1; i < hex.Length; i++, j--)
            {
                if (hex[i] >= '0' && hex[i] <= '9')
                {
                    numero += (long)Math.Pow(DIVISOR, j) * Convert.ToInt64(hex[i] + "");
                }
                else if (hex[i] >= 'A' && hex[i] <= 'F')
                {
                    numero += (long)Math.Pow(DIVISOR, j) * Convert.ToInt64((hex[i] - 'A' + 10) + "");
                }
                else
                {
                    numero = numero - 1;
                }
            }
            //return numero;
            //La varible numero es el valor de hexadecimal a decimal
            //Ahora sigue cambiar el decimal a binario
            long binario = 0;
            const int DIVISOR2 = 2;
            long digito = 0;
            for (long i = numero % DIVISOR2, j = 0; numero > 0; numero /= DIVISOR2, i = numero % DIVISOR2, j++)
            {
                digito = i % DIVISOR2;
                binario += digito * (long)Math.Pow(10, j);
            }
            return binario;
        }
        public static long HexadecimalaDecimal(string hex)
        {
            long numero = 0;
            const int DIVISOR = 16;
            for (int i = 0, j = hex.Length - 1; i < hex.Length; i++, j--)
            {
                if (hex[i] >= '0' && hex[i] <= '9')
                {
                    numero += (long)Math.Pow(DIVISOR, j) * Convert.ToInt64(hex[i] + "");
                }
                else if (hex[i] >= 'A' && hex[i] <= 'F')
                {
                    numero += (long)Math.Pow(DIVISOR, j) * Convert.ToInt64((hex[i] - 'A' + 10) + "");
                }
                else
                {
                    return -1;
                }
            }
            return numero;
        }
        public static long HexadecimalaOctal(string hex)
        {
            long numero = 0;
            const int DIVISOR = 16;
            for (int i = 0, j = hex.Length - 1; i < hex.Length; i++, j--)
            {
                if (hex[i] >= '0' && hex[i] <= '9')
                {
                    numero += (long)Math.Pow(DIVISOR, j) * Convert.ToInt64(hex[i] + "");
                }
                else if (hex[i] >= 'A' && hex[i] <= 'F')
                {
                    numero += (long)Math.Pow(DIVISOR, j) * Convert.ToInt64((hex[i] - 'A' + 10) + "");
                }
                else
                {
                    return -1;
                }
            }
            //return numero;
            //La variable numero es un decimal
            //ahora vamos a cambiar ese decimal por octal
            long p, q, Octal = 0;
            long DecimalNumero = numero;
            p = 1;
            for (q = DecimalNumero; q > 0; q = q / 8)
            {
                Octal = Octal + (q % 8) * p;
                p *= 10;
                DecimalNumero /= 8;
            }
            return Octal;
        }
    }
}
