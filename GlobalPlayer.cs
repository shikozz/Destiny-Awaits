using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using DestinyAwaits.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using IL.Terraria.Graphics.CameraModifiers;

namespace Inquisitors
{
    public class GlobalPlayer:ModPlayer
    {
        public bool WhisperShoot = false;
        public int HitCounts = 0;
        public override void PostUpdate()
        {
           
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            
        }

        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            
        }

        public override void ResetEffects()
        {

        }

        public override void PostUpdateEquips()
        {

        }
    }
}

