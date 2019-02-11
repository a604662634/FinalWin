using CGame.Scenes;
using CGame.Utils;
using CLEngine;
using FairyGUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CGame
{
	/// <summary>
	/// 主游戏入口 执行顺序:
	///	Initialize -> LoadContent -> Update -> Draw -> ... -> UnLoadContent
	/// </summary>
	public partial class Game1 : Core
	{
#if FairyGui
		public Stage Stage { get; set; }
#endif

		/// <summary>
		/// 初始化游戏
		/// </summary>
		protected override void Initialize()
		{
#if FairyGui
			Stage = new Stage(this);
			Components.Add(Stage);
#endif

			base.Initialize();

			var mainScene = new MainScene();
			scene = mainScene;
		}

		/// <summary>
		/// 加载资源
		/// </summary>
		protected override void LoadContent()
		{
			base.LoadContent();

			CharaterManager.LoadAtlas();
		}

		/// <summary>
		/// 绘制逻辑
		/// </summary>
		/// <param name="gameTime"></param>
		protected override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);

#if FairyGui
			Stage.Draw(gameTime);
#endif
		}

		/// <summary>
		/// 更新逻辑
		/// </summary>
		/// <param name="gameTime"></param>
		protected override void Update(GameTime gameTime)
		{
#if FairyGui
			Stage.Update(gameTime);
#endif

			base.Update(gameTime);
		}

		/// <summary>
		/// 卸载资源
		/// </summary>
		protected override void UnloadContent()
		{
			base.UnloadContent();
		}
	}
}