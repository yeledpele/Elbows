using UnityEngine;

namespace QueueUp.Data
{
    public abstract class CardData
        : ScriptableObject
    {
        [Header("Card Data")]
        [SerializeField] private Sprite _backImage;
        [SerializeField] private Sprite _frontImage;
        [SerializeField] private string _displayName;
        
        public Sprite BackImage => _backImage;
        public Sprite FrontImage => _frontImage;
        public string DisplayName => _displayName;
        public abstract CardType Type { get; }
    }
}
