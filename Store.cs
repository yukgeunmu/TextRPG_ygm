using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_ygm.Program;

namespace TextRPG_ygm
{
    internal class Store
    {
        public void StoreDisplay(Player player, List<Equipment> equipment)
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine(player.gold + " G\n");
                Console.WriteLine("[아이템 목록]");

                foreach (var item in equipment)
                {
                    if (item.type == EquipmentType.armor)
                    {
                        Console.Write("- {0}  |방어력 +{1}  | {2}  | ", item.name, item.ability, item.Description);
                        if (item.isBuy == true)
                        {
                            Console.WriteLine("구매완료");
                        }
                        else
                        {
                            Console.WriteLine(item.price + " G");
                        }
                    }
                    else if (item.type == EquipmentType.weapon)
                    {
                        Console.Write("- {0}  |공격력 +{1}  | {2}  | ", item.name, item.ability, item.Description);
                        if (item.isBuy == true)
                        {
                            Console.WriteLine("구매완료");
                        }
                        else
                        {
                            Console.WriteLine(item.price + " G");
                        }
                    }

                }

                Console.WriteLine();
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
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
                        StorebuyDisplay(player, equipment);
                    }
                    else if (selectnumber == 2)
                    {
                        StoreSellDisplay(player, equipment);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

                Console.ReadKey();

            }

            Console.WriteLine("아무키나 누르세요.");
        }

        public void StorebuyDisplay(Player player, List<Equipment> equipment)

        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점-아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine(player.gold + " G\n");
                Console.WriteLine("[아이템 목록]");
                int i = 1;

                foreach (var item in equipment)
                {
                    if (item.type == EquipmentType.armor)
                    {
                        Console.Write("- {0} {1}  |방어력 +{2}  | {3}  | ", i, item.name, item.ability, item.Description);
                        if (item.isBuy == true)
                        {
                            Console.WriteLine("구매완료");
                        }
                        else
                        {
                            Console.WriteLine(item.price + " G");
                        }
                    }
                    else if (item.type == EquipmentType.weapon)
                    {
                        Console.Write("- {0} {1} |공격력 +{2}  | {3}  | ", i, item.name, item.ability, item.Description);
                        if (item.isBuy == true)
                        {
                            Console.WriteLine("구매완료");
                        }
                        else
                        {
                            Console.WriteLine(item.price + " G");
                        }
                    }

                    i++;
                }


                Console.WriteLine();
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
                    else if (selectnumber >= 1 && selectnumber <= equipment.Count)
                    {
                        if (player.gold >= equipment[selectnumber - 1].price && equipment[selectnumber - 1].isBuy == false)
                        {
                            player.gold = player.gold - equipment[selectnumber - 1].price;
                            equipment[selectnumber - 1].isBuy = true;
                            Console.WriteLine("구매를 완료했습니다.");
                            Console.ReadKey();

                        }
                        else if (equipment[selectnumber - 1].isBuy == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Gold가 부족합니다.");
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

        public void StoreSellDisplay(Player player, List<Equipment> equipment)
        {

            
            while (true)
            {

                List<Equipment> equipmentSell = new List<Equipment>();

                foreach (var item in equipment)
                {
                    if (item.isBuy == true)
                    {
                        equipmentSell.Add(item);
                    }
                }

                Console.Clear();
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine(player.gold + "G\n");
                Console.WriteLine("[아이템 목록]");

                int i = 1;

                foreach (Equipment item in equipmentSell)
                {
                    if (item.type == EquipmentType.armor)
                    {
                        float sell = item.price * 0.85f;
                        Console.WriteLine("- {0} {1}    | 방어력 +{2}    | {3}    | {4} G", i, item.name, item.ability, item.Description, (int)sell);
                    }
                    else if (item.type == EquipmentType.weapon)
                    {
                        float sell = item.price * 0.85f;
                        Console.WriteLine("- {0} {1}    | 공격력 +{2}    | {3}    | {4} G", i, item.name, item.ability, item.Description, (int)sell);
                    }

                    i++;

                }

                Console.WriteLine();
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
                    else if (selectnumber >= 1 && selectnumber <= equipmentSell.Count)
                    {
                        float sell = equipmentSell[selectnumber - 1].price * 0.85f;
                        player.gold += (int)sell;
                        equipmentSell[selectnumber - 1].isBuy = false;

                        if (equipmentSell[selectnumber - 1].Eq == true)
                        {
                            equipmentSell[selectnumber - 1].Eq = false;
                            if (equipmentSell[selectnumber - 1].type == EquipmentType.armor)
                            {
                                player.defence -= equipmentSell[selectnumber - 1].ability;
                            }
                            else if (equipmentSell[selectnumber - 1].type == EquipmentType.weapon)
                            {
                                player.attack -= equipmentSell[selectnumber - 1].ability;
                            }
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

        }



    }
}
