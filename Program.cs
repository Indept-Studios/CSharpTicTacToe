//Tic Tac Toe
//geschrieben von Indept_studios


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CSharpTicTacToe
{

    class Program
    {
        //Variablen
        public static char PlayerToken;
        public static string Player1;
        public static string Player2;
        public static int Turn = 0;
        public static char[] Token = new char[] { 'X', '#' };
        public static char[] Field = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        // Haupt
        static void Main(string[] args)
        {
            Console.WriteLine( );
            Console.WriteLine("Willkommen bei Tic Tac Toe");
            Console.WriteLine("geschrieben von Indept_Studios 17.01.2018\n");
            Playerinitialization();
            Console.WriteLine("\nSehr schön " + Player1 + " & " + Player2);
            Console.WriteLine(Player1 + " du bist nun (X) " + Player2 + " du bist nun (#)");

            do //while(!IsWin() && Turn <= 8);
            {
                Board();
                Game();
            } while (!IsWin() && Turn <= 8);

            if (!IsWin()) //Es gibt keine if-Schleifen, sondern nur if-Abfragen!
            {
                Console.WriteLine("Tut mir leid, keiner hat gewonnen.");
            }

            else
            {
                Console.Clear();
                Console.WriteLine(GetCurrentPlayer() + " hat gewonnen, Herzlichen Glückwunsch");
            }

            Console.ReadKey();
        }// Main


        // Name des Spielers zurückgeben
        static string GetCurrentPlayer()
        {
            return PlayerToken == Token[0] ? Player1 : Player2;
        }// GetCurrentPlayer


        // Eigentliches Spiel
        private static void Game()
        {
            //Playerswitch
            PlayerToken = PlayerToken == Token[0] ? Token[1] : Token[0];
            


            Console.WriteLine(GetCurrentPlayer() + " Wähle dein Feld:");
            ConsoleKeyInfo Input = Console.ReadKey();
            Console.CursorLeft = 0;

            int index = (int)Input.Key - (int)ConsoleKey.NumPad1;

            //Abfrage der Tastatur Eingabe aufs Numpad (zahlenleiste geht nicht! in dem Beispiel)
            if (Input.Key >= ConsoleKey.NumPad1 && Input.Key <= ConsoleKey.NumPad9 && Field[index] == Input.KeyChar)
            {
                Field[index] = PlayerToken;
                Turn++;
            }
            //Wenn nicht 1-9 auf Numpad gedrückt wurde
            else
            {
                Console.WriteLine("Bitte nur Tasten von 1-9 auf dem Numpad");
                PlayerToken = PlayerToken == Token[0] ? Token[1] : Token[0];
            }
        }// Game


        // Spieler Daten Abfrage
        private static void Playerinitialization()
        {
            Console.WriteLine("Erster Spieler gib bitte deinen namen ein:");
            Player1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nDanke " + Player1 + ". Jetzt zu Dir Spieler 2");
            Player2 = Console.ReadLine();
            Console.Clear();
        }// Playerinitialization


        // Board zeichnen
        private static void Board()
        {
            Console.Clear();
            Console.WriteLine(" " + Field[0] + " | " + Field[1] + " | " + Field[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + Field[3] + " | " + Field[4] + " | " + Field[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + Field[6] + " | " + Field[7] + " | " + Field[8]);
        }// Board


        // Gewinner Abfrage
        private static bool IsWin()
        {
            //Wawgerechte 
            if (Field[0] == Field[1] && Field[1] == Field[2])
                return true;
            if (Field[3] == Field[4] && Field[4] == Field[5])
                return true;
            if (Field[6] == Field[7] && Field[7] == Field[8])
                return true;

            //Senkrechte Abfrage
            if (Field[0] == Field[3] && Field[3] == Field[6])
                return true;
            if (Field[1] == Field[4] && Field[4] == Field[7])
                return true;
            if (Field[2] == Field[5] && Field[5] == Field[8])
                return true;

            //Diagonale Abfrage
            if (Field[0] == Field[4] && Field[4] == Field[8])
                return true;
            if (Field[2] == Field[4] && Field[4] == Field[6])
                return true;


            return false;
        }// IsWin
    }
}


