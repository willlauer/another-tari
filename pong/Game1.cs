using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pong;

public class Game1 : Game
{
    Texture2D ballTexture;
    private GraphicsDeviceManager graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    #region Constants
    private const int GameWindowHeight = 1000;
    private const int GameWindowWidth = 800;
    private const int BallDimension = 100;
    #endregion

    #region Derived
    private float ballScale = 1.0f;
    #endregion

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        // Set up the screen dimensions
        // https://stackoverflow.com/questions/20157064/how-do-i-set-a-fixed-window-size-in-monogame
        graphics.IsFullScreen = false;
        graphics.PreferredBackBufferHeight = GameWindowHeight;
        graphics.PreferredBackBufferWidth = GameWindowWidth;
        graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        ballTexture = Content.Load<Texture2D>("sphere");
        ballScale = BallDimension * 1.0f / Math.Min(ballTexture.Width, ballTexture.Height);
        Debug.WriteLine($"{ballScale}");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        // this.Window.AllowUserResizing = true;

        // Debug.WriteLine($"Texture height: {ballTexture.Height}, Screen height: {GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height}, GameWindow Height: {this.Window.ClientBounds.Height}");

        _spriteBatch.Draw(ballTexture,
                       new Rectangle(0, 0, (int)(ballTexture.Width * ballScale), (int)(ballTexture.Height * ballScale)),
                       new Rectangle(0, 0, ballTexture.Width, ballTexture.Height),
                       Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
