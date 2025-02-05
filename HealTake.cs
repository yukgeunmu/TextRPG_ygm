using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_ygm.Program;

namespace TextRPG_ygm
{
    internal class HealTake
    {
        public void HealDisplay(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("휴식하기");
                Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)\n", player.gold);

                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");


                string input = Console.ReadLine();
                int selectnumber;
                bool isNumber = int.TryParse(input, out selectnumber);

                if (isNumber)
                {
                    if (selectnumber == 0)
                    {
                        break;
                    }
                    else if (selectnumber == 1)
                    {
                        if (player.gold >= 500 && player.health < 100)
                        {
                            player.gold -= 500;
                            player.health = 100;
                            Console.WriteLine("휴식을 완료했습니다.");
                            Console.ReadKey();

                        }
                        else if (player.gold < 500)
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                            Console.ReadKey();
                        }
                        else if (player.health == 100)
                        {
                            Console.WriteLine("체력이 풀피입니다.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }

            }

            Console.WriteLine("아무키나 누르세요.");

        }


    }
}
