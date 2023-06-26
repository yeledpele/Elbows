using UnityEngine;

namespace QueueUp.Data
{
    public class PlayerStats
        : ScriptableObject
    {

        public int Hp;
        public int Pat;
        public int Ass;
        public int Str;
        public int Spd;

        public Sprite PlayerImage; // in case we want to add an image somewhere
    }
}
