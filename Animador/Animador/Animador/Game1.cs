using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Natal
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Background background;        
        Player player;
        HUD hud;
        Present coin1, coin2, coin3;

        enum GameState { Start, InGame, GameOver };
        GameState currentGameState = GameState.Start;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;
        }

       
        protected override void Initialize()
        {
            background = new Background();
            background.Initialize();
            coin1 = new Present(new Vector2(50, 0));
            coin1.Initialize(6);
            coin2 = new Present(new Vector2(200, 0));
            coin2.Initialize(3);
            coin3 = new Present(new Vector2(350, 0));
            coin3.Initialize(9);
            player = new Player();
            player.Initialize();
            hud = new HUD();
            hud.Initialize();                       

            base.Initialize();
        }

        
        protected override void LoadContent()
        {            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background.LoadContent(Content);
            coin1.LoadContent(Content);
            coin2.LoadContent(Content);
            coin3.LoadContent(Content);
            player.LoadContent(Content);
            hud.LoadContent(Content);  
        }

     

        protected override void Update(GameTime gameTime)
        {            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            coin1.Update();
            coin2.Update();
            coin3.Update();
            player.Update();
            hud.Update(gameTime);

            switch (currentGameState)
            {
                case GameState.Start:
                    KeyboardState state = Keyboard.GetState();
                    if (state.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.InGame;
                    }

                    break;
                case GameState.InGame:

                    Random random = new Random();

                    if (coin1.boundingBox.Intersects(player.boundingBox))
                    {
                        hud.valor++;
                        coin1.visivel = false;
                        coin1.posicao.Y = 0;
                        coin1.velocidade = random.Next(7, 15);

                    }
                    else { coin1.visivel = true; }

                    if (coin2.boundingBox.Intersects(player.boundingBox))
                    {
                        hud.valor++;
                        coin2.visivel = false;
                        coin2.posicao.Y = 0;
                        coin2.velocidade = random.Next(7, 15);
                    }
                    else { coin2.visivel = true; }

                    if (coin3.boundingBox.Intersects(player.boundingBox))
                    {
                        hud.valor++;
                        coin3.visivel = false;
                        coin3.posicao.Y = 0;
                        coin3.velocidade = random.Next(7, 15);
                    }
                    else { coin3.visivel = true; }
                    if (hud.tempo == 0)
                    {
                        currentGameState = GameState.GameOver;
                    }

                    break;                   

                case GameState.GameOver:
                    
                    break;
            }          

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            background.Draw(spriteBatch);

            switch (currentGameState)
            {
                case GameState.Start:
                    hud.DrawStart(spriteBatch);
                    break;
                case GameState.InGame:
                    
                    coin1.Draw(spriteBatch);
                    coin2.Draw(spriteBatch);
                    coin3.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    hud.Draw(spriteBatch);

                    break;
                case GameState.GameOver:
                    hud.DrawGameOver(spriteBatch);
                    break;
            }
            
            spriteBatch.End();            

            base.Draw(gameTime);
        }
    }
}
