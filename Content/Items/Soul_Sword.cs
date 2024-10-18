using Microsoft.Win32;
using MonoMod.Utils;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;



namespace Astrolica.Content.Items
{
    public class Soul_Sword : ModItem
    {
        int maxSouls = 300;
        static int[] damageMinMax = [10, 35];
        static int[] knockbackMinMax = [1, 10];

        public float Souls;

        float damageIncrease = damageMinMax[1] - damageMinMax[0];
        float knockbackIncrease = knockbackMinMax[1] - knockbackMinMax[0];

        public override void LoadData(TagCompound tag)
        {
            base.LoadData(tag);
            Souls = tag.Get<float>("Souls_collected");
        }

        public override void SaveData(TagCompound tag)
        {
            base.SaveData(tag);
            tag["Souls_collected"] = Souls;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1.3f;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.useAnimation = 20;
            Item.damage = damageMinMax[0];
            Item.knockBack = knockbackMinMax[0];
        }

        public override void AddRecipes()
        {
            Recipe Soul_Sword = Recipe.Create(ModContent.ItemType<Content.Items.Soul_Sword>());
            Soul_Sword.AddIngredient(ItemID.DirtBlock, 1);
            Soul_Sword.Register();
        }


        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            base.ModifyWeaponDamage(player, ref damage);
            float var  = maxSouls*0.2f;
            float var2 = maxSouls*0.4f;
            float normal = (1f / (float)Item.damage);

            if (Souls <= var)
            {
                damage *= 1 + (normal*( (Souls/maxSouls) * (damageIncrease*2f) ));
            }
            else if (Souls <= var2)
            {
                damage *= 1 + (normal*( (var / maxSouls) * (damageIncrease*2f) )) + (normal*( ((Souls-var)/maxSouls) * (damageIncrease*1.5f) ));
            }
            else
            {
                damage *= 1 + (normal*( (var / maxSouls) * (damageIncrease*2f) )) + (normal*( ((var2-var)/maxSouls)  * (damageIncrease*1.5f) )) + (normal*( ((Souls-var2-var)/maxSouls) * (damageIncrease * 0.5f) ));
            }
        }

        public override void ModifyWeaponKnockback(Player player, ref StatModifier knockback)
        {
            base.ModifyWeaponKnockback(player, ref knockback);
            float normal = (1f / (float)Item.knockBack);
            
            knockback += normal * ((Souls/maxSouls) * knockbackIncrease);
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(player, target, hit, damageDone);
            if (target.life <= 0)
            {
                if (Souls < maxSouls)
                {
                    Souls++;
                }
                Main.NewText("Souls: " + Souls);
            }
        }
    }
}