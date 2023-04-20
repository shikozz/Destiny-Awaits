using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using DestinyAwaits.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using IL.Terraria.Graphics.CameraModifiers;
using DestinyAwaits.Buffs;
using Terraria.Audio;

namespace Inquisitors
{
    public class GlobalPlayer:ModPlayer
    {
        public bool WhisperShoot = false;
        public int HitCounts = 0;
        public bool WhisperBool = false;
        public bool WhisperSound = false;
        SoundStyle chargeSound = new SoundStyle($"{nameof(DestinyAwaits)}/Sounds/WhisperCharged")
        {
            PitchVariance = 0.2f,
            MaxInstances = 0,
        };

        public override void PostUpdate()
        {
            if (Player.HeldItem.type == ModContent.ItemType<WhisperOfTheWorm>())
            {
                if (!WhisperBool)
                {
                    WhisperSound = true;
                    int wpbuff = ModContent.BuffType<WhisperBuff>();
                    Player.AddBuff(wpbuff, 2);
                }
                else
                {
                    int wpbuff = ModContent.BuffType<WhisperBuffCharged>();
                    Player.AddBuff(wpbuff, 2);
                    if(WhisperSound)
                    {
                        for (int i = 0; i <= 100; i++)
                        {
                            SoundEngine.PlaySound(chargeSound);
                        }
                        WhisperSound= false;
                    }
                }
            }
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

