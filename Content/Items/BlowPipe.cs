using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Astrolica.Content.Items
{
	public class BlowPipeRecipe : ModSystem
	{
		public override void AddRecipes()
		{
			Recipe BlowPipe = Recipe.Create(ItemID.Blowpipe);
			BlowPipe.AddIngredient(ItemID.BambooBlock, 35);
			BlowPipe.Register();
		}
	}
}