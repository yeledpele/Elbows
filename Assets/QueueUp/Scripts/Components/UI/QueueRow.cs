using System.Collections.Generic;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;
using QueueUp.Data;
using QueueUp.Data.CardsData;
using QueueUp.Enums;
using TMPro;
using UnityEngine;
using Event = BinaryEyes.Common.Data.Event;

namespace QueueUp.Components.UI
{
    public class QueueRow
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private int _queueIndex;
        [SerializeField] [ReadOnlyField] private List<CardView> _views;
        [SerializeField] private Event _advancePlayerRequested;
        [SerializeField] private Event<CharacterCardData> _playerCombatRequested;
        public int QueueIndex => _queueIndex;
        public CardView Left => _views[0];
        public CardView Center => _views[1];
        public CardView Right => _views[2];
        public IEvent AdvancePlayerRequested => _advancePlayerRequested;
        public IEvent<CharacterCardData> PlayerCombatRequested => _playerCombatRequested;

        public void SetTint(Color value)
        {
            Left.SetTint(value);
            Center.SetTint(value);
            Right.SetTint(value);
        }

        public QueueRow Initialize(int index, CardData[] data)
        {
            _queueIndex = index;
            name = $"Row ({index})";
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
            {
                view.Reveal();
                return;
            }

            var data = view.Data;
            if (data.Type == CardType.Blank)
                _advancePlayerRequested.Invoke();

            if (data.Type == CardType.Character)
                _playerCombatRequested.Invoke(data as CharacterCardData);
        }
    }
}
