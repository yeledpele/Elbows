using System.Collections.Generic;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using QueueUp.Data;
using QueueUp.Enums;
using UnityEngine;

namespace QueueUp.Components.UI
{
    public class QueueRow
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private int _queueIndex;
        [SerializeField] [ReadOnlyField] private List<CardView> _views;
        public int QueueIndex => _queueIndex;
        public CardView Left => _views[0];
        public CardView Center => _views[1];
        public CardView Right => _views[2];

        public void SetTint(Color value)
        {
            Left.SetTint(value);
            Center.SetTint(value);
            Right.SetTint(value);
        }

        public QueueRow Initialize(int index, CardData[] data)
        {
            name = $"Row ({index})";
            _queueIndex = index;
            var types = new[] { "Left", "Center", "Right" };
            for (var i = 0; i < data.Length; i++)
            {
                var cardData = data[i];
                var type = types[i];
                var view = this.GetNamedComponent<CardView>(type)
                    .Initialize(cardData);

                view.Clicked.AddListener(() => HandleViewClicked(view));
                _views.Add(view);
            }

            return this;
        }

        private void HandleViewClicked(CardView view)
        {
            if (view.State == CardViewState.Unknown)
                view.Reveal();
        }
    }
}
