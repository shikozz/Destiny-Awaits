using Inquisitors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DestinyAwaits.Buffs
{
    public class WhisperBuff : ModBuff
    {
        public GlobalPlayer playerMod;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xol waits");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            playerMod = player.GetModPlayer<GlobalPlayer>();
            Description.SetDefault("Counts registered "+player.GetModPlayer<GlobalPlayer>().HitCounts);
        }

        public override void Unload()
        {

        }

        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            tip = ("Hits on enemies " + playerMod.HitCounts);
        }
    }
}
