﻿using Verse;
using AbilityUser;
using System.Linq;


namespace TorannMagic
{
    public class Projectile_TransferMana : Projectile_AbilityBase
    {
        protected override void Impact(Thing hitThing)
        {
            Map map = base.Map;
            base.Impact(hitThing);
            ThingDef def = this.def;

            Pawn hitPawn = hitThing as Pawn;
            Pawn caster = this.launcher as Pawn;
            CompAbilityUserMagic compHitPawn = hitPawn.GetComp<CompAbilityUserMagic>();            
            CompAbilityUserMagic compCaster = caster.GetComp<CompAbilityUserMagic>();

            if (hitPawn != null)
            {
                if (compHitPawn.IsMagicUser)
                {
                    MagicPowerSkill regen = hitPawn.GetComp<CompAbilityUserMagic>().MagicData.MagicPowerSkill_global_regen.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_global_regen_pwr");
                    compHitPawn.Mana.CurLevel += (.2f + (.01f * regen.level));
                    TM_MoteMaker.ThrowManaPuff(hitPawn.Position.ToVector3(), hitPawn.Map, 1f);
                    TM_MoteMaker.ThrowManaPuff(hitPawn.Position.ToVector3(), hitPawn.Map, 1f);
                }
                else
                {
                    float sev = Rand.Range(0, 10);
                    HealthUtility.AdjustSeverity(hitPawn, TorannMagicDefOf.TM_Manipulation, sev);
                    sev = Rand.Range(0, 10);
                    HealthUtility.AdjustSeverity(hitPawn, TorannMagicDefOf.TM_Movement, sev);
                    sev = Rand.Range(0, 10);
                    HealthUtility.AdjustSeverity(hitPawn, TorannMagicDefOf.TM_Breathing, sev);
                    sev = Rand.Range(0, 10);
                    HealthUtility.AdjustSeverity(hitPawn, TorannMagicDefOf.TM_Sight, sev);
                    TM_MoteMaker.ThrowManaPuff(hitPawn.Position.ToVector3(), hitPawn.Map, 1f);
                    TM_MoteMaker.ThrowManaPuff(hitPawn.Position.ToVector3(), hitPawn.Map, 1f);
                }
            }
        }
    }
}
