namespace Substrate.World
{
    public interface IBiomeCollection
    {
        int GetBiome(int x, int z);
        void SetBiome(int x, int z, int newBiome);
    }
}