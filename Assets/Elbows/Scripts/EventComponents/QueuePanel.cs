using System.Collections.Generic;
using BinaryEyes.Common.Attributes;
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
            var view = Instantiate(_cardView, transform);
            view.SetName($"Card ({_views.Count + 1})");
            view.gameObject.SetActive(true);

            _views.Insert(0, view);

            UpdateViewOffsets();
        }

        private void UpdateViewOffsets()
        {
            for (var i = 0; i < _views.Count; i++)
            {
                var entry = _views[i].transform;
                var entryPosition = entry.localPosition;
                entryPosition.y = OffsetStep*i;
                entry.localPosition = entryPosition;
            }
        }

        private void Awake()
        {
            _cardView = GetComponentInChildren<CardView>();
            _cardView.gameObject.SetActive(false);
        }
    }
}
