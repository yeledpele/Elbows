using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using Elbows.Data;
using UnityEngine;

namespace Elbows.PlayerComponents
{
    /// <summary>
    /// The Player behaviour provides the centralized control over all player
    /// information and operations.
    /// </summary>
    public class Player
        : SingletonComponent<Player>
    {
        [SerializeField] [ReadOnlyField] private PlayerData _current;
        [SerializeField] private PlayerData _data;

        protected override void Awake()
        {
            _current = Instantiate(_data);
            base.Awake();
            this.LogMessage($"{_current.name} is awake");
        }
    }
}
