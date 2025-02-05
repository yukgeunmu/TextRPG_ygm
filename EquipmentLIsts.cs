using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_ygm.Program;

namespace TextRPG_ygm
{
    internal class EquipmentLIsts
    {


        public List<Equipment> equipment = new List<Equipment>
            {
               new Equipment ("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 1000, 5, EquipmentType.armor, false, false),
               new Equipment ("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 2100, 9, EquipmentType.armor, false, false),
               new Equipment ("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, 15, EquipmentType.armor, false, false),
               new Equipment ( "낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 600, 2, EquipmentType.weapon, false, false),
               new Equipment ( "청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 1500, 5, EquipmentType.weapon, false, false),
               new Equipment ( "스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3200,  7, EquipmentType.weapon, false, false),
               new Equipment ( "YGM개발자의 검", "YGM개발자가 만든 창조자의 검입니다.", 9999, 99, EquipmentType.weapon, false, false)

            };
    }

    public class Item
    {
        public string name { get; set; }
        public string Description { get; set; }
        public int price { get; set; }
        public bool isBuy { get; set; }

    }

    public enum EquipmentType
    {
        armor,
        weapon
    }

    public class Equipment : Item
    {
        public int ability { get; set; }
        public EquipmentType type { get; set; }
        public bool Eq { get; set; }

        public Equipment() { }

        public Equipment(string _name, string _Description, int _price, int _ability, EquipmentType _type, bool _isBuy, bool _Eq)
        {
            name = _name;
            Description = _Description;
            price = _price;
            ability = _ability;
            type = _type;
            isBuy = _isBuy;
            Eq = _Eq;
        }
    }


}
