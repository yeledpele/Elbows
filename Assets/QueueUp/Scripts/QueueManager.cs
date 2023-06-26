using System.Collections.Generic;
using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;
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

        private void Start()
        {
            var totalRows = _queueRowsCount.GetRandom();
            var start = MapValue.Perform(totalRows, new Interval(0.0f, 50.0f), new Interval(0.0f, 50.0f));
            var offset = MapValue.Perform(totalRows, new Interval(5.0f, 50.0f), new Interval(2.5f, 1.0f));
            var tintCheck = totalRows%2 == 0 ? 0 : 1;
            for (var i = 0; i < totalRows; i++)
            {
                var rowCardsData = GenerateRowCardsData(i);
                var tint = i%2 == tintCheck ? 0.7f : 1.0f;
                var color = new Color(tint, tint, tint, 1.0f);

                var row = Instantiate(_rowPrefab, _rowPrefab.transform.parent);
                row.Initialize(i, rowCardsData);
                row.gameObject.SetActive(true);
                row.transform.localPosition += new Vector3(0.0f, offset*i - start, 0.0f);
                row.AdvancePlayerRequested.AddListener(AdvancePlayer);
                row.SetTint(color);
                _queue.Add(row);
            }

            var playerRow = Instantiate(_rowPrefab, _rowPrefab.transform.parent)
                .SetName("Player")
                .SetActive(false);
            _queue.Add(playerRow);

            _playerPlace = totalRows;
            _playerMoved.Invoke();
        }

        private void AdvancePlayer()
        {
            var playerRowIndex = _playerPlace;
            var playerRow = _queue[playerRowIndex];
            var currentRow = _queue[playerRowIndex - 1];
            currentRow.SetActive(false);

            _queue[playerRowIndex] = currentRow;
            _queue[playerRowIndex - 1] = playerRow;
            _queue[playerRowIndex - 2].SetTint(Color.white);

            var playerSiblingIndex = playerRow.transform.GetSiblingIndex();
            playerRow.transform.SetSiblingIndex(playerSiblingIndex - 1);
            _playerPlace = playerRowIndex - 1;
            _playerMoved.Invoke();
        }

        private CardData[] GenerateRowCardsData(int index)
        {
            return new[]
            {
                index == 0 ? null : Instantiate(_blankCardData),
                Instantiate(_blankCardData),
                index == 0 ? null : Instantiate(_blankCardData),
            };
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