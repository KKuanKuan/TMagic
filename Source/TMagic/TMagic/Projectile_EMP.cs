﻿using AbilityUser;
using RimWorld;
using Verse;

namespace TorannMagic
{
	public class Projectile_EMP : Projectile_AbilityBase
	{
        protected override void Impact(Thing hitThing)
        {
            Map map = base.Map;
            base.Impact(hitThing);
            ThingDef def = this.def;            
            GenExplosion.DoExplosion(base.Position, map, this.def.projectile.explosionRadius, this.def.projectile.damageDef, this.launcher, this.def.projectile.damageAmountBase, SoundDefOf.ArtilleryShellLoaded, def, this.equipmentDef, null, 0f, 1, false, null, 0f, 1, 0f, true);
            CellRect cellRect = CellRect.CenteredOn(base.Position, 6);
            cellRect.ClipInsideMap(map);
        }		
	}	
}


