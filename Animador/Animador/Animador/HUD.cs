using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Natal
{
    public class HUD
    {
        SpriteFont fonte;
        Vector2 posicaoPontos;
        Vector2 posicaoTempo;
        public int valor;
        public float tempo;

        public void Initialize()
        {
            posicaoPontos = new Vector2(245, 725);
            posicaoTempo = new Vector2(30, 725);
            tempo = 30;
            valor = 0;
        }

        public void LoadContent(ContentManager Content)
        {
            fonte = Content.Load<SpriteFont>("font");

        }

        public void Update(GameTime gameTime)
        {
            tempo -=(float)gameTime.ElapsedGameTime.TotalSeconds;
            if (tempo<1)
            {
                tempo = 0;
            }
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(fonte, "Presentes  " + valor, posicaoPontos, Color.Gray);
            spriteBatch.DrawString(fonte, "Tempo  " + Math.Round(tempo, 0), posicaoTempo, Color.Red);

        }

        public void DrawStart(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(fonte, "Aperte Enter para jogar! ", new Vector2(25, 350) , Color.White);
        }
        public void DrawGameOver(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(fonte, "Conseguiu "+ valor + " presentes", new Vector2(25, 330), Color.Blue);
        }
        
    }


}
