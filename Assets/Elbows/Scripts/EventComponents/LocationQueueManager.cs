using System.Collections;
using System.Collections.Generic;
using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using Elbows.Data;
using Elbows.Enums;
using TMPro;
using UnityEngine;

namespace Elbows.LocationComponents
{
    /// <summary>
    /// The LocationQueueManager behaviour provides the main interaction point
    /// between the game systems and a given location's queues.
    /// </summary>
    public class LocationQueueManager
        : SingletonComponent<LocationQueueManager>
    {
        [SerializeField] [ReadOnlyField] private TextMeshProUGUI _locationName;
        [SerializeField] private LocationData _testEventData;
        private readonly Dictionary<QueueSpot, QueuePanel> _panels = new();
        
        protected override void Awake()
        {
            _locationName = this.GetNameComponent<TextMeshProUGUI>("LocationName");
            base.Awake();
            MapPanels();
            StartCoroutine(RunTestData());
        }

        private void MapPanels()
        {
            var panels = GetComponentsInChildren<QueuePanel>();
            foreach (var panel in panels)
                _panels.Add(panel.Spot, panel);
        }

        private IEnumerator RunTestData()
        {
            yield return null;//wait one frame
            _locationName.text = _testEventData.name;

            var panel = _panels[QueueSpot.Center];
            for (var i = 0; i < 5; i++)
            {
                panel.RegisterCard();
            }
        }
    }
}
