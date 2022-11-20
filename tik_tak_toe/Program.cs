using System;

namespace tik_tak_toe
{
    class board
    {
        public static char[,] startBoard = {
                { '1', '|','2', '|', '3' },
                { '-', '-', '-', '-', '-'},
                { '4', '|','5', '|', '6' },
                { '-', '-', '-', '-', '-'},
                { '7', '|','8', '|', '9' }
        };
        public static char[,] gameBoard = startBoard.Clone() as char[,];
        public static void reset()
        {
            gameBoard = startBoard.Clone() as char[,];
        }
        public static void drawBoard()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Console.Write(gameBoard[i, j]);
                }
                Console.Write('\n');
            }
        }


    }
    class player
    {
        public static bool playerMove = true;
        public static bool playerWon = false;

    }
    class player1 : player
    {
        public static void getMovePlayer1()
        {
            Console.WriteLine("Player 1 move");
            char move = Console.ReadKey().KeyChar;
            doMovePlayer1(move);
        }

        public static void checkWinPlayer1()
        {
            for (int i = 0; i < board.startBoard.GetLength(0); i = i + 2)
            {
                int sumOfRow = 0;
                for (int j = 0; j < board.startBoard.GetLength(1); j = j + 2)
                {
                    if (board.gameBoard[i, j] == 'x')
                        sumOfRow++;
                }
                if (sumOfRow == 3)
                {
                    Console.WriteLine("Player 1 won");
                    playerWon = true;
                    return;
                }
            }

            for (int j = 0; j < board.startBoard.GetLength(0); j = j + 2)
            {
                int sumOfRow = 0;
                for (int i = 0; i < board.startBoard.GetLength(1); i = i + 2)
                {
                    if (board.gameBoard[i, j] == 'x')
                        sumOfRow++;
                }
                if (sumOfRow == 3)
                {
                    Console.WriteLine("Player 1 won");
                    playerWon = true;
                    return;
                }
            }

            int sumOfDiagonalA = 0;
            int sumOfDiagonalB = 0;
            for (int k = 0; k < board.startBoard.GetLength(0); ++k)
            {
                if (board.gameBoard[k, k] == 'x')
                    ++sumOfDiagonalA;
                if (board.gameBoard[k, board.startBoard.GetLength(0) - 1 - k] == 'x')
                    ++sumOfDiagonalB;
            }
            if (sumOfDiagonalA == 3 || sumOfDiagonalB == 3)
            {
                Console.WriteLine("Player 1 won");
                playerWon = true;
                return;
            }
        }

        public static void doMovePlayer1(char move)
        {
            for (int i = 0; i < board.gameBoard.GetLength(0); i += 2)
            {
                for (int j = 0; j < board.gameBoard.GetLength(1); j += 2)
                {
                    if (board.gameBoard[i, j] == move)
                    {
                        board.gameBoard[i, j] = 'x';
                        Console.Clear();
                        board.drawBoard();
                        player1.checkWinPlayer1();
                        player.playerMove = false;
                    }
                }
            }
            if (player.playerMove == true)
            {
                Console.WriteLine(" - unexeptable value, try again");
                getMovePlayer1();
            }
        }

    }
    class player2 : player
    {
        public static bool bot = false;

        public static void getMovePlayer2()
        {
            Random rnd = new Random();

            if (bot == false)
            {
                Console.WriteLine("Player 2 move");
                char move = Console.ReadKey().KeyChar;
                doMovePlayer2(move);
            }
            else
            {
                string x = rnd.Next(1, 9).ToString();
                char move = x[0];
                doMovePlayer2(move);
            }

        }
        public static void checkWinPlayer2()
        {
            
            for (int i = 0; i < board.startBoard.GetLength(0); i = i + 2)
            {
                int sumOfRow = 0;
                for (int j = 0; j < board.startBoard.GetLength(1); j = j + 2)
                {
                    if (board.gameBoard[i, j] == '0')
                        sumOfRow++;
                }
                if (sumOfRow == 3)
                {
                    Console.WriteLine("Player 2 won");
                    playerWon = true;
                    return;
                }
            }
            
            for (int j = 0; j < board.startBoard.GetLength(0); j = j + 2)
            {
                int sumOfRow = 0;
                for (int i = 0; i < board.startBoard.GetLength(1); i = i + 2)
                {
                    if (board.gameBoard[i, j] == '0')
                        sumOfRow++;
                }
                if (sumOfRow == 3)
                {
                    Console.WriteLine("Player 2 won");
                    playerWon = true;
                    return;
                }
            }

            int sumOfDiagonalA = 0;
            int sumOfDiagonalB = 0;
            for (int k = 0; k < board.startBoard.GetLength(0); ++k)
            {
                if (board.gameBoard[k, k] == '0')
                    ++sumOfDiagonalA;
                if (board.gameBoard[k, board.startBoard.GetLength(0) - 1 - k] == '0')
                    ++sumOfDiagonalB;
            }
            if (sumOfDiagonalA == 3 || sumOfDiagonalB == 3)
            {
                Console.WriteLine("Player 2 won");
                playerWon = true;
                return;
            }
        }

        public static void doMovePlayer2(char move)
        {
            for (int i = 0; i < board.gameBoard.GetLength(0); i += 2)
            {
                for (int j = 0; j < board.gameBoard.GetLength(1); j += 2)
                {
                    if (board.gameBoard[i, j] == move)
                    {
                        board.gameBoard[i, j] = '0';
                        Console.Clear();
                        board.drawBoard();
                        player2.checkWinPlayer2();
                        player.playerMove = true;
                    }
                }
            }
            if (bot == false)
            {
                if (player.playerMove == false)
                {
                    Console.WriteLine(" - unexeptable value, try again");
                    getMovePlayer2();
                }
            }
            else
            {
                if (player.playerMove == false)
                {
                    getMovePlayer2();
                }
            }
        }
    }
    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
    class Program
    {
        public static List<Option> options;
        static void Main(string[] args)
        {

            options = new List<Option>
            {
                new Option("Start 2 players", () => start(false)),
                new Option("Start 1 player", () =>  start(true)),
                new Option("Exit", () => Environment.Exit(0)),
            };
            int index = 0;

            WriteMenu(options, options[index]);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();


        }
        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
        static void restart(bool x)
        {
            board.reset();
            Console.Clear();
            board.drawBoard();
            player.playerWon = false;
            start(x);
        }

        static void start(bool x)
        {
            player2.bot = x;
            Console.Clear();
            board.drawBoard();
            for (int i = 0; i < 9; i++)
            {
                if (player.playerMove)
                {
                    player1.getMovePlayer1();
                }
                else
                {
                    player2.getMovePlayer2();
                }
                if (player.playerWon == true) break;
            }
            if (player.playerWon == false)
            {
                Console.WriteLine("tie");
            }

            Console.WriteLine("restart y/n?");
            char ifRestart = Console.ReadKey().KeyChar;
            if (ifRestart == 'y')
            {
                restart(x);
            }
            else
            {
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
        }
    }
}