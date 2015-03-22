using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate
{
	public abstract class StructureGenerationOptions
	{
		public bool Enabled;

		public string GetGenerationOptions()
		{
			if (!Enabled)
				return "";

			return BuildGenerationOptions();
		}
		protected abstract string BuildGenerationOptions();
	}
	public class VillageGenerationOptions : StructureGenerationOptions
	{
		public int Size;

		private int _distance;
		public int Distance
		{
			get { return _distance; }
			set
			{
				if (value < 9)
					value = 9;
				_distance = value;
			}
		}

		public VillageGenerationOptions()
		{
			Distance = 32;
			Size = 1;
		}

		protected override string BuildGenerationOptions()
		{
			StringBuilder generationOptions = new StringBuilder("village(");
			generationOptions.Append("size=");
			generationOptions.Append(Size.ToString());
			generationOptions.Append(" distance=");
			generationOptions.Append(_distance.ToString());
			generationOptions.Append(')');

			return generationOptions.ToString();
		}
	}
	public class MineshaftGenerationOptions : StructureGenerationOptions
	{
		private float _chance;
		public float Chance
		{
			get { return _chance; }
			set
			{
				if (value < 0.0f)
					value = 0.0f;
				else if (value > 1.0f)
					value = 1.0f;

				_chance = value;
			}
		}

		public MineshaftGenerationOptions()
		{
			Chance = 0.01f;
		}

		protected override string BuildGenerationOptions()
		{
			StringBuilder generationOptions = new StringBuilder("mineshaft(");
			generationOptions.Append("chance=");
			generationOptions.Append(_chance.ToString());
			generationOptions.Append(')');

			return generationOptions.ToString();
		}
	}
	public class StrongholdGenerationOptions : StructureGenerationOptions
	{
		private float _distance;
		public float Distance
		{
			get { return _distance; }
			set
			{
				if (value < 1.0f)
					value = 1.0f;

				_distance = value;
			}
		}

		public int Count;

		private int _spread;
		public int Spread
		{
			get { return _spread; }
			set
			{
				if (value < 1)
					value = 1;

				_spread = value;
			}
		}

		public StrongholdGenerationOptions()
		{
			_distance = 32f;
			Count = 3;
			_spread = 3;
		}

		protected override string BuildGenerationOptions()
		{
			StringBuilder generationOptions = new StringBuilder("stronghold(");
			generationOptions.Append("distance=");
			generationOptions.Append(_distance.ToString());
			generationOptions.Append(" count=");
			generationOptions.Append(Count.ToString());
			generationOptions.Append(" spread=");
			generationOptions.Append(_spread.ToString());
			generationOptions.Append(')');

			return generationOptions.ToString();
		}
	}
	public class BiomeFeatureGenerationOptions : StructureGenerationOptions
	{
		private int _distance;
		public int Distance
		{
			get { return _distance; }
			set
			{
				if (value < 9)
					value = 9;

				_distance = value;
			}
		}

		public BiomeFeatureGenerationOptions()
		{
			_distance = 32;
		}

		protected override string BuildGenerationOptions()
		{
			StringBuilder generationOptions = new StringBuilder("biome_1(");
			generationOptions.Append("distance=");
			generationOptions.Append(_distance.ToString());
			generationOptions.Append(')');

			return generationOptions.ToString();
		}
	}
	public class DungeonGenerationOptions : StructureGenerationOptions
	{
		protected override string BuildGenerationOptions()
		{
			return "dungeon";
		}
	}
	public class DecorationGenerationOptions : StructureGenerationOptions
	{
		protected override string BuildGenerationOptions()
		{
			return "decoration";
		}
	}
	public class LakeGenerationOptions : StructureGenerationOptions
	{
		protected override string BuildGenerationOptions()
		{
			return "lake";
		}
	}
	public class LavaLakeGenerationOptions : StructureGenerationOptions
	{
		protected override string BuildGenerationOptions()
		{
			return "lava_lake";
		}
	}
	public class OceanMonumentGenerationOptions : StructureGenerationOptions
	{
		protected override string BuildGenerationOptions()
		{
			return "oceanmonument";
		}
	}
}
