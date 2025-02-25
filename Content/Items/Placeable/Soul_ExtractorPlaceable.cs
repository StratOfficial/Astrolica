using Astrolica.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Astrolica.Content.Items.Placeable
{
    public class Soul_ExtractorPlaceable : ModItem

    {
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Soul_ExtractorTile>(), 0);

            Item.width = 32;
			Item.height = 32;
			Item.placeStyle = 0;
        }

		public override void AddRecipes()
		{
            Recipe soulextractorTungsten = Recipe.Create(ModContent.ItemType<Content.Items.Placeable.Soul_ExtractorPlaceable>());
            soulextractorTungsten.AddIngredient(ItemID.Diamond, 10);
            soulextractorTungsten.AddIngredient(ItemID.Extractinator, 1);
            soulextractorTungsten.Register();
        }
    }
}