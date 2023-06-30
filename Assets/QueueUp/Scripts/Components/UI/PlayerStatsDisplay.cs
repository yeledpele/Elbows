using TMPro;
using UnityEngine;

namespace QueueUp.Components.UI
{
    public class PlayerStatsDisplay
        : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthDisplay;
        [SerializeField] private TextMeshProUGUI _patienceDisplay;
        [SerializeField] private TextMeshProUGUI _assertivenessDisplay;
        [SerializeField] private TextMeshProUGUI _strengthDisplay;
        [SerializeField] private TextMeshProUGUI _speedDisplay;

        private void Start()
        {
            _healthDisplay.text = PlayerManager.Instance.Health.ToString();
            _patienceDisplay.text = PlayerManager.Instance.Patience.ToString();
            _assertivenessDisplay.text = PlayerManager.Instance.Assertiveness.ToString();
            _strengthDisplay.text = PlayerManager.Instance.Strength.ToString();
            _speedDisplay.text = PlayerManager.Instance.Speed.ToString();

            PlayerManager.Instance.HealthChanged.AddListener(() =>
                _healthDisplay.text = PlayerManager.Instance.Health.ToString());

            PlayerManager.Instance.PatienceChanged.AddListener(() =>
                _patienceDisplay.text = PlayerManager.Instance.Patience.ToString());

            PlayerManager.Instance.AssertivenessChanged.AddListener(() =>
                _assertivenessDisplay.text = PlayerManager.Instance.Assertiveness.ToString());

            PlayerManager.Instance.StrengthChanged.AddListener(() =>
                _strengthDisplay.text = PlayerManager.Instance.Strength.ToString());

            PlayerManager.Instance.SpeedChanged.AddListener(() =>
                _speedDisplay.text = PlayerManager.Instance.Speed.ToString());
        }
    }
}
