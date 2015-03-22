using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Substrate
{
	/// <summary>
	/// Represents a position in the world.
	/// </summary>
	public struct Position
	{
		/// <summary>
		/// The x coordinate of the position.
		/// </summary>
		public int X { get; private set; }
		/// <summary>
		/// The y coordinate of the position.
		/// </summary>
		public int Y { get; private set; }
		/// <summary>
		/// The z coordinate of the position.
		/// </summary>
		public int Z { get; private set; }

		/// <summary>
		/// Constructs a new position with the given x, y and z coordinates.
		/// </summary>
		/// <param name="x">The x coordinate of the position.</param>
		/// <param name="y">The y coordinate of the position.</param>
		/// <param name="z">The z coordinate of the position.</param>
		public Position(int x, int y, int z)
			: this()
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// Constructs a position with the given x value and the y and z values of this position.
		/// </summary>
		/// <param name="newX">The x value of the new position.</param>
		/// <returns>A position with the given x value and the y and z values of this position.</returns>
		public Position WithX(int newX)
		{
			return new Position(newX, Y, Z);
		}
		/// <summary>
		/// Constructs a position with the given y value and the x and z values of this position.
		/// </summary>
		/// <param name="newY">The y value of the new position.</param>
		/// <returns>A position with the given y value and the x and z values of this position.</returns>
		public Position WithY(int newY)
		{
			return new Position(X, newY, Z);
		}
		/// <summary>
		/// Constructs a position with the given z value and the x and y values of this position.
		/// </summary>
		/// <param name="newZ">The z value of the new position.</param>
		/// <returns>A position with the given z value and the x and y values of this position.</returns>
		public Position WithZ(int newZ)
		{
			return new Position(X, Y, newZ);
		}

		/// <summary>
		/// Returns the distance of this position to the given other position.
		/// </summary>
		/// <param name="other">The position to get the distance to.</param>
		/// <returns>The distance of this position to the given other position.</returns>
		public double DistanceTo(Position other)
		{
			int diffX = X - other.X;
			int diffY = Y - other.Y;
			int diffZ = Z - other.Z;
			return Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
		}

		/// <summary>
		/// Adds the given position to this position and returns the sum of both.
		/// </summary>
		/// <param name="other">The position to add.</param>
		/// <returns>The sum of both positions.</returns>
		public Position Add(Position other)
		{
			return new Position(X + other.X, Y + other.Y, Z + other.Z);
		}
		/// <summary>
		/// Subtracts the given position from this position and returns the difference of both.
		/// </summary>
		/// <param name="other">The position to subtract.</param>
		/// <returns>The difference of both positions.</returns>
		public Position Subtract(Position other)
		{
			return new Position(X - other.X, Y - other.Y, Z - other.Z);
		}
		/// <summary>
		/// Multiplies this position with the given scalar and returns the scaled position.
		/// </summary>
		/// <param name="scalar">The scalar to multiply this position by.</param>
		/// <returns>The scaled position.</returns>
		public Position Multiply(double scalar)
		{
			return new Position((int)(X * scalar), (int)(Y * scalar), (int)(Z * scalar));
		}
		/// <summary>
		/// Divides this position with the given divisor and returns the scaled position.
		/// </summary>
		/// <param name="divisor">The divisor to divide this position by.</param>
		/// <returns>The scaled position.</returns>
		public Position Divide(double divisor)
		{
			return new Position((int)(X / divisor), (int)(Y / divisor), (int)(Z / divisor));
		}

		public static Position operator +(Position left, Position right)
		{
			return left.Add(right);
		}
		public static Position operator -(Position left, Position right)
		{
			return left.Subtract(right);
		}
		public static Position operator *(Position left, double scalar)
		{
			return left.Multiply(scalar);
		}
		public static Position operator /(Position left, double divisor)
		{
			return left.Divide(divisor);
		}
	}
}
