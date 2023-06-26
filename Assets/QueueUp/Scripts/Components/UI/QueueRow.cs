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

        public void SetTint(Color value)
        {
            Left.SetTint(value);
            Center.SetTint(value);
            Right.SetTint(value);
        }

        public QueueRow Initialize(int index)
        {
            name = $"Row ({index})";
            _queueIndex = index;
            _left = this.GetNamedComponent<CardView>("Left");
            _center = this.GetNamedComponent<CardView>("Center");
            _right = this.GetNamedComponent<CardView>("Right");
            return this;
        }
    }
}
