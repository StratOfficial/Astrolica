using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Astrolica.Content.Items
{
	public class Soul_Extractor : ModItem
	{
        //item.ModItem is Soul_Sword soulSword

        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
            Recipe soulextractorTungsten = Recipe.Create(ModContent.ItemType<Content.Items.Soul_Extractor>());
            soulextractorTungsten.AddIngredient(ItemID.Diamond, 10);
            soulextractorTungsten.AddIngredient(ItemID.Extractinator, 1);
            soulextractorTungsten.Register();
        }
	}
}