using System.Collections.Generic;
using CLEngine;
using CLEngine.ECS.Components.Renderables.Sprites;
using CLEngine.Graphics.Textures;
using CLEngine.PipelineRuntime.TexturePacker;

namespace CGame.Utils
{
	public static class CharaterManager
	{
		/// <summary>
		/// 弓箭手图集
		/// </summary>
		public static TexturePackerAtlas GjsAtlas;
		/// <summary>
		/// 野蛮人站立图集
		/// </summary>
		public static TexturePackerAtlas YmrStandAtlas;

		/// <summary>
		/// 加载图集
		/// </summary>
		public static void LoadAtlas()
		{
			GjsAtlas = Core.content.Load<TexturePackerAtlas>("mainRole/main_gjs");
			YmrStandAtlas = Core.content.Load<TexturePackerAtlas>("mainMonster/main_ymr");
		}

		/// <summary>
		/// 加载玩家动作
		/// </summary>
		public static SpriteAnimation LoadPlayerIdle(PlayerIdle idle, TexturePackerAtlas atlas)
		{
			switch (idle)
			{
				case PlayerIdle.Stand:
					return new SpriteAnimation(LoadTextureList(atlas, 0, 3));
				default:
					return null;
			}
		}

		private static List<Subtexture> LoadTextureList(TexturePackerAtlas atlas, int startIndex, int endIndex)
		{
			var textures = new List<Subtexture>();
			for (int i = startIndex; i < endIndex; i++)
			{
				textures.Add(atlas.subtextures[i]);
			}

			return textures;
		}

		public static SpriteAnimation LoadMonsterIdle(MonsterIdle idle, TexturePackerAtlas atlas)
		{
			switch (idle)
			{
				case MonsterIdle.Stand:
					return new SpriteAnimation(LoadTextureList(atlas, 0, 7));
				default:
					return null;
			}
		}


	}
}