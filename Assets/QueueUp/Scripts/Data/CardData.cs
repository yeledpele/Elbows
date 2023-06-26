using UnityEngine;

namespace QueueUp.Data
{
    public abstract class CardData
        : ScriptableObject
    {
        [SerializeField] private Sprite _backImage;
        [SerializeField] private Sprite _frontImage;
        public Sprite BackImage => _backImage;
        public Sprite FrontImage => _frontImage;
        public abstract CardType Type { get; }
    }
}
