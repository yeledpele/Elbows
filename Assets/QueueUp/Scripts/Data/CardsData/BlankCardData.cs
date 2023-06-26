using System;
using UnityEngine;

namespace QueueUp.Data.CardsData
{
    [Serializable]
    [CreateAssetMenu(menuName = "Queue Up/Card Data/Blank", order = -10_000)]
    public class BlankCardData
        : CardData
    {
        public override CardType Type => CardType.Blank;
    }
}
