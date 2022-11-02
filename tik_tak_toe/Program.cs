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
            check1(move);
        }
        public static void check1(char move)
        {
            if (move == 'x' || move == '0')
            {
                Console.WriteLine(" - unexeptable value, try again");
                getMovePlayer1();
            }
            else
            {
                doMovePlayer1(move);
            }
        }
        public static void checkWinPlayer1()
        {
            if (board.gameBoard[0, 0] == 'x' && board.gameBoard[0, 2] == 'x' && board.gameBoard[0, 4] == 'x')
            {
                Console.WriteLine("Player 1 won");
                playerWon = true;
            }
            if (board.gameBoard[2, 0] == 'x' && board.gameBoard[2, 2] == 'x' && board.gameBoard[2, 4] == 'x')
            {
                Console.WriteLine("Player 1 won");
                playerWon = true;
            }
            if (board.gameBoard[4, 0] == 'x' && board.gameBoard[4, 2] == 'x' && board.gameBoard[4, 4] == 'x')
            {
                Console.WriteLine("Player 1 won");
                playerWon = true;
            }
            if (board.gameBoard[0, 0] == 'x' && board.gameBoard[2, 2] == 'x' && board.gameBoard[4, 4] == 'x')
            {
                Console.WriteLine("Player 1 won");
                playerWon = true;
            }
            if (board.gameBoard[4, 0] == 'x' && board.gameBoard[2, 2] == 'x' && board.gameBoard[4, 4] == 'x')
            {
                Console.WriteLine("Player 1 won");
                playerWon = true;
            }
            if (board.gameBoard[0, 0] == 'x' && board.gameBoard[2, 0] == 'x' && board.gameBoard[4, 0] == 'x')
            {
                Console.WriteLine("Player 1 won");
                playerWon = true;
            }
            if (board.gameBoard[0, 2] == 'x' && board.gameBoard[2, 2] == 'x' && board.gameBoard[4, 2] == 'x')
            {
                Console.WriteLine("Player 1 won");
                playerWon = true;
            }
            if (board.gameBoard[0, 4] == 'x' && board.gameBoard[2, 4] == 'x' && board.gameBoard[4, 4] == 'x')
            {
                Console.WriteLine("Player 1 won");
                playerWon = true;
            }
        }

            public static void doMovePlayer1(char move)
        {
            for (int i = 0; i < board.gameBoard.GetLength(0); i+=2)
            {
                for (int j = 0; j < board.gameBoard.GetLength(1); j+=2)
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
    class player2:player
    {
        public static void getMovePlayer2()
        {
            Console.WriteLine("Player 2 move");
            char move = Console.ReadKey().KeyChar;
            check2(move);
        }
        public static void check2(char move)
        {
            if (move == 'x' || move == '0')
            {
                Console.WriteLine(" - unexeptable value, try again");
                getMovePlayer2();
            }
            else
            {
                doMovePlayer2(move);
            }
        }
        public static void checkWinPlayer2()
        {
            if (board.gameBoard[0, 0] == '0' && board.gameBoard[0, 2] == '0' && board.gameBoard[0, 4] == '0')
            {
                Console.WriteLine("Player 2 won");
                playerWon = true;
            }
            if (board.gameBoard[2, 0] == '0' && board.gameBoard[2, 2] == '0' && board.gameBoard[2, 4] == '0')
            {
                Console.WriteLine("Player 2 won");
                playerWon = true;
            }
            if (board.gameBoard[4, 0] == '0' && board.gameBoard[4, 2] == '0' && board.gameBoard[4, 4] == '0')
            {
                Console.WriteLine("Player 2 won");
                playerWon = true;
            }
            if (board.gameBoard[0, 0] == '0' && board.gameBoard[2, 2] == '0' && board.gameBoard[4, 4] == '0')
            {
                Console.WriteLine("Player 2 won");
                playerWon = true;
            }
            if (board.gameBoard[4, 0] == '0' && board.gameBoard[2, 2] == '0' && board.gameBoard[4, 4] == '0')
            {
                Console.WriteLine("Player 2 won");
                playerWon = true;
            }
            if (board.gameBoard[0, 0] == '0' && board.gameBoard[2, 0] == '0' && board.gameBoard[4, 0] == '0')
            {
                Console.WriteLine("Player 2 won");
                playerWon = true;
            }
            if (board.gameBoard[0, 2] == '0' && board.gameBoard[2, 2] == '0' && board.gameBoard[4, 2] == '0')
            {
                Console.WriteLine("Player 2 won");
                playerWon = true;
            }
            if (board.gameBoard[0, 4] == '0' && board.gameBoard[2, 4] == '0' && board.gameBoard[4, 4] == '0')
            {
                Console.WriteLine("Player 2 won");
                playerWon = true;
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
            if (player.playerMove == false)
            {
                Console.WriteLine(" - unexeptable value, try again");
                getMovePlayer2();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            board.drawBoard();
            start();
            while (true)
            {
                Console.WriteLine("restart y/n?");
                char ifRestart = Console.ReadKey().KeyChar;
                if (ifRestart == 'y')
                {
                    restart();
                }
                else
                {
                    Environment.Exit(0);
                }

            }

        }
        static void restart()
        {
            board.reset();
            Console.Clear();
            board.drawBoard();
            player.playerWon = false;
            start();
        }

        static void start()
        {
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
                if(player.playerWon == true) break;
            }
            if (player.playerWon == false)
            {
                Console.WriteLine("draw");
            }
 
        }
    }
}

