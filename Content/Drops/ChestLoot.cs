using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Astrolica.Content.Drops
{
	public class ChestSpawn : ModSystem
	{
		public override void PostWorldGen()
		{
			int itemsToPlaceInChestsChoice = 0;

			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				int[] itemsToPlaceInChestsChoice4 = { Mod.Find<ModItem>("Frost_Shard").Type };
				int Frost_ShardNum = Main.rand.Next(8, 12);

				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 11 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == 0) continue;
						
						chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChestsChoice4[itemsToPlaceInChestsChoice]);
						chest.item[inventoryIndex].stack = Frost_ShardNum;
						itemsToPlaceInChestsChoice = (itemsToPlaceInChestsChoice + 1) % itemsToPlaceInChestsChoice4.Length;
						inventoryIndex++;
						break;
						
					}
				}
			}
		}
	}
}