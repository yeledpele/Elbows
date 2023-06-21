using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using Elbows.Data;
using Elbows.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Elbows.EventComponents
{
    /// <summary>
    /// The EventQueueManager behaviour provides the main interaction point
    /// between the game systems and the queue events.
    /// </summary>
    public class EventQueueManager
        : SingletonComponent<EventQueueManager>
    {
        [SerializeField] [ReadOnlyField] private TextMeshProUGUI _eventTitle;
        [SerializeField] private Image _fullBackground;
        [SerializeField] private LocationData _testEventData;
        private readonly Dictionary<EventPanelType, QueueEventPanel> _panels = new();
        
        protected override void Awake()
        {
            _eventTitle = this.GetNameComponent<TextMeshProUGUI>("EventTitle");
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
            _eventTitle.text = _testEventData.name;
        }
    }
}
