using UnityEngine;

namespace QueueUp.Data
{
    public abstract class CardData
        : ScriptableObject
    {
        public abstract CardType Type { get; }
    }
}
