using Codec.Library;

Console.WriteLine("Enter plateau size ValuexValue:");

var plateauSize = Console.ReadLine();

Console.WriteLine("Enter movements:");

var movements = Console.ReadLine();

var robot = new Robot();

var finalPosition = robot.Move(plateauSize, movements);

Console.WriteLine(String.Format("{0},{1},{2}", finalPosition.x, finalPosition.y, finalPosition.Facing.ToString()));

Console.Read();
