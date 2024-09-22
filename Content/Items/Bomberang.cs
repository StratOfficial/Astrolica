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
    public class Bomberang : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.CloneDefaults(ItemID.Grenade);
            Item.shoot = ModContent.ProjectileType<BomberangProjectile>();
            Item.shootSpeed = 7;
            Item.scale = 0.7f;
            Item.useAnimation = 32;
            Item.useTime = Item.useAnimation;
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            Recipe Bomberang = Recipe.Create(ModContent.ItemType<Content.Items.Bomberang>());
            Bomberang.AddIngredient(ItemID.Wood, 2);
            Bomberang.AddIngredient(ItemID.Gel, 1);
            Bomberang.AddIngredient(ItemID.Grenade, 1);
            Bomberang.Register();
        }
    }
}
