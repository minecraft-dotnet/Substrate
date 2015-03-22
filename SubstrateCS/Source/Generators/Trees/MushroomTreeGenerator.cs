using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Substrate.Generators.Trees
{
	/// <summary>
	/// Represents a mushroom tree generator that generates mushroom-like shaped trees.
	/// </summary>
	public class MushroomTreeGenerator : TreeGenerator
	{
		private int _logId;
		private int _leafId;
		private bool _isLarge;

		/// <summary>
		/// Constructs a new mushroom tree generator to generate mushroom-like shaped trees.
		/// </summary>
		/// <param name="logId">The block id to use for the logs of the tree.</param>
		/// <param name="leafId">The block id to use for the leaves of the tree.</param>
		/// <param name="isLarge">True if the generated mushroom tree should be large, false otherwise.</param>
		public MushroomTreeGenerator(int logId, int leafId, bool isLarge)
		{
			_logId = logId;
			_leafId = leafId;
			_isLarge = isLarge;
		}

		/// <inheritdoc/>
		public override AlphaBlockCollection GenerateTree(Random rng)
		{
			int width, height, depth;
			int centerX, centerZ;
			if (_isLarge)
			{
				width = 7;
				height = 7 + rng.Next(0, 3);
				depth = 7;

				centerX = 3;
				centerZ = 3;
			}
			else
			{
				width = 5;
				height = 5 + rng.Next(0, 2);
				depth = 5;

				centerX = 2;
				centerZ = 2;
			}

			AlphaBlockCollection tree = new AlphaBlockCollection(width, height, depth);
			tree.AutoLight = false;


			int canopyHeight = 3;
			if (_isLarge)
				canopyHeight = 4;

			for (int i = 1; i < canopyHeight; i++)
			{
				FillWithLeaves(tree, height - i);
			}
			GenerateOuterShroomLeaves(tree, height - canopyHeight);
			for (int i = 0; i < (height - 1); i++)
			{
				tree.SetID(centerX, i, centerZ, _logId);
			}

			return tree;
		}

		private void FillWithLeaves(AlphaBlockCollection tree, int y)
		{
			int distanceFromTop = tree.YDim - y;
			uint size = 1u + (uint)distanceFromTop * 2u;
			tree.Fill(new BoundingBox(new Position((tree.XDim - (int)size) / 2, y, (tree.ZDim - (int)size) / 2), size, 1u, size), _leafId);
		}
		private void GenerateOuterShroomLeaves(AlphaBlockCollection tree, int y)
		{
			int width = tree.XDim;
			int height = tree.YDim;
			int depth = tree.ZDim;
			for (int i = 1; i < (width - 1); i++)
			{
				tree.SetID(i, y, 0, _leafId);
				tree.SetID(i, y, depth - 1, _leafId);
			}
			for (int i = 1; i < (depth - 1); i++)
			{
				tree.SetID(0, y, i, _leafId);
				tree.SetID(width - 1, y, i, _leafId);
			}
		}
	}
}
