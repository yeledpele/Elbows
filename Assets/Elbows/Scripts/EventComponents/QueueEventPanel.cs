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
        [SerializeField] private EventPanelType _type;
        [SerializeField] private Image _background;
        [SerializeField] private Image _activeView;
        public EventPanelType Type => _type;

        public void SetBackground(Sprite image)
        {
            _background.sprite = image;
        }

        public void SetActiveView(Sprite image)
        {
            _activeView.gameObject.SetActive(true);
            _activeView.sprite = image;
        }

        private void Awake()
        {
            _activeView.gameObject.SetActive(false);
        }
    }
}
