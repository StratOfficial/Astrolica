using Microsoft.Build.Tasks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Astrolica.Content.Items
{
    public class BomberangProjectile : ModProjectile
    {
        bool hitEnemy = false;
        int time = 0;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.height = 16;
            Projectile.width = 16;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
        }


        public override void PrepareBombToBlow()
        {
            base.PrepareBombToBlow();
            Projectile.Resize(60, 60);
            Projectile.alpha = 255;
            Projectile.timeLeft = 4;
            Projectile.hostile = true;
            SoundEngine.PlaySound(SoundID.DD2_GoblinBomb, Projectile.position);
        }

        public override void AI()
        {
            base.AI();

            if (Projectile.ai[2] > 4)
            {
                Projectile.aiStyle = ProjAIStyleID.Boomerang;
            }

            PostAI();
            if (!hitEnemy)
            {
                Projectile.ai[2]++;
                if (Projectile.ai[2] > 160)
                {
                    Projectile.PrepareBombToBlow();
                    hitEnemy = true;
                }
            }
            else
            {
                Projectile.velocity = Vector2.Zero;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!hitEnemy)
            {
                Projectile.PrepareBombToBlow();
                Projectile.aiStyle = 0;
                hitEnemy = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity *= -1;
            Projectile.netUpdate = true;
            Projectile.ai[0] = 1;
            Projectile.tileCollide = false;
            Player player = Main.player[Projectile.owner];
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

            if (Projectile.Colliding(player.getRect(), Projectile.getRect()))
            {
                return true;
            }
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            base.OnKill(timeLeft);
            if (!hitEnemy)
            {
                int item = Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<Bomberang>());
            }
            else
            {
                Projectile.Resize(16, 16);

                for (int i = 0; i < 3; i++)
                {
                    var smoke = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                    smoke.velocity *= 1.4f;
                }

                for (int j = 0; j < 3; j++)
                {
                    var fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3.5f);
                    fireDust.noGravity = true;
                    fireDust.velocity *= 7f;
                    fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                    fireDust.velocity *= 3f;
                }

                for (int k = 0; k < 1; k++)
                {
                    float speedMulti = 0.4f;
                    if (k == 1)
                    {
                        speedMulti = 0.8f;
                    }

                    var smokeGore = Gore.NewGoreDirect(Projectile.GetSource_Death(), Projectile.position, default, Main.rand.Next(GoreID.Smoke1, GoreID.Smoke3 + 1));
                    smokeGore.velocity *= speedMulti;
                    smokeGore.velocity += Vector2.One;
                    smokeGore = Gore.NewGoreDirect(Projectile.GetSource_Death(), Projectile.position, default, Main.rand.Next(GoreID.Smoke1, GoreID.Smoke3 + 1));
                    smokeGore.velocity *= speedMulti;
                    smokeGore.velocity.X -= 1f;
                    smokeGore.velocity.Y += 1f;
                    smokeGore = Gore.NewGoreDirect(Projectile.GetSource_Death(), Projectile.position, default, Main.rand.Next(GoreID.Smoke1, GoreID.Smoke3 + 1));
                    smokeGore.velocity *= speedMulti;
                    smokeGore.velocity.X += 1f;
                    smokeGore.velocity.Y -= 1f;
                    smokeGore = Gore.NewGoreDirect(Projectile.GetSource_Death(), Projectile.position, default, Main.rand.Next(GoreID.Smoke1, GoreID.Smoke3 + 1));
                    smokeGore.velocity *= speedMulti;
                    smokeGore.velocity -= Vector2.One;
                }
            }
        }
    }
}