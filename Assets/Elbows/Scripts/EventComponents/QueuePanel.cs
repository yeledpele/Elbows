using Elbows.Enums;
using UnityEngine;

namespace Elbows.LocationComponents
{
    /// <summary>
    /// The QueuePanel behaviour provides information and operations related
    /// to a single queue panel within a queue event.
    /// </summary>
    public class QueuePanel
        : MonoBehaviour
    {
        [SerializeField] private QueueSpot _spot;
        public QueueSpot Spot => _spot;
    }
}
