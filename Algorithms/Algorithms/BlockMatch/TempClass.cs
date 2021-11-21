namespace Algorithms
{
	public class TempClass
	{
		/// <summary>
		/// You can assume the gameboard is a 4x4 square grid.
		/// This matches the image at
		/// https://drive.google.com/file/d/1Chz6meMXKPa6ZdcUhuh745i4My9mbxIK/view?usp=sharing
		/// </summary>

		public Block[] board = new Block[]
		{
		new Block { Position = new Vector2Int {X = 0, Y = 0}, Color = Color.JeffGoldblum},
		new Block { Position = new Vector2Int {X = 1, Y = 0}, Color = Color.JeffGoldblum},
		new Block { Position = new Vector2Int {X = 2, Y = 0}, Color = Color.Red},
		new Block { Position = new Vector2Int {X = 3, Y = 0}, Color = Color.Red},
		new Block { Position = new Vector2Int {X = 0, Y = 1}, Color = Color.Red},
		new Block { Position = new Vector2Int {X = 1, Y = 1}, Color = Color.Gold},
		new Block { Position = new Vector2Int {X = 2, Y = 3}, Color = Color.Yeti},
		new Block { Position = new Vector2Int {X = 3, Y = 2}, Color = Color.Yeti},
		new Block { Position = new Vector2Int {X = 2, Y = 1}, Color = Color.Red},
		new Block { Position = new Vector2Int {X = 3, Y = 1}, Color = Color.Yeti},
		new Block { Position = new Vector2Int {X = 0, Y = 2}, Color = Color.Yeti},
		new Block { Position = new Vector2Int {X = 1, Y = 2}, Color = Color.Gold},
		new Block { Position = new Vector2Int {X = 2, Y = 2}, Color = Color.Yeti},
		new Block { Position = new Vector2Int {X = 0, Y = 3}, Color = Color.Gold},
		new Block { Position = new Vector2Int {X = 1, Y = 3}, Color = Color.Yeti},
		new Block { Position = new Vector2Int {X = 3, Y = 3}, Color = Color.JeffGoldblum},
		};

		/// <summary>
		/// Implement this function
		/// </summary>
		public static Block[] GetGroup(Vector2Int tappedPosition, Block[] board)
		{
			Block startingPos;
			Queue<Block> toCheck = new Queue<Block>();
			Dictionary<Block, Block> cameFrom = new Dictionary<Block, Block>();

			foreach (var block in board)
			{
				if (block.Position.X == tappedPosition.X && block.Position.Y == tappedPosition.Y)
				{
					startingPos = block;
					toCheck.Enqueue(startingPos);
					cameFrom[startingPos] = new Block();
				}
			}

			while (toCheck.Count > 0)
			{
				var currentBlock = toCheck.Dequeue();
				foreach (var nextBlock in GetNeighbors(currentBlock, board))
				{
					if (!cameFrom.ContainsKey(nextBlock))
					{
						toCheck.Enqueue(nextBlock);
						cameFrom.Add(nextBlock, currentBlock);
					}
				}
			}
			return cameFrom.Keys.ToArray();
		}
		public static List<Block> GetNeighbors(Block inputBlock, Block[] gameboard)
		{
			var inputColor = inputBlock.Color;
			List<Block> output = new List<Block>();

			Vector2Int[] neighborArr = new Vector2Int[] {
				new Vector2Int(inputBlock.Position.X + 1, inputBlock.Position.Y),
				new Vector2Int(inputBlock.Position.X - 1, inputBlock.Position.Y),
				new Vector2Int(inputBlock.Position.X, inputBlock.Position.Y + 1),
				new Vector2Int(inputBlock.Position.X, inputBlock.Position.Y - 1) };

			for (int i = 0; i < gameboard.Length; i++)
				foreach (var vector in neighborArr)
					if (vector.Equals(gameboard[i].Position) && inputColor.Equals(gameboard[i].Color))
						output.Add(gameboard[i]);

			return output;
		}
	}
}
