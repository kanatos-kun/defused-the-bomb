using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace defused_the_bomb
{

    class GameScreen : GameManager
    {
        spriteManager background_image;

        spriteManager module_wire;
        spriteManager module_bomb;

        GuiButton wire_01;
        GuiButton wire_02;
        GuiButton wire_03;
        GuiButton wire_04;
        GuiButton wire_05;
        GuiButton wire_06;

        public override void ContentLoad(ContentManager Content)
        {
            scene = "gameScreen";

            background_image = new spriteManager(0,Vector2.Zero,Content);
            module_wire = new spriteManager(9, new Vector2(187, 201), Content);
            module_bomb = new spriteManager(24, new Vector2(386,201), Content);

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
            //Module wire
            //-----------------------------------------------------------------
            wire_01.update(gameTime);
            wire_02.update(gameTime);
            wire_03.update(gameTime);
            wire_04.update(gameTime);
            wire_05.update(gameTime);
            wire_06.update(gameTime);


            if (wire_02.timer.stop)
                transition = "GameOverScreen";
            if (wire_03.timer.stop)
                transition = "GameWinScreen";


            if (wire_01.click())
            {
                wire_01.image = spriteManager.Instance.Tblimage[21];
            }
            if (wire_02.click())
            {
                wire_02.image = spriteManager.Instance.Tblimage[19];
            }
            if (wire_03.click())
            {
                wire_03.image = spriteManager.Instance.Tblimage[17];
            }
            if (wire_04.click())
            {
                wire_04.image = spriteManager.Instance.Tblimage[15];
            }
            if (wire_05.click())
            {
                wire_05.image = spriteManager.Instance.Tblimage[13];
            }
            if (wire_06.click())
            {
                wire_06.image = spriteManager.Instance.Tblimage[11];
            }
            //-----------------------------------------------------------------

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background_image.image,background_image.position,Color.White);

            spriteBatch.Draw(module_wire.image, module_wire.position, Color.White);
            spriteBatch.Draw(module_bomb.image, module_bomb.position, Color.White);


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
