
namespace Хранилище__лр_3_
{
    class Program
    {
        public class PlanetarySystem
        {
            private const int n = 100;
            private Planet[] planets = new Planet[n];
            private Station[] stations = new Station[n];
            private int[] id = new int[2 * n];

            private int count = 0;
            private int plCount = 0;
            private int stCount = 0;

            public void add(Planet pl)
            {
                planets[plCount] = pl;
                id[count] = ++plCount;
                count++;

                System.Console.WriteLine($"\nPlanet {pl.name} was added to the planetary system.");
            }

            public void add(Station st)
            {
                stations[stCount] = st;
                id[count] = ++stCount + 100;
                count++;

                System.Console.WriteLine($"\nStation {st.name} was added to the planetary system.");
            }

            public void del()
            {
                if (id[count] > 100)
                {
                    System.Console.WriteLine($"\nStation {stations[stCount - 1].name} was removed from the planetary system.");
                    stations[--stCount] = null;
                    id[count--] = 0;
                }
                else
                {
                    System.Console.WriteLine($"\nPlanet {planets[plCount - 1].name} was removed from the planetary system.");
                    planets[--plCount] = null;
                    id[count--] = 0;
                }
            }
        }

        public class Planet
        {
            public string name;
            protected char type;
            protected bool colonized;

            public void scan()
            {
                System.Console.WriteLine($"\nYou scan planet {this.name}.");
                switch (type)
                {
                    case 'd':
                        System.Console.WriteLine($" It's a dwarf planet.");
                        break;
                    case 'e':
                        System.Console.WriteLine($" It's an Earth-like planet.");
                        break;
                    case 'g':
                        System.Console.WriteLine($" It's a gaseous planet.");
                        break;
                    default:
                        System.Console.WriteLine($" It's planetary type is unknown.");
                        break;
                }
                if (this.colonized)
                    System.Console.WriteLine($" It is a colonized world.");
                else
                    System.Console.WriteLine($" It is not a colonized world.");
            }

            public bool land(bool landed)
            {
                if (landed && (this.type == 'g'))
                    System.Console.WriteLine($"\nYou can not land on the planet {this.name} at the moment.");
                else
                {
                    System.Console.WriteLine($"\n You landed on the planet {this.name} succesfully!");
                    return true;
                }

                return false;
            }

            public bool takeoff(bool landed)
            {
                if (landed)
                {
                    System.Console.WriteLine($"\n You have taken off succesfully!");
                    return false;
                }

                return true;
            }

            public Planet(string n, char t, bool c)
            {
                this.name = n;
                this.type = t;
                this.colonized = c;
            }
        }

        public class Station
        {
            public string name;
            protected bool dockable;
            protected int capacity;

            public void comm()
            {
                if (this.dockable)
                    System.Console.WriteLine($"\nCommunication with station {this.name} secured. It is a dockable station, it has {this.capacity} spare docks available.");
                else
                    System.Console.WriteLine($"\nCommunication with station {this.name} secured. It is not a dockable station.");
            }

            public bool dock(bool landed)
            {
                if (landed && this.dockable && (this.capacity > 0))
                    System.Console.WriteLine($"\n You can not dock to the station {this.name} at the moment.");
                else
                {
                    System.Console.WriteLine($"\n You docked to the station {this.name} succesfully!");
                    return true;
                }

                return false;
            }

            public bool takeoff(bool landed)
            {
                if (landed)
                {
                    System.Console.WriteLine($"\n You have taken off succesfully!");
                    return false;
                }

                return true;
            }

            public Station(string n, bool d, int c)
            {
                this.name = n;
                this.dockable = d;
                this.capacity = c;
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
