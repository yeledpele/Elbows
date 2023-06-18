using System.Collections.Generic;
using BinaryEyes.Common;
using Elbows.Enums;

namespace Elbows.EventComponents
{
    /// <summary>
    /// The EventQueueManager behaviour provides the main interaction point
    /// between the game systems and the queue events.
    /// </summary>
    public class EventQueueManager
        : SingletonComponent<EventQueueManager>
    {
        private readonly Dictionary<EventPanelType, QueueEventPanel> _panels = new();
        public IReadOnlyDictionary<EventPanelType, QueueEventPanel> Panels => _panels;

        protected override void Awake()
        {
            base.Awake();
            var panels = GetComponentsInChildren<QueueEventPanel>();
            foreach (var panel in panels)
                _panels.Add(panel.Type, panel);
        }
    }
}
