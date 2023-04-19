using ReLogic.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using DestinyAwaits.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Inquisitors;

namespace DestinyAwaits.Projectiles
{
    public class WhisperBulletProjectile: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Whisper Bullet"); 
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; 
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 4; 
            Projectile.height = 4;
            Projectile.aiStyle = 1; 
            Projectile.friendly = true; 
            Projectile.hostile = false; 
            Projectile.DamageType = DamageClass.Ranged; 
            Projectile.penetrate = 1; 
            Projectile.timeLeft = 600; 
            Projectile.alpha = 255; 
            Projectile.light = 1f; 
            Projectile.ignoreWater = true; 
            Projectile.tileCollide = true; 

            AIType = ProjectileID.Bullet; 
            Projectile.velocity = Vector2.One;
            Projectile.extraUpdates = 2;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[Projectile.owner];
            GlobalPlayer ModPlayer = player.GetModPlayer<GlobalPlayer>();
            ModPlayer.WhisperShoot= false;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }
    }
}
