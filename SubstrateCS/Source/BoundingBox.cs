using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Substrate
{
	/// <summary>
	/// Represents a bounding box.
	/// </summary>
	public struct BoundingBox
	{
		private Position _m_min_pos;
		private Position _m_max_pos;

		/// <summary>
		/// The low x coordinate of this bounding box.
		/// </summary>
		public int LowX { get { return _m_min_pos.X; } }
		/// <summary>
		/// The low y coordinate of this bounding box.
		/// </summary>
		public int LowY { get { return _m_min_pos.Y; } }
		/// <summary>
		/// The low z coordinate of this bounding box.
		/// </summary>
		public int LowZ { get { return _m_min_pos.Z; } }

		/// <summary>
		/// The high x coordinate of this bounding box.
		/// </summary>
		public int HighX { get { return _m_max_pos.X; } }
		/// <summary>
		/// The high y coordinate of this bounding box.
		/// </summary>
		public int HighY { get { return _m_max_pos.Y; } }
		/// <summary>
		/// The high z coordinate of this bounding box.
		/// </summary>
		public int HighZ { get { return _m_max_pos.Z; } }

		/// <summary>
		/// A position made up of the low x, y and z coordinates.
		/// </summary>
		public Position LowXLowYLowZ { get { return _m_min_pos; } }
		/// <summary>
		/// A position made up of the low x and y and the high z coordinate.
		/// </summary>
		public Position LowXLowYHighZ { get { return new Position(LowX, LowY, HighZ); } }
		/// <summary>
		/// A position made up of the low x and z and the high y coordinate.
		/// </summary>
		public Position LowXHighYLowZ { get { return new Position(LowX, HighY, LowZ); } }
		/// <summary>
		/// A position made up of the low x and the high y and z coordinates.
		/// </summary>
		public Position LowXHighYHighZ { get { return new Position(LowX, HighY, HighZ); } }

		/// <summary>
		/// A position made up of the high x and low y and z coordinates.
		/// </summary>
		public Position HighXLowYLowZ { get { return new Position(HighX, LowY, LowZ); } }
		/// <summary>
		/// A position made up of the high x and z and the low y coordinate.
		/// </summary>
		public Position HighXLowYHighZ { get { return new Position(HighX, LowY, HighZ); } }
		/// <summary>
		/// A position made up of the high x and y and the low z coordinate.
		/// </summary>
		public Position HighXHighYLowZ { get { return new Position(HighX, HighY, LowZ); } }
		/// <summary>
		/// A position made up of the high x, y and z coordinates.
		/// </summary>
		public Position HighXHighYHighZ { get { return _m_max_pos; } }

		/// <summary>
		/// The width of the bounding box.
		/// </summary>
		public int Width { get { return (_m_max_pos.X - _m_min_pos.X) + 1; } }
		/// <summary>
		/// The height of the bounding box.
		/// </summary>
		public int Height { get { return (_m_max_pos.Y - _m_min_pos.Y) + 1; } }
		/// <summary>
		/// The depth of the bounding box.
		/// </summary>
		public int Depth { get { return (_m_max_pos.Z - _m_min_pos.Z) + 1; } }

		/// <summary>
		/// Constructs a new bounding box from the given sets of low and high coordinates.
		/// </summary>
		/// <param name="lowX">The low x coordinate of the bounding box.</param>
		/// <param name="lowY">The low y coordinate of the bounding box.</param>
		/// <param name="lowZ">The low z coordinate of the bounding box.</param>
		/// <param name="highX">The high x coordinate of the bounding box.</param>
		/// <param name="highY">The high y coordinate of the bounding box.</param>
		/// <param name="highZ">The high z coordinate of the bounding box.</param>
		public BoundingBox(int lowX, int lowY, int lowZ, int highX, int highY, int highZ)
		{
			if (lowX > highX)
				throw new ArgumentOutOfRangeException(
					"lowX must be lesser than or equal to highX. lowX = " + lowX.ToString() + ", highX = " + highX.ToString() + "."
				);
			if (lowY > highY)
				throw new ArgumentOutOfRangeException(
					"lowY must be lesser than or equal to highY. lowY = " + lowY.ToString() + ", highY = " + highY.ToString() + "."
				);
			if (lowZ > highZ)
				throw new ArgumentOutOfRangeException(
					"lowZ must be lesser than or equal to highZ. lowZ = " + lowZ.ToString() + ", highZ = " + highZ.ToString() + "."
				);

			_m_min_pos = new Position(lowX, lowY, lowZ);
			_m_max_pos = new Position(highX, highY, highZ);
		}
		/// <summary>
		/// Constructs a new bounding box from the given sets of low and high coordinates.
		/// </summary>
		/// <param name="lowPos">The low position of the bounding box.</param>
		/// <param name="highX">The high x coordinate of the bounding box.</param>
		/// <param name="highY">The high y coordinate of the bounding box.</param>
		/// <param name="highZ">The high z coordinate of the bounding box.</param>
		public BoundingBox(Position lowPos, int highX, int highY, int highZ)
			: this(lowPos.X, lowPos.Y, lowPos.Z, highX, highY, highZ)
		{
		}
		/// <summary>
		/// Constructs a new bounding box from the given sets of low and high coordinates.
		/// </summary>
		/// <param name="lowX">The low x coordinate of the bounding box.</param>
		/// <param name="lowY">The low y coordinate of the bounding box.</param>
		/// <param name="lowZ">The low z coordinate of the bounding box.</param>
		/// <param name="highPos">The high position of the bounding box.</param>
		public BoundingBox(int lowX, int lowY, int lowZ, Position highPos)
			: this(lowX, lowY, lowZ, highPos.X, highPos.Y, highPos.Z)
		{
		}
		/// <summary>
		/// Constructs a new bounding box from the given sets of low and high coordinates.
		/// </summary>
		/// <param name="lowPos">The low position of the bounding box.</param>
		/// <param name="highPos">The high position of the bounding box.</param>
		public BoundingBox(Position lowPos, Position highPos)
			: this(lowPos.X, lowPos.Y, lowPos.Z, highPos.X, highPos.Y, highPos.Z)
		{
		}
		/// <summary>
		/// Constructs a new bounding box from the given set of low coordinates and dimensions.
		/// </summary>
		/// <param name="lowPos">The low position of the bounding box.</param>
		/// <param name="width">The width of the bounding box.</param>
		/// <param name="height">The height of the bounding box.</param>
		/// <param name="depth">The depth of the bounding box.</param>
		public BoundingBox(Position lowPos, uint width, uint height, uint depth)
			: this(lowPos.X, lowPos.Y, lowPos.Z, lowPos.X + (int)width - 1, lowPos.Y + (int)height - 1, lowPos.Z + (int)depth - 1)
		{
		}

		/// <summary>
		/// Returns the volume of the bounding box.
		/// </summary>
		/// <returns>The volume of the bounding box.</returns>
		public int GetVolume()
		{
			return Width * Height * Depth;
		}
		/// <summary>
		/// Returns the area of the bottom or top surface of the bounding box.
		/// </summary>
		/// <returns>The area of the bottom or top surface of the bounding box.</returns>
		public int GetBottomArea()
		{
			return Width * Depth;
		}
		/// <summary>
		/// Returns the area of the front or back surface of the bounding box.
		/// </summary>
		/// <returns>The area of the front or back surface of the bounding box.</returns>
		public int GetFrontArea()
		{
			return Width * Height;
		}
		/// <summary>
		/// Returns the area of the left or right surface of the bounding box.
		/// </summary>
		/// <returns>The area of the left or right surface of the bounding box.</returns>
		public int GetSideArea()
		{
			return Depth * Height;
		}

		/// <summary>
		/// Returns true if the given position is inside this bounding box, false otherwise.
		/// </summary>
		/// <param name="pos">The position to check.</param>
		/// <returns>True if the given position is inside this bounding box, false otherwise.</returns>
		public bool IsInside(Position pos)
		{
			return pos.X >= LowX && pos.X <= HighX &&
				pos.Y >= LowY && pos.Y <= HighY &&
				pos.Z >= LowZ && pos.Z <= HighZ;
		}
		/// <summary>
		/// Returns true if the given bounding box intersects with (or is inside) this bounding box.
		/// </summary>
		/// <param name="other">The bounding box to check.</param>
		/// <returns>True if the given bounding box intersects with (or is inside) this bounding box.</returns>
		public bool IntersectsWith(BoundingBox other)
		{
			return
				IsInside(other.LowXLowYLowZ) ||
				IsInside(other.LowXLowYHighZ) ||
				IsInside(other.LowXHighYLowZ) ||
				IsInside(other.LowXHighYHighZ) ||
				IsInside(other.HighXLowYLowZ) ||
				IsInside(other.HighXLowYHighZ) ||
				IsInside(other.HighXHighYLowZ) ||
				IsInside(other.HighXHighYHighZ) ||

				other.IsInside(LowXLowYLowZ) ||
				other.IsInside(LowXLowYHighZ) ||
				other.IsInside(LowXHighYLowZ) ||
				other.IsInside(LowXHighYHighZ) ||
				other.IsInside(HighXLowYLowZ) ||
				other.IsInside(HighXLowYHighZ) ||
				other.IsInside(HighXHighYLowZ) ||
				other.IsInside(HighXHighYHighZ);
		}

		/// <summary>
		/// Offsets this bounding box by the given x, y and z coordinates.
		/// </summary>
		/// <param name="x">The x coordinate to offset the bounding box by.</param>
		/// <param name="y">The y coordinate to offset the bounding box by.</param>
		/// <param name="z">The z coordinate to offset the bounding box by.</param>
		public void Offset(int x, int y, int z)
		{
			Offset(new Position(x, y, z));
		}
		/// <summary>
		/// Offsets this bounding box by the given position.
		/// </summary>
		/// <param name="pos">The position to offset the bounding box by.</param>
		public void Offset(Position pos)
		{
			_m_min_pos += pos;
			_m_max_pos += pos;
		}
	}
}
