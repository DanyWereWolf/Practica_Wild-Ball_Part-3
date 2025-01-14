using UnityEngine;
using WildBall.inputs;

public class BridgeTrigger : MonoBehaviour
{
    [SerializeField] public GameController gameController;
    [SerializeField] public Animator bridgeAnim;
    [SerializeField] public GameObject TrigZone;
    [SerializeField] public GameObject OpenKey;
    [SerializeField] public GameObject InfoKey;
    [SerializeField] public bool InTrigPl = false;

    private void Update()
    {
        if (InTrigPl == true)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Проверяем нажатие клавиши E
            {
                bridgeAnim.SetTrigger("LowerBridge"); // Запускаем опускание моста
                OpenKey.SetActive(false);
                InfoKey.SetActive(false);
                Destroy(TrigZone);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameController.hasKey) // Проверяем, что это игрок и у него есть ключ
        {
            OpenKey.SetActive(true);
            InTrigPl = true;
        }
        else
        {
            InfoKey.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OpenKey.SetActive(false);
        InfoKey.SetActive(false);
    }
}
