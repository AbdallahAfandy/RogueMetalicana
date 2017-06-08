﻿namespace RogueMetalicana
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RogueMetalicana.ConsoleCare;
    using RogueMetalicana.PlayerUnit;
    using RogueMetalicana.EnemyUnit;
    using RogueMetalicana.LevelEngine;
    using RogueMetalicana.GameEngine;
    using RogueMetalicana.Visualization;

    public class StartUp
    {
        public static void Main()
        {
            //Setting the console size for the game
            ConsoleManager.SetConsoleSize();

            //Creating instances for the player, enemies and the dungeon
            Player player = new Player();
            List<Enemy> allEnemies = new List<Enemy>();
            List<string> dungeon = new List<string>();

            //Processes and generates the level from the Level.txt file
            //Sets the player position fills the list with enemies and creates the dungeon from the file.
            LevelGenerator levelGenerator = new LevelGenerator();
            levelGenerator.GenerateLevel(player, allEnemies, dungeon);

            //Knows about all objects/units and takes the care about the interaction of the units.
            Engine gameEngine = new Engine(player, allEnemies, dungeon);
            //The movement of the player is an event
            //The engine is subscribed to this event so it can know about every move of the player.
            player.PlayerMoved += gameEngine.OnPlayerMoved;
            
            while (true)
            {
                player.MakeAMove();
               // Visualisator.PrintDungeon(dungeon);
            }
        }
    }
}
