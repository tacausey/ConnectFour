using System;

namespace ConnectFour {
	class GameBoard {
		private readonly int rows = 6;
		private readonly int cols = 7;
		private Piece[,] Board {get; set;}
		public GameBoard() {
			Board = new Piece[rows, cols];
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < cols; j++) {
					Board[i,j] = new Piece();
				}
			}
		}
		public void Place(Piece piece, int col) {
			for (int i = rows-1; i >= 0; i--) {	// iterate up column col
				if (Board[i, col].Color == Color.White) {	// if you found an empty spot
					Board[i, col] = piece;	// place piece
					return;
				}
			}
		}
		public void Print() {
			Console.WriteLine("1   2   3   4   5   6   7");
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < cols; j++) {
					Board[i,j].Print();
					if (j != cols-1) Console.Write(" | ");
				}
				if (i != rows-1) Console.WriteLine("\n-------------------------");
			}
			Console.WriteLine("\n1   2   3   4   5   6   7\n");
		}
		public Color GameOver() {
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j <= cols-4; j++) {
					if (Board[i,j].Color == Color.White)
						continue;
					else if (Board[i,j].Color == Board[i,j+1].Color	// horizontal
							&& Board[i,j].Color == Board[i,j+2].Color
							&& Board[i,j].Color == Board[i,j+3].Color) {
						return Board[i,j].Color;
					}
				}
			}
			for (int i = 0; i <= rows-4; i++) {
				for (int j = 0; j < cols; j++) {
					if (Board[i,j].Color == Color.White)
						continue;
					else if (Board[i,j].Color == Board[i+1,j].Color	// vertical
							&& Board[i,j].Color == Board[i+2,j].Color
							&& Board[i,j].Color == Board[i+3,j].Color) {
						return Board[i,j].Color;
					}
				}
			}
			//Console.WriteLine("vertical/horizontal test passed");
			for (int i = 0; i <= rows-4; i++) {
				for (int j = 0; j <= cols-4; j++) {
					if (Board[i,j].Color == Color.White)
						continue;
					else if (Board[i,j].Color == Board[i+1, j+1].Color	// top left to bottom right
							&& Board[i,j].Color == Board[i+2, j+2].Color
							&& Board[i,j].Color == Board[i+3, j+3].Color) {
						return Board[i,j].Color;
					}
				}
			}
			for (int i = 0; i <= rows-4; i++) {
				for (int j = 3; j < cols; j++) {
					if (Board[i,j].Color == Color.White)
						continue;
					else if (Board[i,j].Color == Board[i+1, j-1].Color	// top right to bottom left
							&& Board[i,j].Color == Board[i+2, j-2].Color
							&& Board[i,j].Color == Board[i+3, j-3].Color) {
						return Board[i,j].Color;
					}
				}
			}
			return Color.White;
		}
		public bool ValidCol(int col) {
			if (col >= cols) return false;
			else if (Board[0, col].Color == Color.White) return true;
			else return false;
		}
	}
}