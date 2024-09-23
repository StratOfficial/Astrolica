using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Astrolica.Content.Items
{
	public class Soul_Extractor : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			Recipe soulextractorSilver = Recipe.Create(ModContent.ItemType<Content.Items.Soul_Extractor>());
			soulextractorSilver.AddIngredient(ItemID.Diamond, 25);
			soulextractorSilver.AddIngredient(ItemID.SilverBar, 15);

            soulextractorSilver.AddRecipeGroup(RecipeGroupID.IronBar, 15);
            soulextractorSilver.Register();



            Recipe soulextractorTungsten = Recipe.Create(ModContent.ItemType<Content.Items.Soul_Extractor>());
            soulextractorTungsten.AddIngredient(ItemID.Diamond, 25);
            soulextractorTungsten.AddIngredient(ItemID.TungstenBar, 15);

            soulextractorTungsten.AddRecipeGroup(RecipeGroupID.IronBar, 15);
            soulextractorTungsten.Register();
        }
	}
}