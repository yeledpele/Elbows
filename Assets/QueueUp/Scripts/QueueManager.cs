using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;
using BinaryEyes.Common.Utilities;
using QueueUp.Components;
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
        [Header("State")]
        [SerializeField] [ReadOnlyField] private QueueRow _rowPrefab;
        [SerializeField] [ReadOnlyField] private int _playerPlace;
        [SerializeField] [ReadOnlyField] private List<QueueRow> _queue;

        [Header("Events")]
        [SerializeField] private Event _playerMoved;
        [SerializeField] private Event _playerReachedQueueEnd;

        [Header("Cards")]
        [SerializeField] private BlankCardData _blankCardData;
        [SerializeField] private CharacterCardData[] _npcCardsData;
        [SerializeField] private Range _queueRowsCount;

        public int QueueLength => _queue.Count;
        public int PlayerPlace => _playerPlace;
        public IReadOnlyList<QueueRow> Queue => _queue;
        public IEvent PlayerMoved => _playerMoved;
        public IEvent PlayerReachedQueueEnd => _playerReachedQueueEnd;

        private void Start()
        {
            var npcCardsData = _npcCardsData.ToList();
            var totalRows = _queueRowsCount.GetRandom();
            var start = MapValue.Perform(totalRows, new Interval(0.0f, 50.0f), new Interval(0.0f, 50.0f));
            var offset = MapValue.Perform(totalRows, new Interval(5.0f, 50.0f), new Interval(2.5f, 1.0f));
            var tintCheck = totalRows%2 == 0 ? 0 : 1;
            for (var i = 0; i < totalRows; i++)
            {
                if (npcCardsData.Count == 0)
                    npcCardsData = _npcCardsData.ToList();

                var rowCardsData = GenerateRowCardsData(i, npcCardsData);
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
            StartCoroutine(PerformPlayerMovementForward());
        }

        private IEnumerator PerformPlayerMovementForward()
        {
            InputBlock.Instance.Activate();
            var playerRowIndex = _playerPlace;
            var playerRow = _queue[playerRowIndex];
            var currentRow = _queue[playerRowIndex - 1];
            var group = currentRow.GetComponent<CanvasGroup>();
            group.interactable = false;
            group.blocksRaycasts = false;

            const float tweenTime = 0.5f;
            var currentRowY = group.transform.localPosition.y;
            var moveTween = LeanTween.moveLocalY(group.gameObject, currentRowY + 150.0f, tweenTime).setEaseOutSine();
            var fadeTween = LeanTween.alphaCanvas(group, 0.0f, tweenTime).setEaseOutSine();
            yield return new WaitForSeconds(tweenTime*0.15f);

            InputBlock.Instance.Deactivate();
            yield return new WaitWhile(() => LeanTween.isTweening(fadeTween.uniqueId));

            currentRow.SetActive(false);
            currentRow.transform.SetLocalPositionY(currentRowY);

            _playerPlace = playerRowIndex - 1;
            _queue[playerRowIndex] = currentRow;
            _queue[playerRowIndex - 1] = playerRow;
            if (_playerPlace != 0)
                _queue[playerRowIndex - 2].SetTint(Color.white);

            var playerSiblingIndex = playerRow.transform.GetSiblingIndex();
            playerRow.transform.SetSiblingIndex(playerSiblingIndex - 1);
            _playerMoved.Invoke();

            if (_playerPlace == 0)
                _playerReachedQueueEnd.Invoke();
        }

        private CardData[] GenerateRowCardsData(int index, List<CharacterCardData> npcCardsData)
        {
            CardData leftCard = index == 0 ? null : Instantiate(_blankCardData);
            CardData centerCard = npcCardsData.PopRandom();
            CardData rightCard = index == 0 ? null : Instantiate(_blankCardData);
            return new[] { leftCard, centerCard, rightCard };
        }

        protected override void Awake()
        {
            base.Awake();
            _rowPrefab = GetComponentInChildren<QueueRow>(true);
            _rowPrefab.gameObject.SetActive(false);
        }
    }
}