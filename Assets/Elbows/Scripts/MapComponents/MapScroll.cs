using UnityEngine;

namespace Elbows.MapComponents
{
    public class MapScroll
        : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        private RectTransform _canvasTransform;
        private Canvas _canvas;
        private Vector2 _offset;

        private void Start()
        {
            _canvas = _target.GetComponentInParent<Canvas>();
            _canvasTransform = _canvas.GetComponent<RectTransform>();
        }

        private void Update()
        {
            var targetSize = Vector2.Scale(_target.sizeDelta, _target.localScale);
            _offset = (_canvasTransform.sizeDelta - targetSize)*0.5f;
            _offset.x = Mathf.Abs(_offset.x);
            _offset.y = Mathf.Abs(_offset.y);
        }
    }
}