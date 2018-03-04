using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Natal
{
    public class Player
    {
        Texture2D textura;
        Vector2 posicao;
        public Rectangle boundingBox;

        public void Initialize()
        {
            posicao = new Vector2(180, 500);
        }

        public void LoadContent(ContentManager Content)
        {
            textura = Content.Load<Texture2D>(@"Player\noel"); 
        }

        public void Update()
        {
            posicao.X = 180;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                posicao.X = 25;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                posicao.X = 310;
            }
            boundingBox = new Rectangle((int)posicao.X,(int)posicao.Y, textura.Width, textura.Height);      

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, posicao, Color.White);

        }
    }
}
