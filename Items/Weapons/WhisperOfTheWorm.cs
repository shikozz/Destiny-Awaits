using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using IL.Terraria.Audio;
using DestinyAwaits.Projectiles;
using Inquisitors;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace DestinyAwaits.Items.Weapons
{
    class WhisperOfTheWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Whisper of the Worm");
            Tooltip.SetDefault("A Guardian's power makes a rich feeding ground." +
                "\nDo not be revolted." +
                "\nThere are parasites that may benefit the host..." +
                "\nteeth sharper than your own.");

        }
        public override void SetDefaults()
        {
            Item.damage = 1000;
            Item.width = 112;
            Item.height = 23;
            Item.autoReuse = false;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 4f;
            Item.noMelee= true;
            Item.rare = ItemRarityID.Red;
            Item.shootSpeed = 100f;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.UseSound = new Terraria.Audio.SoundStyle($"{nameof(DestinyAwaits)}/Sounds/WhisperShootSound") {
                PitchVariance = 0.2f,
                MaxInstances=0,
            };
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.buyPrice(platinum: 2);
            Item.crit = 0;
            Item.shoot = 1;
            Item.shootSpeed = 6.5f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void ModifyWeaponCrit(Player player, ref float crit)
        {
            if (player.GetModPlayer<GlobalPlayer>().WhisperShoot)
            {
                crit = 100;
            }
            else
            {
                crit = 0;
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, -2f);
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if(player.GetModPlayer<GlobalPlayer>().WhisperShoot)
            {
               
            }
            return true;
        }

        public override void UseAnimation(Player player)
        {
            if (player.GetModPlayer<GlobalPlayer>().WhisperShoot)
            {
                for (int i = 0; i <= 10; i++)
                {
                    int dust2 = Dust.NewDust(new Vector2(player.Center.X - 30, player.Center.Y - 30), 60, 60, DustID.LastPrism, 0f, 0f, 0, Color.White, 1.5f);
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].velocity *= 0.2f;

                }
            }
        }  
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (player.GetModPlayer<GlobalPlayer>().WhisperShoot)
            {
                if (type == ProjectileID.Bullet)
                {
                    type = ModContent.ProjectileType<WhisperBulletProjectile>();
                    damage *= 4;
                }
            }
            else
            {
                if (type == ProjectileID.Bullet)
                {
                    type = ModContent.ProjectileType<SolarBulletProjectile>();
                }
            }
            Vector2 offset = velocity * 9.5f;
            position += offset;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarBar, 20)
                .AddIngredient(ItemID.SniperRifle)
                .AddTile(TileID.LunarMonolith)
                .Register();
        }
    }
}
