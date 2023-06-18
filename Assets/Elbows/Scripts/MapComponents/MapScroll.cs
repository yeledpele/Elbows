using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace Elbows.MapComponents
{
    public class MapScroll
        : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private float _speed = 150.0f;
        private Vector2 _mousePosition;
        private RectTransform _canvasTransform;
        private Canvas _canvas;

        private void Start()
        {
            _canvas = _target.GetComponentInParent<Canvas>();
            _canvasTransform = _canvas.GetComponent<RectTransform>();
        }

        private void Update()
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvasTransform,
                Input.mousePosition,
                null,
                out var mousePosition);

            var targetSize = Vector2.Scale(_target.sizeDelta, _target.localScale);
            var offset = (_canvasTransform.sizeDelta - targetSize)*0.5f;
            offset.x = Mathf.Abs(offset.x);
            offset.y = Mathf.Abs(offset.y);

            var targetPosition = _target.anchoredPosition;
            if (Input.GetMouseButton(0))
            {
                var delta = (mousePosition - _mousePosition)*(Time.deltaTime*_speed);
                targetPosition += new Vector2(delta.x, delta.y);
            }

            var horizontal = new Interval(-offset.x, +offset.x);
            var vertical = new Interval(-offset.y, +offset.y);
            targetPosition.x = horizontal.GetLocked(targetPosition.x);
            targetPosition.y = vertical.GetLocked(targetPosition.y);
            _target.anchoredPosition = targetPosition;
            _mousePosition = mousePosition;
        }
    }
}