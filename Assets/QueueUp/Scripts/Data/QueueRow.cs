using System;
using BinaryEyes.Common.Attributes;
using UnityEngine;

namespace QueueUp.Data
{
    [Serializable]
    public class QueueRow
    {
        [SerializeField] [ReadOnlyField] private Card[] _cards;
        public Card LeftCard => _cards[0];
        public Card CenterCard => _cards[1];
        public Card RightCard => _cards[2];

        public QueueRow(CardData[] data)
        {

        }
    }
}
