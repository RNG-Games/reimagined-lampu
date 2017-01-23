﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace reimagined_lampu
{
    class Death : IGameState
    {
        Texture2D background;

        public Death(ContentManager Content)
        {
            LoadContent(Content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: background, position: new Vector2(0, 0), scale: new Vector2(2.0f/3.0f,2.0f/3.0f), color: Color.White);
            spriteBatch.DrawString(GameStuff.Instance.arial, "You have died...", new Vector2(30), Color.White);
            spriteBatch.DrawString(GameStuff.Instance.arial, "Press Enter", new Vector2(30,660), Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("Death");
        }

        public EState Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                GameStuff.Instance.mainMenu.reset();
                GameStuff.setGameState(EState.MainMenu);
            }
            return EState.Death;
        }
    }
}