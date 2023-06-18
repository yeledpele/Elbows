using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using Elbows.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Elbows.EventComponents
{
    /// <summary>
    /// The QueueEventPanel behaviour provides information and operations related
    /// to a single queue panel within a queue event.
    /// </summary>
    public class QueueEventPanel
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private Image _background;
        [SerializeField] [ReadOnlyField] private Image _cardView;
        [SerializeField] private EventPanelType _type;
        public EventPanelType Type => _type;

        public void SetBackground(Sprite image)
        {
            _background.sprite = image;
        }

        public void SetActiveView(Sprite image)
        {
            _cardView.gameObject.SetActive(true);
            _cardView.sprite = image;
        }

        private void Awake()
        {
            _background = GetComponent<Image>();
            _cardView = this.GetNameComponent<Image>("CardView");
            _cardView.gameObject.SetActive(false);
        }
    }
}
