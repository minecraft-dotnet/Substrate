using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Substrate.Generators.Floors
{
	/// <summary>
	/// Represents a flat floor.
	/// </summary>
	public class FlatFloor : IFloor
	{
		private int height;

		/// <summary>
		/// Constructs a new flat floor at the given y-elevation.
		/// </summary>
		/// <param name="height">The y-elevation of the flat floor.</param>
		public FlatFloor(int height)
		{
			this.height = height;
		}

		public int GetHeight(int x, int z)
		{
			return height;
		}
	}
}
