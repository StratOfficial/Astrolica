using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Astrolica.Content.Items
{
	public class Soul_Bottle : ModItem
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.width = 20;
			Item.height = 26;
			Item.maxStack = 999;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.placeStyle = 0;
		}

    }
}