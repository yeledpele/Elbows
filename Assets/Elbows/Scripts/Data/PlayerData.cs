using UnityEngine;

namespace Elbows.Data
{
    /// <summary>
    /// The PlayerData container provides starting information regarding the
    /// state of the current player.
    /// </summary>
    [CreateAssetMenu(menuName = "Elbows/Player Data")]
    public class PlayerData
        : ScriptableObject
    {
        public int HealthPoints;
        public int Patience;
        public int Assertiveness;
        public int Strength;
        public int Speed;
    }
}
