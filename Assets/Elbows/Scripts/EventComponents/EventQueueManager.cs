using System;
using System.Collections;
using System.Collections.Generic;
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
        private readonly Dictionary<EventPanelType, QueueEventPanel> _panels = new();
        [SerializeField] private QueueEventData _testEventData;
        
        protected override void Awake()
        {
            base.Awake();
            MapPanels();
            StartCoroutine(RunTestData());
        }

        private void MapPanels()
        {
            var panels = GetComponentsInChildren<QueueEventPanel>();
            foreach (var panel in panels)
                _panels.Add(panel.Type, panel);
        }

        private IEnumerator RunTestData()
        {
            yield return null;//wait one frame
            var panelTypes = Enum.GetValues(typeof(EventPanelType)).Cast<EventPanelType>();
            foreach (var panelType in panelTypes)
                _panels[panelType].SetBackground(_testEventData.GetBackground(panelType));
        }
    }
}
