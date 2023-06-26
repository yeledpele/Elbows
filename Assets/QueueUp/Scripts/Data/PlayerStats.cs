using UnityEngine;

namespace QueueUp.Data
{
    [CreateAssetMenu(menuName = "Queue Up/Player Stats", order = -20_000)]
    public class PlayerStats
        : ScriptableObject
    {
        public int Health;
        public int Patience;
        public int Assertiveness;
        public int Strength;
        public int Speed;

        public Sprite PlayerImage; // in case we want to add an image somewhere
    }
}
