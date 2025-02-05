using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_ygm.Program;

namespace TextRPG_ygm
{
    internal class Inven
    {
        public void InvenDisPlayRe(Player player, List<Equipment> equipment)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                // 상점에서 산 아이템 목록 표시
                foreach (var item in equipment)
                {
                    if (item.type == EquipmentType.armor)
                    {
                        if (item.Eq == true)
                        {
                            Console.WriteLine("- [E]{0}  |방어력 +{1}  | {2}  | ", item.name, item.ability, item.Description);
                        }
                        else
                        {
                            Console.WriteLine("- {0}  |방어력 +{1}  | {2}  | ", item.name, item.ability, item.Description);
                        }
                    }
                    else if (item.type == EquipmentType.weapon)
                    {
                        if (item.Eq == true)
                        {
                            Console.WriteLine("- [E]{0}  |공격력 +{1}  | {2}  | ", item.name, item.ability, item.Description);
                        }
                        else
                        {
                            Console.WriteLine("- {0}  |공격력 +{1}  | {2}  | ", item.name, item.ability, item.Description);
                        }
                    }

                }

                Console.WriteLine("");
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나기기\n");
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
                        EquimentDisPlay(player, equipment);
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

        public void EquimentDisPlay(Player player, List<Equipment> equipmentMe)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                int j = 1;

                foreach (var item in equipmentMe)
                {
                    if (item.type == EquipmentType.armor)
                    {
                        if (item.Eq == true)
                        {
                            Console.WriteLine("- {0} [E]{1}  |방어력 +{2}  | {3}", j, item.name, item.ability, item.Description);

                        }
                        else Console.WriteLine("- {0} {1}  |방어력 +{2}  | {3}", j, item.name, item.ability, item.Description);
                    }
                    else if (item.type == EquipmentType.weapon)
                    {
                        if (item.Eq == true)
                        {
                            Console.WriteLine("- {0} [E]{1}  |방어력 +{2}  | {3}", j, item.name, item.ability, item.Description);

                        }
                        else Console.WriteLine("- {0} {1} |공격력 +{2}  | {3}", j, item.name, item.ability, item.Description);
                    }

                    j++;

                }

                Console.WriteLine(" ");
                Console.WriteLine("0. 나가기 ");
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

                    // 구매한 장비가 있는가? 목록이 없을 경우 숫자 키 입력을 방지
                    else if (equipmentMe.Count != 0)
                    {
                        // 1~구매한 장비 만큼 숫자키 입력 받음
                        if (selectnumber >= 1 && selectnumber <= equipmentMe.Count)
                        {
                            // 장비가 장착된 상태가 아니면 실행
                            if (!equipmentMe[selectnumber - 1].Eq)
                            {
                                // 장비가 장착 안 된 상태인데 방어구면 실행
                                if (equipmentMe[selectnumber - 1].type == EquipmentType.armor)
                                {
                                    // 구매한 방어구를 다 돌아서 장착 안 된 상태로 돌림
                                    foreach (var difitem in equipmentMe)
                                    {
                                        if (difitem.Eq == true && difitem.type == EquipmentType.armor)
                                        {
                                            difitem.Eq = false;
                                            player.defence -= difitem.ability;
                                        }
                                    }

                                    //선택한 방어구 장착
                                    equipmentMe[selectnumber - 1].Eq = true;

                                    //플레이어 방어력 선택한 방어구 능력치 만큼 증가
                                    player.defence += equipmentMe[selectnumber - 1].ability;

                                }
                                else if (equipmentMe[selectnumber - 1].type == EquipmentType.weapon)
                                {
                                    foreach (var difitem in equipmentMe)
                                    {
                                        if (difitem.Eq == true && difitem.type == EquipmentType.weapon)
                                        {
                                            difitem.Eq = false;
                                            player.attack -= difitem.ability;
                                        }
                                    }

                                    equipmentMe[selectnumber - 1].Eq = true;
                                    player.attack += equipmentMe[selectnumber - 1].ability;

                                }
                            }
                            else
                            {
                                equipmentMe[selectnumber - 1].Eq = false;
                                if (equipmentMe[selectnumber - 1].type == EquipmentType.armor)
                                {
                                    player.defence -= equipmentMe[selectnumber - 1].ability;
                                }
                                else if (equipmentMe[selectnumber - 1].type == EquipmentType.weapon)
                                {
                                    player.attack -= equipmentMe[selectnumber - 1].ability;
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
