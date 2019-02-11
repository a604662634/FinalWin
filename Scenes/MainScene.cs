using CGame.Utils;
using CLEngine;
using CLEngine.ECS;
using CLEngine.ECS.Components.Renderables.Sprites;
using CLEngine.Graphics;
using CLEngine.Graphics.PostProcessing;
using CLEngine.Graphics.Renderers;
using CLEngine.Utils.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CGame.Scenes
{
	public class MainScene : Scene, IFinalRenderDelegate
	{
		public MainScene()
		{
			finalRenderDelegate = this;

			addRenderer(new DefaultRenderer());
		}

		public void onAddedToScene()
		{
			var player = createEntity("gjs").setPosition(0, 1000);
			player.addComponent(new Sprite<PlayerIdle>()).addAnimation(PlayerIdle.Stand,
					CharaterManager.LoadPlayerIdle(PlayerIdle.Stand, CharaterManager.GjsAtlas))
				.play(PlayerIdle.Stand)
				.setPingPong(true);

			var monster = createEntity("monster").setPosition(1500, 1000);
			var monsterSprite = monster.addComponent(new Sprite<MonsterIdle>()).addAnimation(MonsterIdle.Stand,
					CharaterManager.LoadMonsterIdle(MonsterIdle.Stand, CharaterManager.YmrStandAtlas));
			monsterSprite.flipX = true;
			monsterSprite.play(MonsterIdle.Stand);

			camera.rawZoom = 0.40f;
		}

		public void onSceneBackBufferSizeChanged(int newWidth, int newHeight)
		{
		}

		public void handleFinalRender(Color letterboxColor, RenderTarget2D source, Rectangle finalRenderDestinationRect,
			SamplerState samplerState)
		{
			Core.graphicsDevice.SetRenderTarget(null);
			Core.graphicsDevice.Clear(letterboxColor);

			Graphics.instance.batcher.begin(BlendState.NonPremultiplied, samplerState, DepthStencilState.Default,
				RasterizerState.CullNone);
			Graphics.instance.batcher.draw(source, finalRenderDestinationRect);
			Graphics.instance.batcher.end();
		}

		public Scene scene { get; set; }
	}
}