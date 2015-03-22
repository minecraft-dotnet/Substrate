using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Substrate.Generators.Trees
{
	/// <summary>
	/// Represents a tree generator that can be used to spawn trees on a floor.
	/// </summary>
	public abstract class TreeGenerator
	{
		public abstract AlphaBlockCollection GenerateTree(Random rng);
	}
}
