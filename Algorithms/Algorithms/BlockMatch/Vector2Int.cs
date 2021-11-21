namespace Algorithms
{
	public struct Vector2Int
	{
		public Vector2Int(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X;
		public int Y;

		public override string ToString()
		{
			return $"[{nameof(Vector2Int)} ({X}, {Y})]";
		}
	}
}
