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
        public float Battery;
        public float Fuel;
        public float Money;
    }
}
