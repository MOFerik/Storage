
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

            private int point = 0;

            public void add(Planet pl)
            {
                planets[++plCount] = pl;
                id[count] = plCount;
                count++;

                System.Console.WriteLine($"\nPlanet {pl.name} was added to the planetary system.");
            }

            public void add(Station st)
            {
                stations[++stCount] = st;
                id[count] = stCount + 100;
                count++;

                System.Console.WriteLine($"\nStation {st.name} was added to the planetary system.");
            }

            public void del()
            {
                if (id[point] > 100)
                {
                    System.Console.WriteLine($"\nStation {stations[id[point] - 100].name} was removed from the planetary system.");
                    stations[--stCount] = null;
                    id[point] = 0;
                    count--;
                }
                else if (id[point] > 0)
                {
                    System.Console.WriteLine($"\nPlanet {planets[id[point]].name} was removed from the planetary system.");
                    planets[--plCount] = null;
                    id[point] = 0;
                    count--;
                }
                else
                    System.Console.WriteLine($"\nNothing to remove!");
            }

            public void current()
            {
                if (id[point] > 0)
                {
                    System.Console.Write($"\nYou are currently targeting object number {point + 1}:");
                    if (id[point] > 100)
                        System.Console.WriteLine($" station {stations[id[point] - 100].name}.");
                    else
                        System.Console.WriteLine($" planet {planets[id[point]].name}.");
                }
                else
                    System.Console.WriteLine($"\nYou are currently not targeting any objects.");
            }

            public void next()
            {
                point++;
                if (id[point] > 0)
                {
                    System.Console.Write($"\nYou are now targeting object number {point + 1}:");
                    if (id[point] > 100)
                        System.Console.WriteLine($" station {stations[id[point] - 100].name}.");
                    else
                        System.Console.WriteLine($" planet {planets[id[point]].name}.");
                }
                else
                    System.Console.WriteLine($"\nYou are now not targeting any objects.");
            }

            public void prev()
            {
                if (point > 0)
                {
                    point++;
                    if (id[point] > 0)
                    {
                        System.Console.Write($"\nYou are now targeting object number {point + 1}:");
                        if (id[point] > 100)
                            System.Console.WriteLine($" station {stations[id[point] - 100].name}.");
                        else
                            System.Console.WriteLine($" planet {planets[id[point]].name}.");
                    }
                    else
                        System.Console.WriteLine($"\nYou are now not targeting any objects.");
                }
                else
                    System.Console.WriteLine($"\nYou can not select a non-existing object.");
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
            PlanetarySystem plsys = new PlanetarySystem();
            Planet earth = new Planet("Earth", 'e', true);
            Planet mars = new Planet("Mars", 'e', false);
            Station iss = new Station("ISS-2", true, 3);
            Station uran = new Station("Uranus-1", false, 0);

            plsys.add(iss);
            plsys.add(earth);
            plsys.add(uran);
            plsys.add(mars);

            plsys.current();

            plsys.del();
            plsys.del();
        }
    }
}
