using System.Drawing;
using System.Text;

namespace TextRPG
{
    internal class Program
    {
        static void gogildong(int x)
        {

            string[] gildong = new string[19];
            gildong[0] = "██████▒▒██████████████████████\r\n";
            gildong[1] = "█████░░░▒█████████████████████\r\n";
            gildong[2] = "███░░▒▒▒░█████████████████████\r\n";
            gildong[3] = "██░░▒░░▒██████████████████████\r\n";
            gildong[4] = "█▓░▒░░▒░█████▓░░░█████████████\r\n";
            gildong[5] = "█░▒░░░▒░███░░░▒▒░░░░░░░░▒█████\r\n";
            gildong[6] = "░▒▒░░░▒░██░░▒░░░░░▒░░▒▒▒░▓████\r\n";
            gildong[7] = "░▒░░░░▒░░░▒▒░░───░░░░░░░▒░░███\r\n";
            gildong[8] = "░▒░░░░░░▒▒▒░───░░░─░░──░░▒░░▒░\r\n";
            gildong[9] = "░▒░░░▒░▒░░▒░──░░░░░░░░──░▒░▒▒▒\r\n";
            gildong[10] = "░▒▒▒▒▒░▒░░░░░░░░░░▒░░░░─░░░░░▒\r\n";
            gildong[11] = "█░░░▓▒░▒▒░░░░▒░░░░░░░░▒░─░░░░░\r\n";
            gildong[12] = "██░░▒▒░▒░──░░░░░░──░░─░░░─░▒▒▒\r\n";
            gildong[13] = "██░▒▒▓▓░───░░░▒▒░─░▒▒░░░░──░▓░\r\n";
            gildong[14] = "██░▒▒▒▒░───░░░░▒░░░▒▒░░▒░──░░░\r\n";
            gildong[15] = "██░▒▒░▒░──░░░──░░▒░░░─░░░───░░\r\n";
            gildong[16] = "██░░▒░▒░──░▒░──░░░▒░──░▒░───░▒\r\n";
            gildong[17] = "███░▒▒▒▒░─░░░░──░▒▒░─░░░░──░░░\r\n";
            gildong[18] = "████▓░░▒░░──░▒░░░░░░░░░────░▒░\r\n";

            Console.WriteLine(gildong[x]);
        }

        enum Scene { Select, Confirm, Town, Forest, Swarm, Maze }
        enum Job { Warrior = 1, Mage, Rogue }
        enum iType
        {
            없음, 방어구, 무기, 소모품
        }

        struct monInven
        {
            public string name;
            public iType type;
        }

        struct Invenitem
        {
            public string Weapon;
            public string Armor;
            public string Expendables;

        }
        static void startItem(int x)
        {
            switch (x)
            {
                case 1:
                    item.Weapon = "대검";
                    item.Armor = "야만전사의 가죽 옷";
                    item.Expendables = "하급 회복 물약";
                    break;
                case 2:
                    item.Weapon = "지팡이";
                    item.Armor = "야만전사의 가죽 옷";
                    item.Expendables = "하급 마력 회복 물약";
                    break;
                case 3:
                    item.Weapon = "단검";
                    item.Armor = "가벼운 천 옷";
                    item.Expendables = "하급 회복 물약";
                    break;
                default:
                    break;
            }
        }

        struct GameData
        {
            public bool running1;
            public bool running2;

            public Scene scene;

            public string name;
            public Job job;
            public int curHP;
            public int maxHP;
            public int STR;
            public int INT;
            public int DEX;
            public int EVA;
            public int gold;

            //미로
            public bool[,] map;
            public ConsoleKey inputKey;
            public Point playerPos;
            public Point BoxPos1;
            public Point BoxPos2;
            public Point BoxPos3;
            public Point BoxPos4;
        }

        struct Item
        {
            public string Name;
            public iType type;
        }

        public struct Point
        {
            public int x;
            public int y;
        }

        static monInven[] mItems = new monInven[4];
        static Item[] items = new Item[6];

        static Invenitem item;

        static GameData data;


