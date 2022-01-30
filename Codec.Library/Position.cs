using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codec.Library
{
    public class Position
    {
        public readonly Dictionary<FacingDirection, FacingDirection> MoveLeft;

        public readonly Dictionary<FacingDirection, FacingDirection> MoveRight;

        private readonly int _maxPlateauX;
        private readonly int _maxPlateauY;

        public Position(int maxPlateauX, int maxPlateauY)
        {
            _maxPlateauX = maxPlateauX;
            _maxPlateauY = maxPlateauY;

            MoveLeft = new Dictionary<FacingDirection, FacingDirection>();

            MoveLeft.Add(FacingDirection.North, FacingDirection.West);
            MoveLeft.Add(FacingDirection.West, FacingDirection.South);
            MoveLeft.Add(FacingDirection.South, FacingDirection.East);
            MoveLeft.Add(FacingDirection.East, FacingDirection.North);

            MoveRight = new Dictionary<FacingDirection, FacingDirection>();

            MoveRight.Add(FacingDirection.North, FacingDirection.East);
            MoveRight.Add(FacingDirection.East, FacingDirection.South);
            MoveRight.Add(FacingDirection.South, FacingDirection.West);
            MoveRight.Add(FacingDirection.West, FacingDirection.North);
        }

        public int x { get; private set; } = 1;
        public int y { get; private set; } = 1;

        public FacingDirection Facing { get; set; } = FacingDirection.North;

        public void Move(char position)
        {
            if(position == 'l')
            {
                Facing = MoveLeft[Facing];
            }
            else if(position == 'r')
            {
                Facing = MoveRight[Facing];
            }
            else if(position == 'f')
            {
                if(Facing == FacingDirection.North)
                {
                    if((y + 1) <= _maxPlateauY)
                        y++;
                }
                else if (Facing == FacingDirection.West)
                {
                    if ((x - 1) >= 1)
                        x--;
                }
                else if(Facing == FacingDirection.South)
                {
                    if ((y - 1) >= 1)
                        y--;
                }
                else if(Facing == FacingDirection.East)
                {
                    if ((x + 1) <= _maxPlateauX)
                        x++;
                }
            }
        }
    }

    public enum FacingDirection
    {
        North = 0,
        West = 1,
        South = 2,
        East = 3
    }
}
