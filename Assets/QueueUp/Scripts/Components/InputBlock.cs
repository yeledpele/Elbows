using BinaryEyes.Common;
using UnityEngine;

namespace QueueUp.Components
{
    public class InputBlock
        : SingletonComponent<InputBlock>
    {
        [SerializeField] private RectTransform _panel;

        public void Activate()
            => _panel.gameObject.SetActive(true);

        public void Deactivate()
            => _panel.gameObject.SetActive(false);

        protected override void Awake()
        {
            base.Awake();
            Deactivate();
        }
    }
}
