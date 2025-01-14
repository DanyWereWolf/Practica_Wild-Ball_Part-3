using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] public GameObject pauseBtn;
    [SerializeField] public GameObject pausePannel;
    public void OnPauseClick()
    {
        Time.timeScale = 0f;
        pauseBtn.SetActive(false);
        pausePannel.SetActive(true);
    }
    public void OffPauseClick()
    {
        Time.timeScale = 1f;
        pauseBtn.SetActive(true);
        pausePannel.SetActive(false);
    }
}