        static void mobItem()
        {
            mItems[0].name = "오래된 붓";
            mItems[0].type = iType.무기;
            mItems[1].name = "양털 옷";
            mItems[1].type = iType.방어구;
            mItems[2].name = "아이작의 눈물";
            mItems[2].type = iType.소모품;
            mItems[3].name = "무너 숙회";
            mItems[3].type = iType.소모품;
        }


        public static int Rand()
        {
            Random rand = new Random();

            return rand.Next(1, 100);
        }
        static int proba = Rand();
        static void Main(string[] args)
        {
            Start();

            while (data.running1)
            {
                Run();
            }

            End();
        }

        static void Start()
        {
            data = new GameData();

            data.running1 = true;
            data.running2 = true;
            data.map = new bool[,]
            {
                { false, false, false, false, false, false, false },
                { false,  true, true,  true,  true,  true, false },
                { false,  true, true,  true,  true,  true, false },
                { false,  true, true,  true,  true,  true, false },
                { false,  true, true,  true,  true,  true, false },
                { false,  true, true,  true,  true,  true, false },
                { false, false, false, false, false, false, false },
            };

            data.playerPos = new Point() { x = 1, y = 1 };
            data.BoxPos1 = new Point() { x = 5, y = 1 };
            data.BoxPos2 = new Point() { x = 5, y = 3 };
            data.BoxPos3 = new Point() { x = 5, y = 5 };
            data.BoxPos4 = new Point() { x = 1, y = 5 };


            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=           레전드 RPG             =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("    계속하려면 아무키나 누르세요    ");
            Console.ReadKey();
        }

        static void End()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=            게임 오버!            =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        static void Run()
        {
            Console.Clear();

            switch (data.scene)
            {
                case Scene.Select:
                    SelectScene();
                    break;
                case Scene.Confirm:
                    ConfirmScene();
                    break;
                case Scene.Town:
                    TownScene();
                    break;
                case Scene.Forest:
                    ForestScene();
                    break;
                case Scene.Swarm:
                    SwarmScene();
                    break;
                case Scene.Maze:
                    Maze();
                    break;
            }
        }

        static void PrintProfile()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"이름 : {data.name,-6} 직업 : {data.job,-6}");
            Console.WriteLine($"무기 : {item.Weapon}");
            Console.WriteLine($"방어구 : {item.Armor}");
            Console.WriteLine($"소모품 : {item.Expendables}");
            Console.WriteLine($"체력 : {data.curHP,+3} / {data.maxHP}");
            Console.WriteLine($"힘 : {data.STR,-3} 지력 : {data.INT,-3} 민첩 : {data.DEX,-3}");
            Console.WriteLine($"소지금 : {data.gold,+5} G");
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        static void Wait(float seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }

