using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;

namespace Astrolica.Content.Items
{
	public class Frost_Boots : ModItem
	{
		public override void SetDefaults()
        {
			Item.width = 34;
			Item.height = 28;

			Item.accessory = true;
		}

		public override void UpdateEquip(Player player)
        {
            if(!player.wet)
            {
                if (!player.controlDownHold)
                {
                    Vector2 feetPosition = player.Bottom;
                    Tile tile = Framing.GetTileSafely(feetPosition + new Vector2(0, 12));
                    Tile tileSurface = Framing.GetTileSafely(feetPosition - new Vector2(0, 4));

                    if (tile.TopSlope || tile.IsHalfBlock)
                    {
                        tile = Framing.GetTileSafely(feetPosition + new Vector2(16 * player.direction, 12));
                        tileSurface = Framing.GetTileSafely(feetPosition - new Vector2(16 * player.direction, 4));
                    }

                    if (tile.TileType != TileID.BreakableIce && tile.LiquidType == LiquidID.Water && tile.LiquidAmount > 0 && tileSurface.LiquidAmount == 0)
                    {
                        byte WaterAmt = tile.LiquidAmount;
                        tile.ResetToType(TileID.BreakableIce);
                        tile.LiquidAmount = WaterAmt;
                    }
                }
            }
        }
    }
}