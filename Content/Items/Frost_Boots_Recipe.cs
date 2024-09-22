using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Astrolica.Content.Items
{
	public class FrostBootsRecipe : ModSystem
	{
		public override void AddRecipes()
		{
			Recipe Frost_Boots = Recipe.Create(ModContent.ItemType<Content.Items.Frost_Boots>());
			Frost_Boots.AddIngredient(ModContent.ItemType<Content.Items.Frost_Shard>(), 30);
			Frost_Boots.Register();
		}
	}
}