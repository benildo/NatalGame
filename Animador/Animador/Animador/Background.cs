using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Natal
{
    public class Background 
    {
        
        Texture2D textura;
        Vector2 posicao;

        public Rectangle boundingBox;
        public void Initialize()
        {
            posicao = new Vector2(0, 0);
        }

        public void LoadContent(ContentManager Content)
        {
            textura = Content.Load<Texture2D>(@"Scenario\background");
        }

        public void Update()
        {
            boundingBox = new Rectangle(0, 480, textura.Width, textura.Height); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, posicao, Color.White);
        }
    }
}
