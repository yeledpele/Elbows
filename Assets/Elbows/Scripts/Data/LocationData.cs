using System;
using System.Collections.Generic;
using Elbows.Enums;
using UnityEngine;

namespace Elbows.Data
{
    /// <summary>
    /// The LocationData provides information regarding a particular game event
    /// in a location with a queue.
    /// </summary>
    [CreateAssetMenu(menuName = "Elbows/Location Data")]
    public class LocationData
        : ScriptableObject
    {
        [SerializeField] private Sprite _fullBackground;
        [SerializeField] private Sprite _leftBackground;
        [SerializeField] private Sprite _centerBackground;
        [SerializeField] private Sprite _rightBackground;
        [SerializeField] private QueueCardData[] _mainCards;
        public IReadOnlyList<QueueCardData> MainCards => _mainCards;
        public Sprite FullBackground => _fullBackground;

        public Sprite GetBackground(EventPanelType type)
        {
            return type switch
            {
                EventPanelType.Left => _leftBackground,
                EventPanelType.Center => _centerBackground,
                EventPanelType.Right => _rightBackground,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
