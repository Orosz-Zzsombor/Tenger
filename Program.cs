using System;

namespace ConsoleApp16
{
    class Program
    {

        static void Main(string[] args)
        {
            const char TENGER_JEL = '*';
            const char SZIGET_JEL = 'O';
            const char HAJO_JEL = '█';
            const int SZIGETEK_SZAMA = 30;
            const int SOROK_SZAMA = 20;
            const int OSZLOPOK_SZAMA = 60;
            char[,] tenger = new char[SOROK_SZAMA, OSZLOPOK_SZAMA];

            int szigetekSzama = 0;
            int tengerSzele = 0;
            bool kozosSziget = false;

            for (int sorIndex = 0; sorIndex < tenger.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < tenger.GetLength(1); oszlopIndex++)
                {
                    tenger[sorIndex, oszlopIndex] = TENGER_JEL;
                }
            }
            Random vel = new Random();
            for (int i = 0; i < SZIGETEK_SZAMA; i++)
            {
                tenger[vel.Next(tenger.GetLength(0)), vel.Next(tenger.GetLength(1))] = SZIGET_JEL;
            }
            Megjelenit(tenger);

            for (int sorIndex = 0; sorIndex < tenger.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < tenger.GetLength(1); oszlopIndex++)
                {
                    if (tenger[sorIndex, oszlopIndex] == SZIGET_JEL)
                    {
                        szigetekSzama++;


                        


                        if (sorIndex == 0 || oszlopIndex == 0 || sorIndex == SOROK_SZAMA - 1 || oszlopIndex == OSZLOPOK_SZAMA - 1)
                        {
                            tengerSzele++;
                            continue;
                        }

                        if (tenger[sorIndex - 1, oszlopIndex] == SZIGET_JEL || tenger[sorIndex, oszlopIndex - 1] == SZIGET_JEL || tenger[sorIndex - 1, oszlopIndex - 1] == SZIGET_JEL || tenger[sorIndex +1, oszlopIndex ] == SZIGET_JEL || tenger[sorIndex , oszlopIndex+1] == SZIGET_JEL || tenger[sorIndex+1, oszlopIndex + 1] == SZIGET_JEL)
                        {
                            kozosSziget= true;
                            break;
                        }

                    }




                }
            }

                //1) Hány sziget van a tengeren?

                Console.WriteLine($"A szigetek száma: {szigetekSzama}");
                //2) Hány sziget van a tenger szélén?
                Console.WriteLine($"A tenger széli szigetek {tengerSzele}");
                //3) Van-e olyan sziget, ami mellett közvetlenül másik sziget is van
                Console.WriteLine($"Egymás melleti szigetek száma: {kozosSziget}");
            }

            static void Megjelenit(char[,] terkep)
            {
                Console.Clear();
                for (int sorIndex = 0; sorIndex < terkep.GetLength(0); sorIndex++)
                {
                    for (int oszlopIndex = 0; oszlopIndex < terkep.GetLength(1); oszlopIndex++)
                    {
                        Console.Write(terkep[sorIndex, oszlopIndex]);
                    }
                    Console.WriteLine();
                }
            }
        
        }
    }

