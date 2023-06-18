﻿using System;
using Elbows.Enums;
using UnityEngine;

namespace Elbows.Data
{
    /// <summary>
    /// The QueueEventData provides information regarding a particular game event
    /// in a location with a queue.
    /// </summary>
    [CreateAssetMenu(menuName = "Elbows/Queue Event Data")]
    public class QueueEventData
        : ScriptableObject
    {
        [SerializeField] private Sprite _leftBackground;
        [SerializeField] private Sprite _centerBackground;
        [SerializeField] private Sprite _rightBackground;

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
