using BinaryEyes.Common.Attributes;
using Elbows.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Elbows.EventComponents
{
    /// <summary>
    /// The CardView behaviour is a visual container of a single (event) card
    /// found in a given queue panel.
    /// </summary>
    public class CardView
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private QueueCardData _card;
        [SerializeField] private Image _display;

        public CardView SetData(QueueCardData data)
        {
            _card = Instantiate(data);
            _display.sprite = _card.BackImage;

            name = data.name;
            gameObject.SetActive(true);
            return this;
        }
    }
}
