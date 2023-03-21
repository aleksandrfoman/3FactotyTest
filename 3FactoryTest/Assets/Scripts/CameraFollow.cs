using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float speed;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position+offset, speed * Time.deltaTime);
    }
}
