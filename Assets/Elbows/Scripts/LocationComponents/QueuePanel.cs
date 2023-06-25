using System.Collections.Generic;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;
using Elbows.Enums;
using UnityEngine;

namespace Elbows.LocationComponents
{
    /// <summary>
    /// The QueuePanel behaviour provides information and operations related
    /// to a single queue panel within a queue event.
    /// </summary>
    public class QueuePanel
        : MonoBehaviour
    {
        public const float OffsetStep = -1.0f;
        [SerializeField] [ReadOnlyField] private CardView _cardView;
        [SerializeField] [ReadOnlyField] private List<CardView> _views;
        [SerializeField] private QueueSpot _spot;
        public QueueSpot Spot => _spot;
        public CardView CardViewPrefab => _cardView;
        public CardView TopCard => _views[0];

        public void RegisterCard()
        {
            var topView = Instantiate(_cardView, transform);
            topView.SetName($"Card ({_views.Count + 1})");
            topView.gameObject.SetActive(true);
            _views.Insert(0, topView);

            var offsetRange = new Interval(3.0f, 1.0f);
            var cardsRange = new Interval(5.0f, 50.0f);
            var offset = -MapValue(_views.Count, cardsRange, offsetRange);
            for (var i = 0; i < _views.Count; i++)
            {
                var view = _views[i];
                view.enabled = i == 0;
                UpdateViewOffset(view.transform, i*offset);
            }
        }

        private static void UpdateViewOffset(Transform entry, float step)
        {
            var entryPosition = entry.localPosition;
            entryPosition.y = step;
            entry.localPosition = entryPosition;
        }

        private void Awake()
        {
            _cardView = GetComponentInChildren<CardView>();
            _cardView.gameObject.SetActive(false);
        }

        private static float MapValue(float value, Interval source, Interval target)
        {
            value = source.GetLocked(value);
            var normalized = (value - source.Min)/(source.Max - source.Min);
            return target.Min + normalized*(target.Max - target.Min);
        }
    }
}
