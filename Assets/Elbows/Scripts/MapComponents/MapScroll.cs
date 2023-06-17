using BinaryEyes.Common.Attributes;
using TMPro;
using UnityEngine;

namespace Elbows.MapComponents
{
    public class MapScroll
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private Canvas _canvas;
        [SerializeField] [ReadOnlyField] private RectTransform _canvasTransform;
        [SerializeField] [ReadOnlyField] private Vector2 _offset;
        [SerializeField] private RectTransform _target;

        private void Start()
        {
            _canvas = _target.GetComponentInParent<Canvas>();
            _canvasTransform = _canvas.GetComponent<RectTransform>();
        }

        private void Update()
        {
            _offset = (_canvasTransform.sizeDelta - _target.sizeDelta)*0.5f;
            _offset.x = Mathf.Abs(_offset.x);
            _offset.y = Mathf.Abs(_offset.y);
        }
    }
}