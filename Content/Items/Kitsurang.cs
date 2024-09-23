using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Astrolica.Content.Items
{
    public class Kitsurang : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Trimarang);
            Item.rare = ItemRarityID.Orange;
            Item.shoot = ModContent.ProjectileType<KitsurangProjectile>();
            Item.useAnimation = 9;
            Item.useTime = 9;
            Item.scale = 1.3f;
            Item.damage = 9;
            Item.ArmorPenetration = 9;
            Item.shootSpeed = 9;
            Item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            Recipe Kitsurang = Recipe.Create(ModContent.ItemType<Content.Items.Kitsurang>());
            Kitsurang.AddIngredient(ItemID.Trimarang, 3);
            Kitsurang.Register();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<KitsurangProjectile>()] < 9;
        }
    }
}
