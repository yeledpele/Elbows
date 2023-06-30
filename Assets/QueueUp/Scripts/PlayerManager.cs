using BinaryEyes.Common;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using QueueUp.Data;
using UnityEngine;
using Event = BinaryEyes.Common.Data.Event;

namespace QueueUp
{
    public class PlayerManager
        : SingletonComponent<PlayerManager>
    {
        [SerializeField] [ReadOnlyField] private int _health;
        [SerializeField] [ReadOnlyField] private int _patience;
        [SerializeField] [ReadOnlyField] private int _assertiveness;
        [SerializeField] [ReadOnlyField] private int _strength;
        [SerializeField] [ReadOnlyField] private int _speed;
        [SerializeField] private PlayerStats _stats;
        [SerializeField] private Event _healthChanged;
        [SerializeField] private Event _patienceChanged;
        [SerializeField] private Event _assertivenessChanged;
        [SerializeField] private Event _strengthChanged;
        [SerializeField] private Event _speedChanged;
        public int Health => _health;
        public int Patience => _patience;
        public int Assertiveness => _assertiveness;
        public int Strength => _strength;
        public int Speed => _speed;
        public IEvent HealthChanged => _healthChanged;
        public IEvent PatienceChanged => _patienceChanged;
        public IEvent AssertivenessChanged => _assertivenessChanged;
        public IEvent StrengthChanged => _strengthChanged;
        public IEvent SpeedChanged => _speedChanged;

        public void ModifySpeed(int value)
        {
            _speed += value;
            _speedChanged.Invoke();
        }

        public void ModifyHealth(int value)
        {
            _health += value;
            _healthChanged.Invoke();
        }

        protected override void Awake()
        {
            _health = _stats.Health;
            _patience = _stats.Patience;
            _assertiveness = _stats.Assertiveness;
            _strength = _stats.Strength;
            _speed = _stats.Speed;
            base.Awake();
        }
    }
}
