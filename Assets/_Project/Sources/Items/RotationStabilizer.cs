using UnityEngine;

namespace Sources.Items
{
    public class RotationStabilizer : MonoBehaviour
    {
        private void LateUpdate() => 
            transform.rotation = Quaternion.identity;
    }
}