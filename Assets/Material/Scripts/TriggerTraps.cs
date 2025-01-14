using UnityEngine;

public class TriggerTraps : MonoBehaviour
{
    [SerializeField] public GameObject PauseBtn;
    [SerializeField] public ParticleSystem particleSystem; 
    [SerializeField] public GameObject losPannel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            particleSystem.Play();
            PauseBtn.SetActive(false);
            losPannel.SetActive(true);
            Time.timeScale = 0f;
        }

    }
}

