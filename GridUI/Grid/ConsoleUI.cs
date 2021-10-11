using System;
using System.Collections.Generic;
using System.Linq;

namespace GridUI.Grid
{
    public static class ConsoleUI
    {
        private static GridTable gridTable = new GridTable();
        private static List<string> mainMenuCommands = new List<string>()
        {
            "0: Quit",
            "1: Create grid with your parameters",
            "2: Create grid with Triangle",
            "3: Create grid with Circle",
            "4: Create grid with Sweden's flag",
        };
        private static List<string> playerCommands = new List<string>()
        {
            "0: Quit simulation",
            "1: Move Forward",
            "2: Move Backward",
            "3: Rotate Clockwise 90 degrees",
            "4: Rotate Counterclockwise 90 degrees",
            "5: Rotate Clockwise 45 degrees",
            "6: Rotate Counterclockwise 45 degrees",
            "It is possible to send more commands in one line ex: 1,4,2,1"
        };

        public static void Run()
        {
            MainMenu();
        }
        private static void MainMenu()
        {
            while (true)
            {
                PrintCommands(mainMenuCommands);
                Console.WriteLine();
                Console.Write("Command: ");
                var input = Console.ReadLine()?.Trim();
                if (input == "0")
                {
                    break;
                }
                if (input == "1")
                {
                    CreateWithParameters();
                }
                if (input == "2")
                {
                    gridTable.CreateGridWithTriangle();
                    SimulationMenu();
                }
                if (input == "3")
                {
                    gridTable.CreateGridWithCircle();
                    SimulationMenu();
                }
                if (input == "4")
                {
                    gridTable.CreateGridWithFlag();
                    SimulationMenu();
                }
            }
        }
        private static void CreateWithParameters()
        {
            Console.WriteLine("Sample Input: 4,4,2,2");
            Console.Write("Your Input: ");
            var input = Console.ReadLine()?.Trim();

            if (input == "")
            {
                Console.Clear();
                Console.WriteLine("Your input is not valid!");
                return;
            }
            
            var commandList = input.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            if (commandList.Count < 4 || commandList.Count > 4)
            {
                Console.Clear();
                Console.WriteLine("Your input is not valid!");
                return;
            }

            int.TryParse(commandList[0], out int columnSize);
            int.TryParse(commandList[1], out int rowSize);
            int.TryParse(commandList[2], out int positionX);
            int.TryParse(commandList[3], out int positionY);

            if (columnSize > 50 || rowSize > 50)
            {
                Console.Clear();
                Console.WriteLine("Column size or Row size is too much!");
                return;
            }


            if (positionX > columnSize || positionX < 0)
            {
                Console.Clear();
                Console.WriteLine("Your input is not valid!");
                return;
            }
            if (positionY > rowSize || positionY < 0)
            {
                Console.Clear();
                Console.WriteLine("Your input is not valid!");
                return;
            }

            gridTable.CreateGrid(columnSize, rowSize, new Item()
            {
                Direction = Direction.North,
                Position = new Position()
                {
                    X = positionX,
                    Y = positionY
                }
            });
            
            SimulationMenu();
        }
        private static void SimulationMenu()
        {
            while (true)
            {
                Console.Clear();
                PrintCommands(playerCommands);
                Console.WriteLine();
                Console.WriteLine(DrawGrid());
                Console.WriteLine($"Current Direction: {gridTable.Player.Direction}");
                Console.WriteLine($"Current Position: {gridTable.Player.Position.X}, {gridTable.Player.Position.Y}");

                Console.Write("Command: ");
                var input = Console.ReadLine()?.Trim();

                if (input.Contains(','))
                {
                    gridTable.SimulatePlayer(input);
                }
                if (input == "0")
                {
                    Console.Clear();
                    Console.WriteLine("Simulation finished");
                    Console.WriteLine($"Position: {gridTable.Player.Position.X}, {gridTable.Player.Position.Y}");
                    Console.WriteLine();
                    break;
                }
                if (input == "1")
                {
                    gridTable.MovePlayer(MovementType.Forward, 1);
                }
                if (input == "2")
                {
                    gridTable.MovePlayer(MovementType.Backward, 1);
                }
                if (input == "3")
                {
                    gridTable.RotatePlayer(RotationType.Clockwise);
                    gridTable.RotatePlayer(RotationType.Clockwise);
                }
                if (input == "4")
                {
                    gridTable.RotatePlayer(RotationType.CounterClockWise);
                    gridTable.RotatePlayer(RotationType.CounterClockWise);
                }
                if (input == "5")
                {
                    gridTable.RotatePlayer(RotationType.Clockwise);
                }
                if (input == "6")
                {
                    gridTable.RotatePlayer(RotationType.CounterClockWise);
                }
                if (gridTable.IsPlayerFellOff())
                {
                    Console.Clear();
                    Console.WriteLine("You fell off the table");
                    Console.WriteLine($"Position: -1, -1");
                    Console.WriteLine();
                    break;
                }
            }
        }
        private static void PrintCommands(List<string> commands)
        {
            for (int i = 0; i < commands.Count; i++)
            {
                Console.WriteLine(commands[i]);
            }
        }
        public static string DrawGrid()
        {
            var gridData = "";
            if (gridTable.Rows == null)
            {
                return gridData;
            }
            for (int i = 0; i < gridTable.Rows.Count; i++)
            {
                for (int j = 0; j < gridTable.Rows[i].Columns.Count; j++)
                {
                    gridData += DrawColumn(gridTable.Rows[i].Columns[j], gridTable.Player.Position);
                }
                gridData += "\n";
            }
            return gridData;
        }
        private static string DrawColumn(Column column, Position playerPosition)
        {
            if (!column.IsFilled) return "   ";

            if (column.Position.X == playerPosition.X && column.Position.Y == playerPosition.Y)
            {
                return "[@]"; 
            }
            else
            {
                return "[ ]";
            }
        }
        
    }
}
