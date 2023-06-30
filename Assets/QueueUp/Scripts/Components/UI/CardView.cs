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
        [SerializeField] private int _clickCount;
        [SerializeField] private float _lastClickTime;
        [SerializeField] private float _delta;

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
                var currentTime = Time.realtimeSinceStartup;
                var delta = _delta = currentTime - _lastClickTime;
                if (_clickCount == 2)
                {
                    _clickCount = 0;
                    if (delta < 0.3f)
                        _clicked.Invoke();
                }
                
                _lastClickTime = currentTime;
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
            return this;
        }

        private void Awake()
        {
            _lastClickTime = Time.realtimeSinceStartup;
            _owner = GetComponentInParent<QueueRow>();
        }
    }
}
