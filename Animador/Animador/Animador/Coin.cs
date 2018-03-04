using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Natal
{
    public class Present
    {
        public Vector2 posicao;    
        public float velocidade;
        Texture2D textura;
        Random random;
        public Rectangle boundingBox;
        public bool visivel;

        public Present (Vector2 posicaoInicial)
        {
            posicao = posicaoInicial;
        }

        public void Initialize(float velocidadeInicial)
        {
            velocidade = velocidadeInicial;
            visivel = true;            
        }

        public void LoadContent(ContentManager Content)
        {
            textura = Content.Load<Texture2D>(@"Scenario\presente");
        }

        public void Update()
        {            
            posicao.Y = posicao.Y + velocidade;
            if (posicao.Y > 800)
            {
                random = new Random();
                velocidade = random.Next(3, 6);
                posicao.Y = 0;
            }            
            
            boundingBox = new Rectangle((int)posicao.X, (int)posicao.Y, textura.Width, textura.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(visivel)
            spriteBatch.Draw(textura, posicao, Color.White);

        }
    }
}
