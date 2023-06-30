using System.Collections;
using TMPro;
using UnityEngine;

namespace QueueUp.Components.UI
{
    public class MessagePanel
        : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textDisplay;
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private bool _isVisible;
        public bool IsVisible => _isVisible;
        public void Show(string text) => StartShow(text);
        public void Hide() => StartHide();

        public Coroutine StartHide()
        {
            if (!_isVisible)
                return null;

            _group.interactable = false;
            _group.blocksRaycasts = false;
            return StartCoroutine(PerformHide());
        }

        public Coroutine StartShow(string text)
        {
            if (_isVisible)
                return null;

            gameObject.SetActive(true);
            _textDisplay.text = text;
            _group.interactable = true;
            _group.blocksRaycasts = true;
            _group.alpha = 0.0f;
            return StartCoroutine(PerformShow());
        }

        private IEnumerator PerformHide()
        {
            var tween = LeanTween.alphaCanvas(_group, 0.0f, 0.35f);
            yield return new WaitWhile(() => LeanTween.isTweening(tween.uniqueId));

            _isVisible = false;
            gameObject.SetActive(false);
        }

        private IEnumerator PerformShow()
        {
            var tween = LeanTween.alphaCanvas(_group, 1.0f, 0.35f);
            yield return new WaitWhile(() => LeanTween.isTweening(tween.uniqueId));
            _isVisible = true;
        }
    }
}
