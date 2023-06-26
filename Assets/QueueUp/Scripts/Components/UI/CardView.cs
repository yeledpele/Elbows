using System;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;
using QueueUp.Data;
using QueueUp.Enums;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Event = BinaryEyes.Common.Data.Event;

namespace QueueUp.Components.UI
{
    public class CardView
        : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] [ReadOnlyField] private CardViewState _state;
        [SerializeField] [ReadOnlyField] private QueueRow _owner;
        [SerializeField] [ReadOnlyField] private CardData _data;
        [SerializeField] [ReadOnlyField] private Image _image;
        [SerializeField] private Event _clicked;
        public IEvent Clicked => _clicked;
        public int QueueIndex => _owner.QueueIndex;
        public CardData Data => _data;
        public CardViewState State => _state;
        public string GetPath() => $"{_owner.name}/{name}";

        public void Reveal()
        {
            if (_state == CardViewState.Revealed)
                throw new InvalidOperationException("card is already revealed");

            _image.sprite = _data.FrontImage;
            _state = CardViewState.Revealed;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            this.LogMessage($"Clicked: {GetPath()}");
            _clicked.Invoke();
        }

        public void SetTint(Color value)
            => _image.color = value;

        public CardView Initialize(CardData data)
        {
            _image = GetComponent<Image>();
            if (data == null)
            {
                gameObject.SetActive(false);
                return this;
            }

            _data = data;
            _image.sprite = data.BackImage;
            return this;
        }

        private void Awake()
            => _owner = GetComponentInParent<QueueRow>();
    }
}
