using Substrate.TileEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.Entities
{
    internal static class RegisterTileEntities
    {
        static RegisterTileEntities()
        {
            TileEntityFactory.Register(TileEntityEndPortal.TypeId, typeof(TileEntityEndPortal));
            TileEntityFactory.Register(TileEntityBeacon.TypeId, typeof(TileEntityBeacon));
            TileEntityFactory.Register(TileEntityBrewingStand.TypeId, typeof(TileEntityBrewingStand));
            TileEntityFactory.Register(TileEntityChest.TypeId, typeof(TileEntityChest));
            TileEntityFactory.Register(TileEntityControl.TypeId, typeof(TileEntityControl));
            TileEntityFactory.Register(TileEntityEnchantmentTable.TypeId, typeof(TileEntityEnchantmentTable));
            TileEntityFactory.Register(TileEntityFurnace.TypeId, typeof(TileEntityFurnace));
            TileEntityFactory.Register(TileEntityMobSpawner.TypeId, typeof(TileEntityMobSpawner));
            TileEntityFactory.Register(TileEntityMusic.TypeId, typeof(TileEntityMusic));
            TileEntityFactory.Register(TileEntityPiston.TypeId, typeof(TileEntityPiston));
            TileEntityFactory.Register(TileEntityRecordPlayer.TypeId, typeof(TileEntityRecordPlayer));
            TileEntityFactory.Register(TileEntitySign.TypeId, typeof(TileEntitySign));
            TileEntityFactory.Register(TileEntityTrap.TypeId, typeof(TileEntityTrap));
        }
    }
}
