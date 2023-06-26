using BinaryEyes.Common.Attributes;
using TMPro;
using UnityEngine;

namespace QueueUp.Components.UI
{
    public class PlayerLocationDisplay
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private TextMeshProUGUI _output;
        private void Awake() => _output = GetComponent<TextMeshProUGUI>();

        private void Start()
        {
            HandlePlayerMoved();
            QueueManager.Instance.PlayerMoved.AddListener(HandlePlayerMoved);
        }

        private void HandlePlayerMoved()
            => _output.text = QueueManager.Instance.PlayerPlace.ToString();
    }
}
