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
    public class BomberangProjectileOLD : ModProjectile
    {
        //Variables
        int maxSpeed = 8;

        //Constant
        bool hitEnemy = false;

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
            hitEnemy = true;
            Projectile.Resize(60, 60);
            Projectile.alpha = 255;
            Projectile.timeLeft = 4;
            Projectile.hostile = true;
        }

        public override void AI()
        {
            base.AI();
            Player player = Main.player[Projectile.owner];
            
            if (!hitEnemy)
            {
                if (Projectile.ai[0] > 180)
                {
                    Projectile.PrepareBombToBlow();
                    SoundEngine.PlaySound(SoundID.DD2_GoblinBomb, Projectile.position);
                }
                var smokeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100);
                smokeDust.scale *= 1f + Main.rand.Next(10) * 0.1f;
                smokeDust.velocity *= 0.2f;
                smokeDust.noGravity = true;
                Projectile.rotation += 0.4f;

                if (Projectile.ai[0] % 8 == 7)
                {
                    SoundEngine.PlaySound(SoundID.Item7, Projectile.position);
                }
                Projectile.ai[0] += 1;
                if (Projectile.tileCollide)
                {
                    if (Projectile.ai[0] >= 30)
                    {
                        Projectile.netUpdate = true;
                        Projectile.tileCollide = false;
                        Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero) * maxSpeed;
                    }
                }

                if (!Projectile.tileCollide)
                {
                    float length = Projectile.velocity.Length();
                    Vector2 playerTarget = (player.position - Projectile.position).SafeNormalize(Vector2.Zero);
                    Projectile.velocity += playerTarget / 1.4f;
                    if (length > maxSpeed)
                    {
                        Projectile.velocity = playerTarget * maxSpeed;
                    }
                    Projectile.netUpdate = true;

                    if (Projectile.Colliding(Projectile.getRect(), player.getRect()))
                    {
                        Projectile.Kill();
                    }
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
                SoundEngine.PlaySound(SoundID.DD2_GoblinBomb, Projectile.position);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity *= -1;
            Projectile.netUpdate = true;
            Projectile.tileCollide = false;
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
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

                for (int i = 0; i < 6; i++)
                {
                    var smoke = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                    smoke.velocity *= 1.4f;
                }

                for (int j = 0; j < 6; j++)
                {
                    var fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3.5f);
                    fireDust.noGravity = true;
                    fireDust.velocity *= 7f;
                    fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                    fireDust.velocity *= 3f;
                }

                for (int k = 0; k < 2; k++)
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