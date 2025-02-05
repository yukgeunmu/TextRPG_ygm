using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_ygm.Program;

namespace TextRPG_ygm
{

    internal class Status
    {
        public void StatusDisPlayRe(Player player, List<Equipment> equipment)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Lv. {player.Lv}");
                Console.WriteLine($"{player.name} ({player.job})");


                // 무기 장착 따른 공격력 변경 로직
                if (equipment.Count != 0)
                {
                    int weaponTotalDamage = 0;

                    foreach (var weapons in equipment)
                    {
                        if (weapons.type == EquipmentType.weapon && weapons.Eq == true)
                        {
                            weaponTotalDamage += weapons.ability;
                        }
                    }

                    if (weaponTotalDamage == 0)
                    {
                        Console.WriteLine($"공격력: {player.attack}");
                    }
                    else
                    {
                        Console.WriteLine($"공격력: {player.attack} (+{weaponTotalDamage})");
                    }

                }
                else
                {
                    Console.WriteLine($"공격력: {player.attack}");
                }


                // 장착된 방어구에 따른 토탈 방어력 로직
                if (equipment.Count != 0)
                {
                    int armorTotalDenfence = 0;

                    foreach (var armors in equipment)
                    {
                        if (armors.type == EquipmentType.armor && armors.Eq == true)
                        {
                            armorTotalDenfence += armors.ability;
                        }
                    }

                    if (armorTotalDenfence == 0)
                    {
                        Console.WriteLine($"방어력: {player.defence}");
                    }
                    else
                    {
                        Console.WriteLine($"방어력: {player.defence} (+{armorTotalDenfence})");
                    }

                }
                else
                {
                    Console.WriteLine($"방어력: {player.defence}");
                }


                Console.WriteLine($"체력: {player.health}");
                Console.WriteLine($"Gold: {player.gold}\n");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");


                // 행동 선택하는 로직
                string input = Console.ReadLine();
                int selectnumber;
                bool isNumber = int.TryParse(input, out selectnumber);

                if (isNumber)
                {
                    if (selectnumber == 0)
                    {
                        break;
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
