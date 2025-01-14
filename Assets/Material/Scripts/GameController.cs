using UnityEngine;
using UnityEngine.Events;

namespace WildBall.inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class GameController : MonoBehaviour
    {

        [SerializeField, Range(0, 10)] private float speed = 2f;
        [SerializeField] private Rigidbody playerRigidbody;
        [SerializeField] private Vector3 movement;
        [SerializeField] public float impactForce = 5f;
        [SerializeField] public bool hasKey = false; 

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            movement = new Vector3(-horizontal, 0, -vertical).normalized;
        }
        private void FixedUpdate()
        {
            MoveCaracter();
        }
        private void MoveCaracter()
        {
            playerRigidbody.AddForce(movement * speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (collision.gameObject.CompareTag("Barrel"))
            {
                
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                otherRigidbody.AddForce(direction * impactForce, ForceMode.Impulse);
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Key")) 
            {
                hasKey = true; 
                Destroy(other.gameObject); 
            }
        }


#if UNITY_EDITOR
        [ContextMenu("Reset Values")]
        public void ResetValues()
        {
            speed = 2f;
        }
#endif
    }
}