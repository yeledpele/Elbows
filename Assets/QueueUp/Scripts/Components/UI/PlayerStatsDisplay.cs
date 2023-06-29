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

        private void Start()
        {
            _healthDisplay.text = PlayerManager.Instance.Health.ToString();
            _patienceDisplay.text = PlayerManager.Instance.Patience.ToString();
            _assertivenessDisplay.text = PlayerManager.Instance.Assertiveness.ToString();
            PlayerManager.Instance.HealthChanged.AddListener(() =>
                _healthDisplay.text = PlayerManager.Instance.Health.ToString());

            PlayerManager.Instance.PatienceChanged.AddListener(() =>
                _patienceDisplay.text = PlayerManager.Instance.Patience.ToString());

            PlayerManager.Instance.AssertivenessChanged.AddListener(() =>
                _assertivenessDisplay.text = PlayerManager.Instance.Assertiveness.ToString());
        }
    }
}
