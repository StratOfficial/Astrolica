using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace Astrolica.Content.Tiles
{
    public class MapleTree : ModTree
    {

        int tree_type = Main.rand.Next(1, 4);

        private Asset<Texture2D> texture;
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
            GrowsOnTileId = new int[1] { TileID.Grass };
            texture = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Plants/Maple_Tree");

            if(tree_type == 1) {
                Branches = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Plants/Maple_Branches1");
                Tops = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Plants/Maple_Tree_Top1");
            }
            if(tree_type == 2) {
                Branches = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Plants/Maple_Branches2");
                Tops = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Plants/Maple_Tree_Top2");
            }
            if(tree_type == 3) {
                Branches = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Plants/Maple_Branches3");
                Tops = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Plants/Maple_Tree_Top3");
            }
            if(tree_type == 4) {
                Branches = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Plants/Maple_Branches4");
                Tops = ModContent.Request<Texture2D>("Astrolica/Content/Tiles/Plants/Maple_Tree_Top4");
            }



        }

        public override Asset<Texture2D> GetTexture()
        {
            return texture;
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int TopTextureFrameHeight )
        {

        }

        public override Asset<Texture2D> GetBranchTextures() => Branches;

        public override Asset<Texture2D> GetTopTextures() => Tops;

        public override int DropWood()
        {
            return ItemID.Wood;
        }

        public override int TreeLeaf()
        {
            return GoreID.TreeLeaf_Normal;
        }
    }
}