using System;

namespace ConnectFour {
	enum Color {
		Red,
		Yellow,
		White
	}
	
	class Piece {
		public Color Color {get; set;}
		public Piece() {Color = Color.White;}
		public Piece(Color color) { Color = color;}
		public void Print() {
			if (Color == Color.Red)
				Console.ForegroundColor = ConsoleColor.Red;
			else if (Color == Color.Yellow)
				Console.ForegroundColor = ConsoleColor.DarkYellow;
			else Console.ForegroundColor = ConsoleColor.White;
			Console.Write("█");
			Console.ForegroundColor = ConsoleColor.White;
		}
		public override string ToString() {
			return Color.ToString();
		}
	}
}