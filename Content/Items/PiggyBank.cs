using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Astrolica.Content.Items
{
	public class PiggyRecipe : ModSystem
	{
		public override void AddRecipes()
		{
			Recipe PiggyBank = Recipe.Create(ItemID.PiggyBank);
			PiggyBank.AddIngredient(ItemID.ClayBlock, 25);
			PiggyBank.Register();
		}
	}
}