using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using QueueUp.Data;
using UnityEngine;
using Event = BinaryEyes.Common.Data.Event;

namespace QueueUp
{
    public class QueueManager
        : SingletonComponent<QueueManager>
    {
        [SerializeField] [ReadOnlyField] private int _playerPlace;
        [SerializeField] [ReadOnlyField] private QueueRow[] _queue;
        [SerializeField] private Event _playerMoved;
        [SerializeField] private Range _queueRowsCount;
        public int QueueLength => _queue.Length;
        public int PlayerPlace => _playerPlace;
        public IEvent PlayerMoved => _playerMoved;

        private void Start()
        {

        }

        public void MovePlayer(int direction)
        {

        }
    }
}