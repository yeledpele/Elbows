using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using QueueUp.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Event = BinaryEyes.Common.Data.Event;

namespace QueueUp.Components.UI
{
    public class CardView
        : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] [ReadOnlyField] private QueueRow _owner;
        [SerializeField] [ReadOnlyField] private CardData _data;
        [SerializeField] [ReadOnlyField] private Image _image;
        [SerializeField] private Event _clicked;
        public IEvent Clicked => _clicked;
        public int QueueIndex => _owner.QueueIndex;
        public CardData Data => _data;

        public void OnPointerClick(PointerEventData eventData)
            => _clicked.Invoke();

        public void SetTint(Color value)
            => _image.color = value;

        public CardView Initialize(CardData data)
        {
            _data = data;
            _image = GetComponent<Image>();
            _image.sprite = data.BackImage;
            return this;
        }

        private void Awake()
            => _owner = GetComponentInParent<QueueRow>();
    }
}
