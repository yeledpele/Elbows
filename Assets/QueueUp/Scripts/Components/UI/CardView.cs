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
        public const float DoubleClickDelay = 0.3f;
        [SerializeField] [ReadOnlyField] private CardViewState _state;
        [SerializeField] [ReadOnlyField] private QueueRow _owner;
        [SerializeField] [ReadOnlyField] private CardData _data;
        [SerializeField] [ReadOnlyField] private Image _image;
        [SerializeField] private Event _clicked;
        [SerializeField] private int _clickCount;
        [SerializeField] private float _clickTimeLeft;

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
            if (_state == CardViewState.Unknown)
                _clicked.Invoke();
            else
            {
                _clickCount += 1;
                _clickTimeLeft = DoubleClickDelay;
                if (_clickCount < 2)
                    return;

                _clickCount = 0;
                _clickTimeLeft = -1.0f;
                _clicked.Invoke();
            }
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
            _state = CardViewState.Unknown;
            return this;
        }

        private void Update()
        {
            if (_state == CardViewState.Unknown)
                return;

            if (_clickCount == 0)
                return;

            _clickTimeLeft -= Time.deltaTime;
            if (_clickTimeLeft > 0.0f)
                return;

            _clickCount -= 1;
            if (_clickCount > 0)
                _clickTimeLeft = DoubleClickDelay;
        }

        private void Awake()
            => _owner = GetComponentInParent<QueueRow>();
    }
}
