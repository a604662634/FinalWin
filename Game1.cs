using CGame.Scenes;
using CGame.Utils;
using CLEngine;
using FairyGUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CGame
{
	/// <summary>
	/// ����Ϸ��� ִ��˳��:
	///	Initialize -> LoadContent -> Update -> Draw -> ... -> UnLoadContent
	/// </summary>
	public partial class Game1 : Core
	{
#if FairyGui
		public Stage Stage { get; set; }
#endif

		/// <summary>
		/// ��ʼ����Ϸ
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
		/// ������Դ
		/// </summary>
		protected override void LoadContent()
		{
			base.LoadContent();

			CharaterManager.LoadAtlas();
		}

		/// <summary>
		/// �����߼�
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
		/// �����߼�
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
		/// ж����Դ
		/// </summary>
		protected override void UnloadContent()
		{
			base.UnloadContent();
		}
	}
}