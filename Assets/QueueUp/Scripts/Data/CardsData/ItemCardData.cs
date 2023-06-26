using UnityEngine;

namespace QueueUp.Data.CardsData
{
    [CreateAssetMenu(menuName = "Queue Up/Card Data/Item")]
    public class ItemCardData
        : CardData
    {
        public override CardType Type => CardType.Item;
    }
}