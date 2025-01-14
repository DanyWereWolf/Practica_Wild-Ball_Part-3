using UnityEngine;

public class CollisionTriggerButton : MonoBehaviour
{
    [SerializeField] public GameObject MagicBridge;
    [SerializeField] public Animator PressBtnAnim;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PressBtnAnim.SetTrigger("PressButton");
            MagicBridge.SetActive(true);
        }
    }
}
