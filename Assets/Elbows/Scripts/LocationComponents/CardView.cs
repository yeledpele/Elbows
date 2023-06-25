using BinaryEyes.Common.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Elbows.LocationComponents
{
    /// <summary>
    /// The CardView behaviour is a visual container of a single card
    /// found in a given queue panel.
    /// </summary>
    public class CardView
        : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent<CardView> Clicked;

        public void OnPointerClick(PointerEventData pointer)
        {
            this.LogMessage("Clicked");
            Clicked.Invoke(this);
        }
    }
}
