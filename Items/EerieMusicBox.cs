using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrawaves.Items
{
	public class EerieMusicBox : ModItem
	{	
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Music Box (Clotted Darkness/Blood Moon)");
		}
	
		public override void SetDefaults()
		{
			base.item.width = 32;
			base.item.height = 32;
			base.item.useTime = 20;
			base.item.useAnimation = 20;
			base.item.useStyle = 1;
			base.item.knockBack = 20f;
			base.item.rare = 4;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
			base.item.consumable = true;
			base.item.value = 0;
			base.item.maxStack = 999;
			base.item.createTile = base.mod.TileType("CDMusicBox");
		}
	}
}