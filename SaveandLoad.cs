using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static TextRPG_ygm.Program;

namespace TextRPG_ygm
{
    internal class SaveandLoad
    {
        // 저장하기 및 불러오기 화면
        public void SaveAndLoadDisplay(Player player, List<Equipment> equipment)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("저장하기/불러오기\n");
                Console.WriteLine("1. 저장하기");
                Console.WriteLine("2. 불러오기\n");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력하세요.");

                string input = Console.ReadLine();
                int selectnumber;
                bool isNumber = int.TryParse(input, out selectnumber);

                if (isNumber)
                {
                    switch(selectnumber)
                    {
                        case 0:
                            return;
                        case 1:
                            SaveTextRPG(player, equipment);
                            break;
                        case 2:
                            GameData data = LoadTextRPG();
                            DataTransform(player, equipment, data);
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

        public void SaveTextRPG(Player player, List<Equipment> equipment, string filename = "SaveTextRPG.json")
        {
            GameData data = new GameData() { Player = player, Equipment = equipment};

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
            Console.WriteLine("게임이 저장되었습니다.");
        }


        public GameData LoadTextRPG(string filename = "SaveTextRPG.json")
        {
           if(!File.Exists(filename))
            {
                Console.WriteLine("저장된 데이터가 없습니다.");
                return new GameData {Player = new Player(), Equipment = new List<Equipment>()};             
            }
           else
            {
                string json =File.ReadAllText(filename);
                GameData data = JsonSerializer.Deserialize<GameData>(json);

                Console.WriteLine("저장된 데이터를 불러왔습니다.");
                return data;
            }

        }

        // 불러온 데이터 전달하는 메서드
        public void DataTransform(Player player,List<Equipment> equipment ,GameData _data)
        {
            player.Lv = _data.Player.Lv;
            player.name = _data.Player.name;
            player.job = _data.Player.job;
            player.health = _data.Player.health;
            player.defence = _data.Player.defence;
            player.attack = _data.Player.attack;
            player.gold = _data.Player.gold;

            int i = 0;

            foreach(var item in _data.Equipment)
            {
                equipment[i].name = item.name;
                equipment[i].Description = item.Description;
                equipment[i].price = item.price;
                equipment[i].ability = item.ability;
                equipment[i].type = item.type;
                equipment[i].isBuy = item.isBuy;
                equipment[i].Eq = item.Eq;
                i++;
            }
            
        }


    }


}
