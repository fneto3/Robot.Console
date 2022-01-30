namespace Codec.Library
{
    public class Robot
    {
        private Position _position;

        public Position Move(string plateau, string movements)
        {
            var maxPlateauX = int.Parse(plateau.Split('x').GetValue(0).ToString());
            var maxPlateauY = int.Parse(plateau.Split('x').GetValue(1).ToString());

            _position = new Position(maxPlateauX, maxPlateauY);

            foreach (var item in movements.ToLower())
            {
                _position.Move(item);
            }

            return _position;
        }
    }
}