using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GridUI.Grid
{
    public class GridTable
    {
        public List<Row> Rows { get; set; }
        public Item Player { get; set; } = new Item() { Direction = Direction.North, Position = new Position() { X = 0, Y = 0 } };

        private static List<Position> FilledPositions = new List<Position>();
        public static List<KeyValuePair<Direction, Position>> MoveByDirection { get; set; } =
            new List<KeyValuePair<Direction, Position>>()
            {
                new KeyValuePair<Direction, Position>(Direction.North, new Position() {X = 0, Y = -1}),
                new KeyValuePair<Direction, Position>(Direction.NorthEast, new Position() {X = 1, Y = -1}),
                new KeyValuePair<Direction, Position>(Direction.East, new Position() {X = 1, Y = 0}),
                new KeyValuePair<Direction, Position>(Direction.SouthEast, new Position() {X = 1, Y = 1}),
                new KeyValuePair<Direction, Position>(Direction.South, new Position() {X = 0, Y = 1}),
                new KeyValuePair<Direction, Position>(Direction.SouthWest, new Position() {X = -1, Y = 1}),
                new KeyValuePair<Direction, Position>(Direction.West, new Position() {X = -1, Y = 0}),
                new KeyValuePair<Direction, Position>(Direction.NorthWest, new Position() {X = -1, Y = -1})
            };
        public void CreateGrid(int columnSize, int rowSize, Item player)
        {
            player.Position = CheckPlayerPosition(player.Position);

            if (columnSize <= 0)
            {
                columnSize = 1;
            }

            if (rowSize <= 0)
            {
                rowSize = 1;
            }

            var gridRows = new List<Row>();
            var gridColumns = new List<Column>();

            for (var i = 0; i < rowSize; i++)
            {
                for (var j = 0; j < columnSize; j++)
                {
                    var tempPosition = new Position() { X = j, Y = i };
                    var tempColumn = new Column() { Position = tempPosition, IsFilled = true };
                    gridColumns.Add(tempColumn);
                    FilledPositions.Add(tempColumn.Position);
                }
                gridRows.Add(new Row() { Columns = gridColumns.ToList() });
                gridColumns.Clear();
            }

            Rows = gridRows;
            Player.Position.X = player.Position.X;
            Player.Position.Y = player.Position.Y;
            Player = player;
        }
        public void CreateGridWithShape(List<Row> shapeRows, Item player)
        {
            FilledPositions = new List<Position>();
            for (int i = 0; i < shapeRows.Count; i++)
            {
                for (int j = 0; j < shapeRows[i].Columns.Count; j++)
                {
                    shapeRows[i].Columns[j].Position = new Position() { X = j, Y = i };
                    if (shapeRows[i].Columns[j].IsFilled)
                    {
                        FilledPositions.Add(shapeRows[i].Columns[j].Position);
                    }
                }
            }

            Player = player;
            Player.Position = CheckPlayerPosition(player.Position);
            Rows = shapeRows;
        }
        public void CreateGridWithTriangle()
        {
            var row1 = new List<Column>
                {
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false}
                };

            var row2 = new List<Column>
                 {
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = false}
                 };

            var row3 = new List<Column>
                {
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false}
                };

            var row4 = new List<Column>
                {
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = false}
                };

            var row5 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true}
            };

            var triangleRows = new List<Row>
                {
                    new Row() { Columns = row1 },
                    new Row() { Columns = row2 },
                    new Row() { Columns = row3 },
                    new Row() { Columns = row4 },
                    new Row() {Columns = row5}
                };

            CreateGridWithShape(triangleRows, new Item()
            {
                Direction = Direction.North,
                Position = new Position() { X = 4, Y = 0 }
            });
        }
        public void CreateGridWithCircle()
        {
            var row1 = new List<Column>
                {
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                };

            var row2 = new List<Column>
                 {
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = false},
                 };

            var row3 = new List<Column>
                {
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                };

            var row4 = new List<Column>
                {
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = false},
                };

            var row5 = new List<Column>
            {
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
            };
            var row6 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
            };
            var row7 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
            };
            var row8 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
            };
            var row9 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
            };
            var row10 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
            };
            var row11 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
            };
            var row12 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
            };
            var row13 = new List<Column>
            {
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
            };
            var row14 = new List<Column>
            {
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
            };
            var row15 = new List<Column>
            {
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
            };
            var row16 = new List<Column>
            {
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
            };
            var row17 = new List<Column>
            {
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
            };

            var triangleRows = new List<Row>
                {
                    new Row() { Columns = row1 },
                    new Row() { Columns = row2 },
                    new Row() { Columns = row3 },
                    new Row() { Columns = row4 },
                    new Row() { Columns = row5 },
                    new Row() { Columns = row6 },
                    new Row() { Columns = row7 },
                    new Row() { Columns = row8 },
                    new Row() { Columns = row9 },
                    new Row() { Columns = row10 },
                    new Row() { Columns = row11 },
                    new Row() { Columns = row12 },
                    new Row() { Columns = row12 },
                    new Row() { Columns = row14 },
                    new Row() { Columns = row15 },
                    new Row() { Columns = row16 },
                    new Row() { Columns = row17 }
                };

            CreateGridWithShape(triangleRows, new Item()
            {
                Direction = Direction.North,
                Position = new Position() { X = 5, Y = 5 }
            });
        }
        public void CreateGridWithFlag()
        {
            var row1 = new List<Column>
                {
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true}
                };

            var row2 = new List<Column>
                 {
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = false},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true},
                     new Column() {IsFilled = true}
                 };

            var row3 = new List<Column>
                {
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true}
                };

            var row4 = new List<Column>
                {
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = false},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true},
                    new Column() {IsFilled = true}
                };

            var row5 = new List<Column>
            {
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false}
            };

            var row6 = new List<Column>
            {
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false}
            };
            var row7 = new List<Column>
            {
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false}
            };
            var row8 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true}
            };
            var row9 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true}
            };
            var row10 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true}
            };
            var row11 = new List<Column>
            {
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = false},
                new Column() {IsFilled = false},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true},
                new Column() {IsFilled = true}
            };

            var triangleRows = new List<Row>
                {
                    new Row() { Columns = row1 },
                    new Row() { Columns = row2 },
                    new Row() { Columns = row3 },
                    new Row() { Columns = row4 },
                    new Row() { Columns = row5 },
                    new Row() { Columns = row6 },
                    new Row() { Columns = row7 },
                    new Row() { Columns = row8 },
                    new Row() { Columns = row9 },
                    new Row() { Columns = row10 },
                    new Row() { Columns = row11 }
                };

            CreateGridWithShape(triangleRows, new Item()
            {
                Direction = Direction.North,
                Position = new Position() { X = 0, Y = 0 }
            });
        }
        public void MovePlayer(MovementType type, int steps)
        {
            var nextPosition = MoveByDirection.FirstOrDefault(x => x.Key == Player.Direction);
            var movementFactor = 1;
            if (type == MovementType.Backward)
            {
                movementFactor = -1;
            }

            Player.Position.X += nextPosition.Value.X * steps * movementFactor;
            Player.Position.Y += nextPosition.Value.Y * steps * movementFactor;
        }
        public void RotatePlayer(RotationType rotation)
        {
            var rotationStep = rotation == RotationType.CounterClockWise ? -1 : 1;
            var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
            var currentDirectionIndex = Array.IndexOf(Enum.GetValues(Player.Direction.GetType()), Player.Direction);
            var nextPossibleDirectionIndex = currentDirectionIndex + rotationStep;

            if (nextPossibleDirectionIndex >= directions.Count)
            {
                Player.Direction = directions[0];
            }
            else if (nextPossibleDirectionIndex < 0)
            {
                Player.Direction = directions[directions.Count - 1];
            }
            else
            {
                Player.Direction = directions[nextPossibleDirectionIndex];
            }
        }
        private static Position CheckPlayerPosition(Position playerPosition)
        {
            if (playerPosition.X < 0)
            {
                playerPosition.X = 0;
            }

            if (playerPosition.Y < 0)
            {
                playerPosition.Y = 0;
            }

            return playerPosition;
        }
        public bool IsPlayerFellOff()
        {
            return !FilledPositions.Any(x => x.X == Player.Position.X && x.Y == Player.Position.Y);
        }
        public void SimulatePlayer(string commands)
        {
            var commandList = commands.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < commandList.Count; i++)
            {
                if (IsPlayerFellOff())
                {
                    break;
                }
                if (commandList[i] == "0")
                {
                    break;
                }
                if (commandList[i] == "1")
                {
                    MovePlayer(MovementType.Forward, 1);
                }
                if (commandList[i] == "2")
                {
                    MovePlayer(MovementType.Backward, 1);
                }
                if (commandList[i] == "3")
                {
                    RotatePlayer(RotationType.Clockwise);
                    RotatePlayer(RotationType.Clockwise);
                }
                if (commandList[i] == "4")
                {
                    RotatePlayer(RotationType.CounterClockWise);
                    RotatePlayer(RotationType.CounterClockWise);
                }
                if (commandList[i] == "5")
                {
                    RotatePlayer(RotationType.Clockwise);
                }
                if (commandList[i] == "6")
                {
                    RotatePlayer(RotationType.CounterClockWise);
                }
            }
        }
    }
    public class Row
    {
        public List<Column> Columns { get; set; }
    }
    public class Column
    {
        public bool IsFilled { get; set; } = true;
        public Position Position { get; set; } = new Position();
    }
    public class Item
    {
        public Position Position { get; set; } = new Position();
        public Direction Direction { get; set; }
    }
    public class Position
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
    }
    public enum Direction
    {
        North = 0,
        NorthEast = 1,
        East = 2,
        SouthEast = 3,
        South = 4,
        SouthWest = 5,
        West = 6,
        NorthWest = 7
    }
    public enum MovementType
    {
        Forward = 0,
        Backward = 1
    }
    public enum RotationType
    {
        Clockwise = 0,
        CounterClockWise = 1
    }
}