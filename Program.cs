using System;
using System.Threading;

namespace ConnectFour {
	class Program {
		static void Main() {
			GameBoard gameBoard = new GameBoard();
			int turns = 0;
			while (gameBoard.GameOver() == Color.White) {
				gameBoard.Print();
				int col;
				if (turns % 2 == 0) {
					Console.WriteLine("Red's turn!");
					Piece red = new Piece(Color.Red);
					Console.WriteLine("Which column to place your piece?");
					while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out col)
						|| !gameBoard.ValidCol(--col))
						Console.WriteLine("Invalid column. Pick another:");
					gameBoard.Place(red, col);
				}
				else {
					Console.WriteLine("Yellow's turn!");
					Piece yellow = new Piece(Color.Yellow);
					Console.WriteLine("Which column to place your piece?");
					while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out col)
						|| !gameBoard.ValidCol(--col))
						Console.WriteLine("Invalid column. Pick another:");
					gameBoard.Place(yellow, col);
				}
				turns++;
				Console.Clear();
			}
			gameBoard.Print();
			Console.WriteLine($"{gameBoard.GameOver()} Wins!");
			Console.ReadKey(true);
		}
	}
}