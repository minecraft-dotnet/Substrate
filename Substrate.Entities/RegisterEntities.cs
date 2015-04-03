using System;
using System.Collections.Generic;

namespace Substrate.Entities
{
    internal static class RegisterEntities
    {
        static RegisterEntities()
        {
            EntityFactory.Register(EntityArrow.TypeId, typeof(EntityArrow));
            EntityFactory.Register(EntityBlaze.TypeId, typeof(EntityBlaze));
            EntityFactory.Register(EntityBoat.TypeId, typeof(EntityBoat));
            EntityFactory.Register(EntityCaveSpider.TypeId, typeof(EntityCaveSpider));
            EntityFactory.Register(EntityChicken.TypeId, typeof(EntityChicken));
            EntityFactory.Register(EntityCow.TypeId, typeof(EntityCow));
            EntityFactory.Register(EntityCreeper.TypeId, typeof(EntityCreeper));
            EntityFactory.Register(EntityEgg.TypeId, typeof(EntityEgg));
            EntityFactory.Register(EntityEnderDragon.TypeId, typeof(EntityEnderDragon));
            EntityFactory.Register(EntityEnderman.TypeId, typeof(EntityEnderman));
            EntityFactory.Register(EntityEnderEye.TypeId, typeof(EntityEnderEye));
            EntityFactory.Register(EntityFallingSand.TypeId, typeof(EntityFallingSand));
            EntityFactory.Register(EntityFireball.TypeId, typeof(EntityFireball));
            EntityFactory.Register(EntityGhast.TypeId, typeof(EntityGhast));
            EntityFactory.Register(EntityGiant.TypeId, typeof(EntityGiant));
            EntityFactory.Register(EntityItem.TypeId, typeof(EntityItem));
            EntityFactory.Register(EntityMagmaCube.TypeId, typeof(EntityMagmaCube));
            EntityFactory.Register(EntityMinecart.TypeId, typeof(EntityMinecart));
            EntityFactory.Register(EntityMob.TypeId, typeof(EntityMob));
            EntityFactory.Register(EntityMonster.TypeId, typeof(EntityMonster));
            EntityFactory.Register(EntityMooshroom.TypeId, typeof(EntityMooshroom));
            EntityFactory.Register(EntityPainting.TypeId, typeof(EntityPainting));
            EntityFactory.Register(EntityPig.TypeId, typeof(EntityPig));
            EntityFactory.Register(EntityPigZombie.TypeId, typeof(EntityPigZombie));
            EntityFactory.Register(EntityPrimedTnt.TypeId, typeof(EntityPrimedTnt));
            EntityFactory.Register(EntitySheep.TypeId, typeof(EntitySheep));
            EntityFactory.Register(EntitySilverfish.TypeId, typeof(EntitySilverfish));
            EntityFactory.Register(EntitySkeleton.TypeId, typeof(EntitySkeleton));
            EntityFactory.Register(EntitySlime.TypeId, typeof(EntitySlime));
            EntityFactory.Register(EntitySmallFireball.TypeId, typeof(EntitySmallFireball));
            EntityFactory.Register(EntitySnowball.TypeId, typeof(EntitySnowball));
            EntityFactory.Register(EntitySnowman.TypeId, typeof(EntitySnowman));
            EntityFactory.Register(EntitySpider.TypeId, typeof(EntitySpider));
            EntityFactory.Register(EntitySquid.TypeId, typeof(EntitySquid));
            EntityFactory.Register(EntityEnderPearl.TypeId, typeof(EntityEnderPearl));
            EntityFactory.Register(EntityVillager.TypeId, typeof(EntityVillager));
            EntityFactory.Register(EntityWolf.TypeId, typeof(EntityWolf));
            EntityFactory.Register(EntityXPOrb.TypeId, typeof(EntityXPOrb));
            EntityFactory.Register(EntityZombie.TypeId, typeof(EntityZombie));
        }
    }
}
