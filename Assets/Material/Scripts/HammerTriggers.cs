using UnityEngine;

public class HammerTriggers : MonoBehaviour
{
    [SerializeField] public float impactForce = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (otherRigidbody != null)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                // Наносим удар
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                otherRigidbody.AddForce(direction * impactForce, ForceMode.Impulse);
            }
        }
    }
}
