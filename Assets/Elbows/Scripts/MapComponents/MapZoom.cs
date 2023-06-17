using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace Elbows.MapComponents
{
    /// <summary>
    /// The MapZoom behaviour allows the set rect-transform target to be zoomed
    /// by the mouse.
    /// </summary>
    public class MapZoom 
        : MonoBehaviour
    {
        [SerializeField] private float _current = 1.0f;
        [SerializeField] private Interval _range = new(1.0f, 3.0f);
        [SerializeField] private float _zoomSpeed = 4.0f;
        [SerializeField] private RectTransform _target;

        private void Update()
        {
            var scroll = Input.mouseScrollDelta.y*Time.deltaTime*_zoomSpeed;
            var next = _current + scroll;
            _current = _range.GetLocked(next);

            _target.localScale = Vector3.one*_current;
        }
    }
}
