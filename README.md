# GridSimulation with player

Download

```sh
git clone https://github.com/hsnkorkmaz/GridSimulation.git
```
# Executable Files
- Running project without Visual Studio is possible.

Download Link: 
https://drive.google.com/file/d/1nfKw6iOwGX8XA8ZDd6Lax4q9ZaXkPqdE/view?usp=sharing

1. Download the zip file
2. Go into Release/net5.0/
3. Run GridUI.exe

When you run the project you will have below options
```sh
- 0: Quit
- 1: Create grid with your parameters
- 2: Create grid with Triangle
- 3: Create grid with Circle
- 4: Create grid with Sweden's flag
```
If you choose 1 you will be asked to enter your grid size and players position.
```sh
Expected input is ColumnSize,RowSize,PositionX,PositionY  (Sample: 10,10,2,2)

Your grid will look like:
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][@][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
```
If you choose other options like 4, grid will be ready to simulate as below
```sh
[@][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]



[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
Current Direction: North
Current Position: 0, 0
```
In the simulations your options will be as follows:
```sh
0: Quit simulation
1: Move Forward
2: Move Backward
3: Rotate Clockwise 90 degrees
4: Rotate Counterclockwise 90 degrees
5: Rotate Clockwise 45 degrees
6: Rotate Counterclockwise 45 degrees
It is possible to send more commands in one line ex: 1,4,2,1
```

If you fell off from the grid with your moves you will end up in the main menu and your players final coordinates will be -1,-1

- Current designs are shown below. It is possible to create more designs with creating rows and columns within code or with a json file with deserialisation.
```sh
Triangle
            [@]
         [ ][ ][ ]
      [ ][ ][ ][ ][ ]
   [ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ]

Circle
               [ ][ ][ ][ ][ ]
         [ ][ ][ ][ ][ ][ ][ ][ ][ ]
      [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
   [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
   [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][@][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
   [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
      [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
         [ ][ ][ ][ ][ ][ ][ ][ ][ ]
               [ ][ ][ ][ ][ ]

Sweden's flag
[@][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]



[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ]      [ ][ ][ ][ ][ ][ ][ ][ ][ ]
```
