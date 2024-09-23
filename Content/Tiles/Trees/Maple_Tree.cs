using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace Astrolica.Content.Tiles
{
    public class Maple_Tree : ModTree
    {

        int tree_type = Main.rand.Next(1, 4);

        private Asset<Texture2D> TreeTexture;
        private Asset<Texture2D> Branches;
        private Asset<Texture2D> Tops;

        public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
        {
            UseSpecialGroups = true,
            SpecialGroupMinimalHueValue = 11f / 72f,
            SpecialGroupMaximumHueValue = 0.25f,
            SpecialGroupMinimumSaturationValue = 0.00f,
            SpecialGroupMaximumSaturationValue = 1f
        };

        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[1] { TileID.Dirt };
            TreeTexture = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Trees/Maple_Tree");
            Branches = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Trees/Maple_Branches2");
            Tops = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Trees/Maple_Tree_Top2");
        }

        public override Asset<Texture2D> GetTexture()
        {
            return TreeTexture;
        }

        public override Asset<Texture2D> GetBranchTextures()
        {
            return Branches;
        }

        public override Asset<Texture2D> GetTopTextures()
        {
            return Tops;
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int TopTextureFrameHeight )
        {

        }

        public override int DropWood()
        {
            return ItemID.Acorn;
        }

        public override int TreeLeaf()
        {
            return GoreID.TreeLeaf_Normal;
        }
    }
}