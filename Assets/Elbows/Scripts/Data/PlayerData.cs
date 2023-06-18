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
        [SerializeField] private string _name;
        public string Name => _name;
    }
}
