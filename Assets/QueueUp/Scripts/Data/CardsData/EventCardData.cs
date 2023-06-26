using UnityEngine;

namespace QueueUp.Data.CardsData
{
    [CreateAssetMenu(menuName = "Queue Up/Card Data/Event")]
    public class EventCardData
        : CardData
    {
        public override CardType Type => CardType.Event;
    }
}
