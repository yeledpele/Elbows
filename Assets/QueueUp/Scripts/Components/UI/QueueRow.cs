using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace QueueUp.Components.UI
{
    public class QueueRow
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private int _queueIndex;
        [SerializeField] [ReadOnlyField] private CardView _left;
        [SerializeField] [ReadOnlyField] private CardView _center;
        [SerializeField] [ReadOnlyField] private CardView _right;
        public int QueueIndex => _queueIndex;
        public CardView Left => _left;
        public CardView Center => _center;
        public CardView Right => _right;

        public QueueRow Initialize(int index)
        {
            _queueIndex = index;
            _left = this.GetNameComponent<CardView>("Left");
            _center = this.GetNameComponent<CardView>("Center");
            _right = this.GetNameComponent<CardView>("Right");
            return this;
        }
    }
}
