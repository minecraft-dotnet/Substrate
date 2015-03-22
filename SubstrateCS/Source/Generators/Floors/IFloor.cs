using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Substrate.Generators.Floors
{
	/// <summary>
	/// Represents a floor that features can be generated on or that can be filled with certain blocks.
	/// </summary>
	public interface IFloor
	{
		/// <summary>
		/// Returns the y-elevation of the floor at the given x and z coordinates.
		/// </summary>
		/// <param name="x">The x coordinate the height should be determined for.</param>
		/// <param name="z">The z coordinate the height should be determined for.</param>
		/// <returns>The y-elevation of the floor at the given x and z coordinates.</returns>
		int GetHeight(int x, int z);
	}
}
