using UnityEngine;

namespace Elbows.Data
{
    /// <summary>
    /// The QueueCardData data container provides information about a single queue
    /// card (NPC or Event).
    /// </summary>
    [CreateAssetMenu(menuName = "Elbows/Queue Card Data")]
    public class QueueCardData
        : ScriptableObject
    {
        [SerializeField] private Sprite _backImage;
        [SerializeField] private Sprite _frontImage;
        public Sprite BackImage => _backImage;
        public Sprite FrontImage => _frontImage;
    }
}
