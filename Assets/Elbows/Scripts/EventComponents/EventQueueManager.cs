using System.Collections.Generic;
using System.Linq;
using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
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
        
        protected override void Awake()
        {
            base.Awake();
            var panels = GetComponentsInChildren<QueueEventPanel>();
            _leftPanel = panels.First(entry => entry.Type == EventPanelType.Left);
            _centerPanel = panels.First(entry => entry.Type == EventPanelType.Center);
            _rightPanel = panels.First(entry => entry.Type == EventPanelType.Right);
        }
    }
}
