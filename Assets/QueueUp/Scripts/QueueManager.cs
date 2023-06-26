using System.Collections.Generic;
using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using BinaryEyes.Common.Utilities;
using QueueUp.Components.UI;
using QueueUp.Data;
using QueueUp.Data.CardsData;
using UnityEngine;
using Event = BinaryEyes.Common.Data.Event;

namespace QueueUp
{
    public class QueueManager
        : SingletonComponent<QueueManager>
    {
        [SerializeField] [ReadOnlyField] private QueueRow _rowPrefab;
        [SerializeField] [ReadOnlyField] private int _playerPlace;
        [SerializeField] [ReadOnlyField] private List<QueueRow> _queue;
        [SerializeField] private BlankCardData _blankCardData;
        [SerializeField] private Event _playerMoved;
        [SerializeField] private Range _queueRowsCount;
        public int QueueLength => _queue.Count;
        public int PlayerPlace => _playerPlace;
        public IEvent PlayerMoved => _playerMoved;
        public IReadOnlyList<QueueRow> Queue => _queue;

        public RectTransform Prefab;

        private void Start()
        {
            var totalRows = _queueRowsCount.GetRandom();
            var offset = MapValue.Perform(totalRows, new Interval(5.0f, 50.0f), new Interval(2.5f, 1.0f));
            var tintCheck = totalRows%2 == 0 ? 0 : 1;
            for (var i = 0; i < totalRows; i++)
            {
                var tint = (i%2 == tintCheck) ? 0.7f : 1.0f;
                var color = new Color(tint, tint, tint, 1.0f);

                var queueIndex = i + 1;
                var row = Instantiate(_rowPrefab, _rowPrefab.transform.parent);
                row.Initialize(queueIndex);
                row.Left.Initialize(_blankCardData);
                row.Center.Initialize(_blankCardData);
                row.Right.Initialize(_blankCardData);
                row.gameObject.SetActive(true);
                row.transform.localPosition += new Vector3(0.0f, offset*i, 0.0f);
                row.SetTint(color);
                _queue.Add(row);
            }
        }

        public void MovePlayer(int direction)
        {

        }

        protected override void Awake()
        {
            base.Awake();
            _rowPrefab = GetComponentInChildren<QueueRow>(true);
            _rowPrefab.gameObject.SetActive(false);
        }
    }
}