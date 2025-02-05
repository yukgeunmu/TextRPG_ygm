using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_ygm.Program;

namespace TextRPG_ygm
{
    internal class Dungeon
    {
        // 던전 리스트
        public List<DungeonBase> dungeons = new List<DungeonBase>()
            {
                new DungeonBase("쉬운 던전", 1000, 5),
                new DungeonBase( "일반 던전", 1700, 11),
                new DungeonBase("어려운 던전", 2500, 17)
            };

        // 던전 입장 화면
        public void DungeonExit(Player player, List<DungeonBase> dungeons)
        {

            while (true)
            {
                Console.Clear();
                
                if(player.health <= 0)
                {
                    Console.WriteLine("메인화면으로 돌아갑니다.");
                    Console.WriteLine("아무키나 누르세요.");
                    return;
                }

                Console.WriteLine("던전입장");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1. 쉬운 던전\t방어력 5 이상 권장");
                Console.WriteLine("2. 일반 던전\t방어력 11 이상 권장");
                Console.WriteLine("3. 어려운 던전\t방어력 17이상 권장\n");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                string input = Console.ReadLine();
                int selectnumber;
                bool isNumber = int.TryParse(input, out selectnumber);

                if (isNumber)
                {
                    switch (selectnumber)
                    {
                        case 0:
                            Console.WriteLine("아무키나 누르세요.");
                            return;
                        case 1:
                            DunGeon(player, dungeons, selectnumber);
                            break;
                        case 2:
                            DunGeon(player, dungeons, selectnumber);
                            break;
                        case 3:
                            DunGeon(player, dungeons, selectnumber);
                            break;
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

        public void DunGeon(Player player, List<DungeonBase> dungeons, int dungeonNumebr)
        {
            // 매개변수로 받은 숫자를 받아서 던전 리스트 중에 하나를 dungeon 변수에 넣기
            DungeonBase selectDungeon = dungeons[dungeonNumebr - 1];
            

            // 랜덤 숫자
            Random random = new Random();

            // 0~9 까지 숫자 중 0~3 사이 숫자가 나올 확률은 40%
            int clearNumber = random.Next(0, 10);

            // 20~36 랜덤 숫자 중에 데미지 선택
            int basicdamage = random.Next(20, 36);

            // 각 던전에 맞는 보상 할당
            int basicReword = selectDungeon.reword;

            // 공격력에 따른 보상 추가 보상
            int attackPercetntage = random.Next((int)player.attack, (int)player.attack * 2);
            float addReword = basicReword * attackPercetntage / 100;

            int resultdamge;
            //최종 데미지
            if (selectDungeon.damge > player.defence)
            {
                resultdamge = basicdamage + (selectDungeon.damge - player.defence);
            }
            else
            {
                resultdamge = basicdamage;
            }
            
            //최종 보상
            int resultReword = basicReword + (int)addReword;

            // 권장 방어력에 따른 if문 로직
            if (player.defence < selectDungeon.damge)
            {
                // 40% 확률로 실패
                if (clearNumber <= 3)
                {
                    DefeatDIsplay(selectDungeon, player);
                }
                else
                {
                    ClearDisplay(selectDungeon, player, resultdamge, resultReword);
                }
            }
            else
            {

                ClearDisplay(selectDungeon, player, resultdamge, resultReword);
            }

        }


        // 클리어 화면
        public void ClearDisplay(DungeonBase dungeon, Player player, int dungeonDamage, int dungeonreword)
        {
            int hp = player.health;
            int gold = player.gold;

            player.health -= dungeonDamage;
            player.gold += dungeonreword;

            //던전 클리어시 레벨업
            player.Lv++;
            player.attack += 0.5f;
            player.defence++;

            while (true)
            {
                Console.Clear();

                if(player.health <= 0)
                {
                    player.health = 0;
                    DeadDisplay();
                    return;

                }

                Console.WriteLine("던전 클리어");
                Console.WriteLine("축하합니다.!!");
                Console.WriteLine("{0}을 클리어 하였습니다.\n", dungeon.name);
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine("체력 {0} -> {1}", hp, player.health);
                Console.WriteLine("Gold {0} G -> {1} G\n", gold, player.gold);
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                string input = Console.ReadLine();
                int selectnumber;
                bool isNumber = int.TryParse(input, out selectnumber);

                if (isNumber)
                {
                    switch (selectnumber)
                    {
                        case 0:
                            Console.WriteLine("아무키나 누르세요.");
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

        // 클리어 실패 화면
        public void DefeatDIsplay(DungeonBase dungeon, Player player)
        {
            int hp = player.health;

            player.health /= 2;


            Console.Clear();
            Console.WriteLine("던전 클리어 실패");
            Console.WriteLine("{0}에 클리어를 실패하셨습니다.\n", dungeon.name);
            Console.WriteLine("[탐험결과]");
            Console.WriteLine("체력 {0} -> {1}", hp, player.health);
            Console.WriteLine("Gold {0} G\n", player.gold);
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            string input = Console.ReadLine();
            int selectnumber;
            bool isNumber = int.TryParse(input, out selectnumber);

            if (isNumber)
            {
                switch (selectnumber)
                {
                    case 0:
                        Console.WriteLine("아무키나 누르세요.");
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

        public void DeadDisplay()
        {
            Console.WriteLine("사망하였습니다.");
            Console.WriteLine("아무키나 누르세요.");
            Console.ReadKey();
        }


    }

    public class DungeonBase
    {
        public string name { get; set; }
        public int reword { get; set; }
        public int damge { get; set; }

        public DungeonBase(string _name, int _reword, int _damge)
        {
            name = _name;
            reword = _reword;
            damge = _damge;
        }

    }
}
