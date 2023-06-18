using System.Collections;
using System.Linq;
using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
using Elbows.Data;
using Elbows.Enums;
using UnityEngine;

namespace Elbows.EventComponents
{
    /// <summary>
    /// The EventQueueManager behaviour provides the main interaction point
    /// between the game systems and the queue events.
    /// </summary>
    public class EventQueueManager
        : SingletonComponent<EventQueueManager>
    {
        [SerializeField] [ReadOnlyField] private QueueEventPanel _leftPanel;
        [SerializeField] [ReadOnlyField] private QueueEventPanel _centerPanel;
        [SerializeField] [ReadOnlyField] private QueueEventPanel _rightPanel;
        [SerializeField] private QueueEventData _testEventData;
        
        protected override void Awake()
        {
            base.Awake();
            var panels = GetComponentsInChildren<QueueEventPanel>();
            _leftPanel = panels.First(entry => entry.Type == EventPanelType.Left);
            _centerPanel = panels.First(entry => entry.Type == EventPanelType.Center);
            _rightPanel = panels.First(entry => entry.Type == EventPanelType.Right);
            StartCoroutine(RunTestData());
        }

        private IEnumerator RunTestData()
        {
            yield return null;
            
        }
    }
}
