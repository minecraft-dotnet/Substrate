#using <System.dll>

using namespace Substrate;
using namespace Substrate::Core;

// This example replaces all instances of one block ID with another in a world.
// Substrate will handle all of the lower-level headaches that can pop up, such
// as maintaining correct lighting or replacing TileEntity records for blocks
// that need them.

// For a more advanced Block Replace example, see replace.cs in NBToolkit.

int main (array<System::String^>^ args) 
{
	if (args->Length != 3) {
        System::Console::WriteLine("Usage: BlockReplace <world> <before-id> <after-id>");
        return 0;
    }

    System::String^ dest = args[0];
    int before = System::Convert::ToInt32(args[1]);
    int after = System::Convert::ToInt32(args[2]);

	// Open our world
	NbtWorld^ world = NbtWorld::Open(dest);

	// The chunk manager is more efficient than the block manager for
    // this purpose, since we'll inspect every block
	IChunkManager^ cm = world->GetChunkManager();

	for each (ChunkRef^ chunk in cm) {
		// You could hardcode your dimensions, but maybe some day they
        // won't always be 16.  Also the CLR is a bit stupid and has
        // trouble optimizing repeated calls to Chunk.Blocks.xx, so we
		// cache them in locals
		int xdim = chunk->Blocks->XDim;
		int ydim = chunk->Blocks->YDim;
		int zdim = chunk->Blocks->ZDim;

		// x, z, y is the most efficient order to scan blocks (not that
        // you should care about internal detail)
		for (int x = 0; x < xdim; x++) {
			for (int z = 0; z < zdim; z++) {
				for (int y = 0; y < ydim; y++) {

					// Replace the block with after if it matches before
					if (chunk->Blocks->GetID(x, y, z) == before) {
						chunk->Blocks->SetData(x, y, z, 0);
						chunk->Blocks->SetID(x, y, z, after);
					}
				}
			}
		}

		// Save the chunk
		cm->Save();

		System::Console::WriteLine("Processed Chunk {0},{1}", chunk->X, chunk->Z);
	}

	return 0;
}