using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate
{
	/// <summary>
	/// Represents options for the level generator of a flat world.
	/// </summary>
	public class LevelGeneratorOptions
	{
		public const string VERSION_STRING = "3";
		private List<BlockLayer> _blockLayers;

		public int BiomeID;

		public readonly VillageGenerationOptions VillageOptions = new VillageGenerationOptions();
		public readonly MineshaftGenerationOptions MineshaftOptions = new MineshaftGenerationOptions();
		public readonly StrongholdGenerationOptions StrongholdOptions = new StrongholdGenerationOptions();
		public readonly BiomeFeatureGenerationOptions BiomeFeatureOptions = new BiomeFeatureGenerationOptions();
		public readonly DungeonGenerationOptions DungeonOptions = new DungeonGenerationOptions();
		public readonly DecorationGenerationOptions DecorationOptions = new DecorationGenerationOptions();
		public readonly LakeGenerationOptions LakeOptions = new LakeGenerationOptions();
		public readonly LavaLakeGenerationOptions LavaLakeOptions = new LavaLakeGenerationOptions();
		public readonly OceanMonumentGenerationOptions OceanMonumentOptions = new OceanMonumentGenerationOptions();

		private StructureGenerationOptions[] _structureGenerationOptions;
	
		public LevelGeneratorOptions()
		{
			BiomeID = BiomeType.Forest;

			_blockLayers = new List<BlockLayer>();
			_structureGenerationOptions = new StructureGenerationOptions[]
			{
				VillageOptions, 
				MineshaftOptions,
				StrongholdOptions, 
				BiomeFeatureOptions,
				DungeonOptions,
				DecorationOptions,
				LakeOptions, 
				LavaLakeOptions,
				OceanMonumentOptions
			};
		}
		public LevelGeneratorOptions(string optionsString)
			: this()
		{
			string[] segments = optionsString.Split(';');
			if (segments.Length != 4)
				throw new FormatException("The given options string must contain 4 segments separated by semicolons.");

			string version = segments[0];
			if (version != VERSION_STRING)
				throw new FormatException("The given options string version segment must be \"" + VERSION_STRING + "\".");

			string[] blockLayers = segments[1].Split(',');
			if (blockLayers.Length < 1)
				throw new FormatException("The given options string must contain at least one block layer.");

			for (int i = 0; i < blockLayers.Length; i++)
			{
				string[] layerSegments = blockLayers[i].Split('*');
				if (layerSegments.Length == 1)
				{
					string[] valueSegments = layerSegments[0].Split(':');
					if (valueSegments.Length > 2 || valueSegments.Length == 0)
						throw new FormatException("The given options string contains an invalid block layer definition.");

					int blockId;
					int damageValue = 0;
					if (!int.TryParse(valueSegments[0], out blockId))
						throw new FormatException("The given options string contains a block layer that uses a non-numeric block id.");
					
					if(valueSegments.Length == 2)
					{
						if (!int.TryParse(valueSegments[1], out damageValue))
							throw new FormatException("The given options string contains a block layer that uses a non-numeric damage value.");
					}

					_blockLayers.Add(new BlockLayer(blockId, damageValue, 1));
				}
				else if (layerSegments.Length == 2)
				{
					string[] valueSegments = layerSegments[0].Split(':');
					if (valueSegments.Length > 2 || valueSegments.Length == 0)
						throw new FormatException("The given options string contains an invalid block layer definition.");

					int blockId;
					int damageValue = 0;
					if (!int.TryParse(valueSegments[0], out blockId))
						throw new FormatException("The given options string contains a block layer that uses a non-numeric block id.");

					if (valueSegments.Length == 2)
					{
						if (!int.TryParse(valueSegments[1], out damageValue))
							throw new FormatException("The given options string contains a block layer that uses a non-numeric damage value.");
					}

					int thickness;
					if (!int.TryParse(layerSegments[1], out thickness))
						throw new FormatException("The given options string contains a block layer that uses a non-numeric thickness value.");

					_blockLayers.Add(new BlockLayer(blockId, damageValue, thickness));
				}
				else
				{
					throw new FormatException("The given options string contains an invalid block layer definition.");
				}
			}

			if (!int.TryParse(segments[2], out BiomeID))
				throw new FormatException("The given options string contains a non-numeric biome id.");

			string[] structureOptions = segments[3].Split(',');
			for (int i = 0; i < structureOptions.Length; i++)
			{
				if (string.IsNullOrEmpty(structureOptions[i]))
					continue;

				int paramsStartIndex = structureOptions[i].IndexOf('(');
				int paramsEndIndex = structureOptions[i].IndexOf(')');

				string structureName;
				string[] structureParams;
				if (paramsStartIndex == -1 && paramsEndIndex == -1)
				{
					structureName = structureOptions[i];
					structureParams = new string[0];
				}
				else
				{
					structureName = structureOptions[i].Substring(0, paramsStartIndex);
					structureParams = structureOptions[i].Substring(paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1).Split(' ');
				}
				


				switch (structureName)
				{
					case "village":
						VillageOptions.Enabled = true;
						for (int j = 0; j < structureParams.Length; j++)
						{
							string[] keyValuePair = structureParams[j].Split('=');
							if (keyValuePair.Length != 2)
								throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");

							switch (keyValuePair[0])
							{
								case "size":
									if (!int.TryParse(keyValuePair[1], out VillageOptions.Size))
										throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");
									break;
								case "distance":
									int distance;
									if (!int.TryParse(keyValuePair[1], out distance))
										throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");

									VillageOptions.Distance = distance;
									break;
								default:
									throw new FormatException("The given options string contains a structure declaration with non-recognized parameter name \"" + keyValuePair[0] + "\" for a structure of type village.");
							}
						}
						break;
					case "mineshaft":
						MineshaftOptions.Enabled = true;
						for (int j = 0; j < structureParams.Length; j++)
						{
							string[] keyValuePair = structureParams[j].Split('=');
							if (keyValuePair.Length != 2)
								throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");

							switch (keyValuePair[0])
							{
								case "chance":
									float chance;
									if (!float.TryParse(keyValuePair[1], out chance))
										throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");

									MineshaftOptions.Chance = chance;
									break;
								default:
									throw new FormatException("The given options string contains a structure declaration with non-recognized parameter name \"" + keyValuePair[0] + "\" for a structure of type mineshaft.");
							}
						}
						break;
					case "stronghold":
						StrongholdOptions.Enabled = true;

						for (int j = 0; j < structureParams.Length; j++)
						{
							string[] keyValuePair = structureParams[j].Split('=');
							if (keyValuePair.Length != 2)
								throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");

							switch (keyValuePair[0])
							{
								case "count":
									if (!int.TryParse(keyValuePair[1], out StrongholdOptions.Count))
										throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");
									break;
								case "spread":
									int spread;
									if (!int.TryParse(keyValuePair[1], out spread))
										throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");

									StrongholdOptions.Spread = spread;
									break;
								case "distance":
									float distance;
									if (!float.TryParse(keyValuePair[1], out distance))
										throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");

									StrongholdOptions.Distance = distance;
									break;
								default:
									throw new FormatException("The given options string contains a structure declaration with non-recognized parameter name \"" + keyValuePair[0] + "\" for a structure of type stronghold.");
							}
						}
						break;
					case "biome_1":
						BiomeFeatureOptions.Enabled = true;
						for (int j = 0; j < structureParams.Length; j++)
						{
							string[] keyValuePair = structureParams[j].Split('=');
							if (keyValuePair.Length != 2)
								throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");

							switch (keyValuePair[0])
							{
								case "distance":
									int distance;
									if (!int.TryParse(keyValuePair[1], out distance))
										throw new FormatException("The given options string contains a structure declaration with an invalid parameter.");

									BiomeFeatureOptions.Distance = distance;
									break;
								default:
									throw new FormatException("The given options string contains a structure declaration with non-recognized parameter name \"" + keyValuePair[0] + "\" for a structure of type biome_1.");
							}
						}
						break;
					case "dungeon":
						DungeonOptions.Enabled = true;
						break;
					case "decoration":
						DecorationOptions.Enabled = true;
						break;
					case "lake":
						LakeOptions.Enabled = true;
						break;
					case "lava_lake":
						LavaLakeOptions.Enabled = true;
						break;
					case "oceanmonument":
						OceanMonumentOptions.Enabled = true;
						break;
					default:
						throw new FormatException("Unknown structure name \"" + structureName + "\" was found in options string.");
				}
			}
		}

		public string GetGeneratorOptions()
		{
			StringBuilder generatorOptions = new StringBuilder(VERSION_STRING);
			generatorOptions.Append(';');
			for (int i = 0; i < _blockLayers.Count; i++)
			{
				BlockLayer layer = _blockLayers[i];
				generatorOptions.Append(layer.BlockId.ToString());
				if (layer.DamageValue != 0)
				{
					generatorOptions.Append(':');
					generatorOptions.Append(layer.DamageValue.ToString());
				}
				if (layer.Thickness > 1)
				{
					generatorOptions.Append('*');
					generatorOptions.Append(layer.Thickness.ToString());
				}
				if((i + 1) < _blockLayers.Count)
					generatorOptions.Append(',');
			}
			generatorOptions.Append(';');
			generatorOptions.Append(BiomeID.ToString());
			generatorOptions.Append(';');
			for (int i = 0; i < _structureGenerationOptions.Length; i++)
			{
				generatorOptions.Append(_structureGenerationOptions[i].GetGenerationOptions());
				
				if ((i + 1) < _structureGenerationOptions.Length)
					generatorOptions.Append(',');
			}

			return generatorOptions.ToString();
		}
	}

	/// <summary>
	/// Represents a layer of blocks for the generation options of a superflat world.
	/// </summary>
	public struct BlockLayer
	{
		/// <summary>
		/// The id of the blocks the layer consists of.
		/// </summary>
		public readonly int BlockId;
		/// <summary>
		/// The damage value of the blocks in this layer.
		/// </summary>
		public readonly int DamageValue;
		/// <summary>
		/// The thickness of the layer.
		/// </summary>
		public readonly int Thickness;

		public BlockLayer(int blockId, int damageValue, int thickness)
		{
			if (thickness < 1)
				throw new ArgumentOutOfRangeException("Thickness of the block layer must be at least 1.");
			
			BlockId = blockId;
			DamageValue = damageValue;
			Thickness = thickness;
		}
	}
}
