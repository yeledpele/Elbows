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
        public EventPanelType Type => _type;

        public void SetBackground(Sprite image)
        {
            _background.sprite = image;
        }
    }
}
