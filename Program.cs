using System;
using System.IO;
using System.Text.Json;


namespace TextRPG_ygm
{
    internal class Program
    {
        class GameStart
        {
            // 플레이어 기본 설정
            Player player = new Player(1, "chad", "전사", 10, 5, 100, 4000);

            // 게임 시작 화면
            public void Start()
            {
                Status Status = new Status();
                Inven inven = new Inven();
                Store store = new Store();
                Dungeon dungeon = new Dungeon();
                HealTake healTake = new HealTake();
                SaveandLoad saveandLoad = new SaveandLoad();
                EquipmentLIsts equipmentLIsts = new EquipmentLIsts();

                List<Equipment> equipment = equipmentLIsts.equipment;
                List<DungeonBase> dungeons = dungeon.dungeons;

                while (true)
                {
                    List<Equipment> trueEquipment = EquimentMe(equipment);

                    Console.Clear();
                    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                    Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점");
                    Console.WriteLine("4. 던전입장");
                    Console.WriteLine("5. 휴식하기");
                    Console.WriteLine("6. 저장하기/불러오기\n");
                    Console.WriteLine("0. 나가기\n");
                    Console.WriteLine("원하시는 행동을 입력하세요.");

                    string input = Console.ReadLine();
                    int selectnumber;
                    bool isNumber = int.TryParse(input, out selectnumber);

                    if (isNumber)
                    {
                        switch (selectnumber)
                        {
                            case 1:
                                Status.StatusDisPlayRe(player, trueEquipment);
                                break;
                            case 2:
                                inven.InvenDisPlayRe(player, trueEquipment);
                                break;
                            case 3:
                                store.StoreDisplay(player, equipment);
                                break;
                            case 4:
                                if (player.health <= 0) Console.WriteLine("체력이 0이라 입장이 안됩니다.");  
                                else dungeon.DungeonExit(player, dungeons);
                                break;
                            case 5:
                                healTake.HealDisplay(player);
                                break;
                            case 6:
                                saveandLoad.SaveAndLoadDisplay(player, equipment);
                                break;
                            case 0:
                                Console.WriteLine("게임을 종료합니다.");
                                return;
                            default:
                                Console.WriteLine("잘못된 입력입니다.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }

                    Console.ReadKey();

                }


            }

            //상점에서 구매한 목록만 모으는 리스트
            public List<Equipment> EquimentMe(List<Equipment> equipment)
            {
                List<Equipment> equipmentMe = new List<Equipment>();


                for (int i = 0; i < equipment.Count; i++)
                {
                    if (equipment[i].isBuy == true)
                    {
                        equipmentMe.Add(equipment[i]);
                    }
                }

                return equipmentMe;
            }

        }

        // 플레이어 클래스
        public class Player
        {
            public int Lv { get; set; }
            public string name { get; set; }
            public string job { get; set; }
            public float attack { get; set; }
            public int defence { get; set; }
            public int health { get; set; }
            public int gold { get; set; }

            public Player() { }

            public Player(int _Lv, string _name, string _job, float _attack, int _defence, int _health, int _gold)
            {
                this.Lv = _Lv;
                this.name = _name;
                this.job = _job;
                this.attack = _attack;
                this.defence = _defence;
                this.health = _health;
                this.gold = _gold;

            }
        }
        
        public class GameData
        {
            public Player Player { get; set; } = new Player();
            public List<Equipment> Equipment { get; set; } = new List<Equipment>();

            public GameData() { }

        }

        static void Main(string[] args)
        {
            GameStart gamestart = new GameStart();

            gamestart.Start();

        }
    }
}
