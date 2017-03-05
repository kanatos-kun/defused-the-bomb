using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace deminage_bombe
{

    class GameScreen : GameManager
    {
        spriteManager background_image;
        spriteManager module;

        GuiButton wire_01;
        GuiButton wire_02;
        GuiButton wire_03;
        GuiButton wire_04;
        GuiButton wire_05;
        GuiButton wire_06;

        public override void ContentLoad(ContentManager Content)
        {
            state = "gameScreen";

            background_image = new spriteManager(0,Vector2.Zero,Content);
            module = new spriteManager(9, new Vector2(187, 200), Content);

            wire_01 = new GuiButton(20, new Vector2(209, 218), Content);
            wire_02 = new GuiButton(18, new Vector2(238, 218), Content);
            wire_03 = new GuiButton(16, new Vector2(266, 218), Content);
            wire_04 = new GuiButton(14, new Vector2(294, 218), Content);
            wire_05 = new GuiButton(12, new Vector2(322, 218), Content);
            wire_06 = new GuiButton(10, new Vector2(350, 218), Content);
            base.ContentLoad(Content);
        }

        public GameScreen(ContentManager Content)
        {
            ContentLoad(Content);
        }

        public GameScreen()
        {

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (wire_01.click())
                wire_01.image = spriteManager.Instance.Tblimage[21];
            if (wire_02.click())
                wire_02.image = spriteManager.Instance.Tblimage[19];
            if (wire_03.click())
                wire_03.image = spriteManager.Instance.Tblimage[17];
            if (wire_04.click())
                wire_04.image = spriteManager.Instance.Tblimage[15];
            if (wire_05.click())
                wire_05.image = spriteManager.Instance.Tblimage[13];
            if (wire_06.click())
                wire_06.image = spriteManager.Instance.Tblimage[11];
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background_image.image,background_image.position,Color.White);
            spriteBatch.Draw(module.image, module.position, Color.White);

            spriteBatch.Draw(wire_01.image, wire_01.position, Color.White);
            spriteBatch.Draw(wire_02.image, wire_02.position, Color.White);
            spriteBatch.Draw(wire_03.image, wire_03.position, Color.White);
            spriteBatch.Draw(wire_04.image, wire_04.position, Color.White);
            spriteBatch.Draw(wire_05.image, wire_05.position, Color.White);
            spriteBatch.Draw(wire_06.image, wire_06.position, Color.White);

            base.Draw(spriteBatch);
        }

    }
}
