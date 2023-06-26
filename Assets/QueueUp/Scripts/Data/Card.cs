using System;

namespace QueueUp.Data
{
    [Serializable]
    public class Card
    {
        private readonly CardData _data;

        public Card(CardData data)
        {
            _data = data;
        }
    }
}
