﻿using System;
using System.Collections.Generic;
using Tkach.Lab7_8.Game.DataStructures;
using static System.Console;

namespace Tkach.Lab7_8.Game.GameWorldRepresentators
{
    class ConsoleRepresentator : IGameWorldRepresentator
    {
        private Dictionary<char, ConsoleColor> symbolColor;
        private bool monochromeMode;

        public ConsoleRepresentator()
        {
            symbolColor = new Dictionary<char, ConsoleColor>();
            symbolColor.Add('P', ConsoleColor.Red);
            symbolColor.Add('o', ConsoleColor.Yellow);
            symbolColor.Add('█', ConsoleColor.Gray);
            symbolColor.Add('D', ConsoleColor.DarkGreen);

            monochromeMode = false;
        }
        public void Represent(Matrix<char> gameWorldCanvas)
        {
            if(monochromeMode == true)
            {
                ForegroundColor = ConsoleColor.White;
            }

            for (int y = 0; y < gameWorldCanvas.dimentions.Y; y++)
            {
                for (int x = 0; x < gameWorldCanvas.dimentions.X; x++)
                {
                    char element = gameWorldCanvas.matrix[y, x];
                    if (monochromeMode == false)
                    {
                        ConsoleColor color;
                        if (symbolColor.TryGetValue(element, out color))
                        {
                            ForegroundColor = symbolColor[element];
                        }
                    }
                    
                    SetCursorPosition(x, y);
                    Write(element);
                    ResetColor();
                }
            }
            Write("\n");
        }

        public void setMonochromeMode(bool mode)
        {
            monochromeMode = mode;
        }
    }
}
