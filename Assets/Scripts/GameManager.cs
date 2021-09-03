using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject Controls;
    [SerializeField]
    private Animation anim;
    private bool Paused;
    private static GameObject canvas;
    private static GameObject gameover;
    private static GameObject finish;
    public static bool startGame;
    private void Awake()
    {
        startGame = false;
        canvas = GameObject.Find("Canvas");
        gameover = canvas.transform.Find("GameOver").gameObject;
        finish = canvas.transform.Find("Finish").gameObject;
    }
    private void Update()
    {
        if (Controls.activeInHierarchy)
        {
            if (Input.touchCount > 0)
            {
                Controls.SetActive(false);
                startGame = true;
                anim.Play();
            }
        }
    }
    public void PauseUnPause()
    {
        if (!finish.activeInHierarchy && !gameover.activeInHierarchy && !Collision.finish)
        {
            if (Paused)
            {
                settings.SetActive(false);
                Time.timeScale = 1.0f;
                Paused = false;
            }
            else
            {
                Paused = true;
                settings.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
    public static void Finish()
    {
        Time.timeScale = 0.0f;
        finish.SetActive(true);
    }
    public static void GameOver()
    {
        Time.timeScale = 0.0f;
        gameover.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