        static void SelectScene()
        {
            Console.Write("캐릭터의 이름을 입력하세요 : ");
            data.name = Console.ReadLine();
            if (data.name == "")
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 도적");
            if (int.TryParse(Console.ReadLine(), out int select) == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }
            else if (Enum.IsDefined(typeof(Job), select) == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            switch ((Job)select)
            {
                case Job.Warrior:
                    data.job = Job.Warrior;
                    data.maxHP = 200;
                    data.curHP = data.maxHP;
                    data.STR = 16;
                    data.INT = 8;
                    data.DEX = 12;
                    data.EVA = 10;
                    data.gold = 100;
                    startItem(select);
                    break;
                case Job.Mage:
                    data.job = Job.Mage;
                    data.maxHP = 80;
                    data.curHP = data.maxHP;
                    data.STR = 6;
                    data.INT = 20;
                    data.DEX = 8;
                    data.EVA = 5;
                    data.gold = 300;
                    startItem(select);
                    break;
                case Job.Rogue:
                    data.job = Job.Rogue;
                    data.maxHP = 120;
                    data.curHP = data.maxHP;
                    data.STR = 10;
                    data.INT = 10;
                    data.DEX = 16;
                    data.EVA = 30;
                    data.gold = 0;
                    startItem(select);
                    break;
            }
            data.scene = Scene.Confirm;
        }

        static void ConfirmScene()
        {
            // Render
            Console.WriteLine("===================");
            Console.WriteLine($"이름 : {data.name}");
            Console.WriteLine($"직업 : {data.job}");
            Console.WriteLine($"무기 : {item.Weapon}");
            Console.WriteLine($"방어구 : {item.Armor}");
            Console.WriteLine($"소모품 : {item.Expendables}");
            Console.WriteLine($"체력 : {data.maxHP}");
            Console.WriteLine($"힘   : {data.STR}");
            Console.WriteLine($"지력 : {data.INT}");
            Console.WriteLine($"민첩 : {data.DEX}");
            Console.WriteLine($"소지금 : {data.gold}");
            Console.WriteLine("===================");
            Console.WriteLine();
            Console.Write("이대로 플레이 하시겠습니까?(y/n)");

            // Input
            string input = Console.ReadLine();

            // Update
            switch (input)
            {
                case "Y":
                case "y":
                    Console.Clear();
                    Console.Write("  __                  ___       ___               __\r\n /\\ \\                /\\_ \\     /\\_ \\             /\\ \\\r\n \\ \\ \\___       __   \\//\\ \\    \\//\\ \\      ___   \\ \\ \\\r\n  \\ \\  _ `\\   /'__`\\   \\ \\ \\     \\ \\ \\    / __`\\  \\ \\ \\\r\n   \\ \\ \\ \\ \\ /\\  __/    \\_\\ \\_    \\_\\ \\_ /\\ \\L\\ \\  \\ \\_\\\r\n    \\ \\_\\ \\_\\\\ \\____\\   /\\____\\   /\\____\\\\ \\____/   \\/\\_\\\r\n     \\/_/\\/_/ \\/____/   \\/____/   \\/____/ \\/___/     \\/_/\r\n");
                    Console.WriteLine("게임을 시작하신것을 축하드립니다.");
                    Wait(1);
                    Console.Clear();

                    Console.WriteLine("마을로 이동합니다...");
                    Wait(2);

                    Console.WriteLine("고향에 몬스터가 들이닥쳐 모든 것을 잃고 용병이 되어 활동한지 3개월째 다음 목적지인 마을이 저 멀리 보이기 시작한다.");
                    Wait(2);
                    data.scene = Scene.Maze;
                    break;
                case "N":
                case "n":
                    data.scene = Scene.Select;
                    break;
                default:
                    data.scene = Scene.Confirm;
                    break;
            }
        }

        static void TownScene()
        {
            // Render

            string choose;
            int choice;
            // Update
            Console.Clear();
            PrintProfile();
            Console.WriteLine("여관으로 이동합니다...");
            Console.WriteLine("여관 주인 : 어서 오시게나! 식사라도 하실텐가?");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. 지금은 생각이 없습니다. 혹시 빈방은 있습니까?");
            Console.WriteLine("2. 마침 배가 출출 했었는데 간판 메뉴 하나주시오");
            Console.Write("선택 : ");
            int.TryParse(Console.ReadLine(), out choice);

            if (choice == 1)
            {
                Console.WriteLine("물론이지오! 숙박 요금은 50골드이네 지불하실텐가? (y/n)");
                Console.Write("선택 : ");
                choose = Console.ReadLine();
                if ((choose.Equals("y") || choose.Equals("y")) && data.gold >= 50)
                {
                    data.gold -= 50;
                    Console.WriteLine("잘 선택했네! 편안하게 쉬었다 가시게나.");
                    Console.WriteLine($"체력을 {data.maxHP - data.curHP} 회복하였습니다.");
                    data.curHP += data.maxHP - data.curHP;
                }
                else
                {
                    Console.WriteLine("우리 여관은 항상 열려있으니 언제든 찾아오시게나!");
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("우리 가게의 간판 메뉴의 가격은 20골드일세 먹으시겠나?");
                Console.Write("선택 : ");
                choose = Console.ReadLine();
                if ((choose.Equals("y") || choose.Equals("y")) && data.gold >= 50)
                {
                    data.gold -= 20;
                    Console.WriteLine("이게 우리 가게의 간판 메뉴! 육고기 비빔 소스 덮밥이라네! 맛있게 먹으시게나");
                    if ((data.curHP + 20) > data.maxHP)
                    {
                        data.curHP = data.maxHP;
                        Console.WriteLine($"체력이 전부 회복되였습니다.");
                    }
                    else
                    {
                        Console.WriteLine("체력이 20회복되었습니다.");
                        data.curHP += 20;
                    }
                }
                else
                {
                    Console.WriteLine("우리 여관은 항상 열려있으니 언제든 찾아오시게나!");
                }
            }
            Wait(2);
            data.running2 = true;
            data.scene = Scene.Maze;
        }

        static void ForestScene()
        {
            PrintProfile();
            Console.WriteLine("적막한 숲입니다.");
            Wait(1);
            Console.WriteLine("갑작스럽게 당신 앞에 슬라임이 나타났습니다.");
            Wait(1);
            Console.WriteLine();
            Console.WriteLine("당신의 행동을 선택해주세요");
            Console.WriteLine("1. 슬라임을 공격한다.(힘)");
            Console.WriteLine("2. 슬라임을 주시하며 공격마법을 시전한다.(지력)");
            Console.WriteLine("3. 슬라임이 눈치채지 못하게 뒤로 접근하여 공격한다.(민첩)");
            Console.Write("선택 : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (data.STR > 14)
                    {
                        Console.WriteLine("당신의 공격은 슬라임에게 치명적이었습니다!");
                        Wait(1);
                        Console.WriteLine("슬라임이 쓰러졌습니다!");
                        Wait(1);
                        Console.WriteLine("100 골드를 얻었습니다!");
                        Wait(1);
                        data.gold += 100;
                    }
                    else
                    {
                        Console.WriteLine("당신의 공격은 슬라임에게 무의미 했습니다!");
                        Wait(1);
                        Console.WriteLine("슬라임이 반격했습니다!");
                        Wait(1);
                        if (proba <= data.EVA)
                        {
                            Console.WriteLine("슬라임의 공격을 회피하였습니다!");
                        }
                        else
                        {
                            Console.WriteLine("30의 체력 피해를 받았습니다!");
                            data.curHP -= 30;
                        }
                        Wait(1);
                    }
                    break;

                case "2":
                    if (data.INT > 12)
                    {
                        Console.WriteLine("당신의 마법은 슬라임에게 치명적이었습니다!");
                        Wait(1);
                        Console.WriteLine("슬라임이 쓰러졌습니다!");
                        Wait(1);
                        Console.WriteLine("100 골드를 얻었습니다!");
                        Wait(1);
                        data.gold += 100;
                        Console.WriteLine("마법을 사용하여 체력 5 소모되었습니다.");
                        data.curHP -= 5;
                    }
                    else
                    {
                        Console.WriteLine("당신의 공격은 슬라임에게 무의미 했습니다!");
                        Wait(1);
                        Console.WriteLine("슬라임이 반격했습니다!");
                        Wait(1);
                        if (proba <= data.EVA)
                        {
                            Console.WriteLine("슬라임의 공격을 회피하였습니다!");
                        }
                        else
                        {
                            Console.WriteLine("30의 체력 피해를 받았습니다!");
                            data.curHP -= 30;
                        }
                        Wait(1);
                    }
                    break;

                case "3":
                    Console.WriteLine("당신은 슬라임의 뒤로 재빠르게 접근했습니다!");
                    Wait(1);
                    Console.WriteLine("하지만 슬라임은 앞뒤 구분이 되지 않았습니다.");
                    Wait(1);
                    Console.WriteLine("슬라임이 반격했습니다!");
                    Wait(1);
                    if (proba <= data.EVA)
                    {
                        Console.WriteLine("슬라임의 공격을 회피하였습니다!");
                    }
                    else
                    {
                        Console.WriteLine("30의 체력 피해를 받았습니다!");
                        data.curHP -= 30;
                    }
                    Wait(1);
                    break;
                default:
                    break;
            }

            Console.Clear();
            Console.WriteLine("마을로 돌아갑니다...");
            Wait(2);
            data.running2 = true;
            data.scene = Scene.Maze;
        }

        static void SwarmScene()
        {
            PrintProfile();
            Console.WriteLine("축축한 냄새가 나는 지역입니다.");
            if (data.DEX <= 12)
            {
                Wait(1);
                Console.WriteLine("늪이 당신을 잡아당기며 몸이 지치는 것이 느껴집니다.");
                Wait(1);
                Console.WriteLine("체력이 10 감소했습니다.");
                data.curHP -= 10;
            }


            Wait(2);
            Console.WriteLine("늪을 건너는 중 이상하게 생긴 식물을 발견했습니다.");

            if (data.INT >= 12)
            {
                Wait(1);
                Console.WriteLine("당신은 식물이 약초라는 것을 알았습니다.");
                Wait(1);
                Console.WriteLine("약초를 습득했습니다!");
            }
            else
            {
                Wait(1);
                Console.WriteLine("당신은 식물에 대한 지식이 없습니다.");
                Wait(1);
                Console.WriteLine("지나쳐 버렸습니다...");
            }

            Console.WriteLine(proba);
            if (proba <= 100)
            {
                for (int i = 0; i < 19; i++)
                {
                    gogildong(i);
                }
                Wait(1);
                Console.WriteLine("정체를 알 수 없는 몬스터가 나타났다");
                Wait(1);
                Console.WriteLine();
                Console.WriteLine("당신의 행동을 선택해주세요");
                Console.WriteLine("1. 공격한다.");
                Console.WriteLine("2. 엎드려 숭배한다.");
                Console.WriteLine("3. 도망친다");
                Console.Write("선택 : ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("당신의 공격에 정체를 알 수 없는 몬스터가 콧방귀를 뀝니다.");
                        Wait(1);
                        Console.WriteLine("무언가 당신의 심장을 관통했습니다. 눈앞이 캄캄해지고 있습니다.");
                        Wait(1);
                        Console.WriteLine("사망하였습니다");
                        Wait(1);
                        Console.Clear();
                        End();
                        break;
                    case "2":
                        mobItem();
                        Console.WriteLine("당신의 조아림에 기분이 좋아진 몬스터는 만족한 표정을 지으며 사라집니다.");
                        Wait(1);
                        Console.WriteLine("당신은 고대의 정령으로부터 생존하였습니다");
                        Wait(1);
                        Console.WriteLine("정령이 사라진 자리에서 아이템을 습득하였습니다");
                        Wait(1);
                        for (int i = 0; i < mItems.Length; i++)
                        {
                            Console.WriteLine($"- {mItems[i].name} (Type: {mItems[i].type})");
                        }
                        for (int i = 0; i < mItems.Length; i++)
                        {
                            items[i].Name = mItems[i].name;
                            items[i].type = mItems[i].type;
                        }
                        Wait(2);
                        break;
                    case "3":
                        Console.WriteLine("당신은 뒤로 몬스터가 재빠르게 접근했습니다!");
                        Wait(1);
                        Console.WriteLine("등에 뜨거운 고통이 느껴지더니 눈 앞이 캄캄해졌습니다");
                        Wait(1);
                        Console.WriteLine("사망하였습니다");

                        Wait(1);
                        Console.Clear();
                        End();
                        break;
                    default:
                        break;
                }
            }
            Wait(1);
            Console.WriteLine("늪지를 지나 다시 마을로 돌아갑니다...");
            Wait(1);
            data.running2 = true;
            data.scene = Scene.Maze;
        }
        static void Maze()
        {
            Console.WriteLine("따뜻한 마을이다. 사람들이 많다.");
            Console.WriteLine("행동하여 스토리를 진행하세요");
            Wait(2);
            Console.Clear();

            data.playerPos = new Point() { x = 1, y = 1 };
            while (data.running2)
            {
                Render();
                Input();
                Update();
            }
        }

        static void PrintMap()
        {
            for (int y = 0; y < data.map.GetLength(0); y++)
            {
                for (int x = 0; x < data.map.GetLength(1); x++)
                {
                    if (data.map[y, x])
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }
        static void PrintPlayer()
        {
            Console.SetCursorPosition(data.playerPos.x, data.playerPos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("P");
            Console.ResetColor();
        }

        static void PrintBox1()
        {
            Console.SetCursorPosition(data.BoxPos1.x, data.BoxPos1.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("H");
            Console.ResetColor();
        }
        static void PrintBox2()
        {
            Console.SetCursorPosition(data.BoxPos2.x, data.BoxPos2.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("B");
            Console.ResetColor();
        }
        static void PrintBox3()
        {
            Console.SetCursorPosition(data.BoxPos3.x, data.BoxPos3.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("F");
            Console.ResetColor();
        }
        static void PrintBox4()
        {
            Console.SetCursorPosition(data.BoxPos4.x, data.BoxPos4.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("S");
            Console.ResetColor();
        }


        static void Input()
        {
            data.inputKey = Console.ReadKey(true).Key;
        }
        static void Update()
        {
            Move();
            CheckGameClear();
        }
        static void Render()
        {
            Console.Clear();

            PrintMap();
            PrintPlayer();
            PrintBox1();
            PrintBox2();
            PrintBox3();
            PrintBox4();

            Console.WriteLine();
            Console.WriteLine();
            PrintProfile();
        }
        static void Move()
        {
            switch (data.inputKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
            }
        }

        static void CheckGameClear()
        {
            if (data.playerPos.x == data.BoxPos1.x &&
                data.playerPos.y == data.BoxPos1.y)
            {
                data.running2 = false;
                Console.Clear();
                Console.WriteLine("여관에 들어갑니다.");
                Wait(2);

                data.playerPos = new Point() { x = 1, y = 1 };
                data.scene = Scene.Town;
            }
            else if (data.playerPos.x == data.BoxPos2.x &&
                data.playerPos.y == data.BoxPos2.y)
            {
                data.running2 = false;
                Console.Clear();
                Console.WriteLine("가방을 확인합니다.");
                Wait(1);
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine($"- {i + 1}번 칸 Name : {items[i].Name} (Type : {items[i].type})");
                }
                Console.ReadKey();
                data.running2 = true;
                data.playerPos = new Point() { x = 1, y = 1 };
                data.scene = Scene.Maze;
            }
            else if (data.playerPos.x == data.BoxPos3.x &&
                data.playerPos.y == data.BoxPos3.y)
            {
                data.running2 = false;
                Console.Clear();
                Console.WriteLine("마을 밖 숲에 들어갑니다.");
                Wait(2);

                data.playerPos = new Point() { x = 1, y = 1 };
                data.scene = Scene.Forest;
            }
            else if (data.playerPos.x == data.BoxPos4.x &&
                data.playerPos.y == data.BoxPos4.y)
            {
                data.running2 = false;
                Console.Clear();
                Console.WriteLine("마을 뒤 숲에 들어갑니다.");
                Wait(2);

                data.playerPos = new Point() { x = 1, y = 1 };
                data.scene = Scene.Swarm;
            }
        }
        static void MoveUp()
        {
            Point next = new Point() { x = data.playerPos.x, y = data.playerPos.y - 1 };
            if (data.map[next.y, next.x])
            {
                data.playerPos = next;
            }
        }

        static void MoveDown()
        {
            Point next = new Point() { x = data.playerPos.x, y = data.playerPos.y + 1 };
            if (data.map[next.y, next.x])
            {
                data.playerPos = next;
            }
        }

        static void MoveLeft()
        {
            Point next = new Point() { x = data.playerPos.x - 1, y = data.playerPos.y };
            if (data.map[next.y, next.x])
            {
                data.playerPos = next;
            }
        }

        static void MoveRight()
        {
            Point next = new Point() { x = data.playerPos.x + 1, y = data.playerPos.y };
            if (data.map[next.y, next.x])
            {
                data.playerPos = next;
            }
        }
    }
}
