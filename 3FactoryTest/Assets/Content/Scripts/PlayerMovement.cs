using UnityEngine;

namespace Content.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] 
        private FloatingJoystick floatingJoystick;
        [SerializeField]
        private float speed,rotateSpeed;
        private float horizontalDir, veritcalDir;
        [SerializeField] 
        private Transform rotateTransform;
        private Rigidbody rigidbody;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            MyInput();
            Rotate();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 velocity = new Vector3(horizontalDir, 0f, veritcalDir) * speed;
            velocity.y = rigidbody.velocity.y;
            Vector3 worldVelocity = transform.TransformVector(velocity);
            rigidbody.velocity = worldVelocity;
        }

        private void Rotate()
        {
            var dir = new Vector2(horizontalDir, veritcalDir);
            var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));

            rotateTransform.rotation = Quaternion.Lerp(rotateTransform.rotation, nextRot, rotateSpeed * Time.deltaTime);
        }

        private void MyInput()
        {
            horizontalDir = floatingJoystick.Horizontal;
            veritcalDir = floatingJoystick.Vertical;
            if (horizontalDir == 0  || veritcalDir == 0)
            {
                horizontalDir = Input.GetAxis("Horizontal");
                veritcalDir = Input.GetAxis("Vertical");
            }

        }
    }
}
