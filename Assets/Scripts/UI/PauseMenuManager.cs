using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;
    InputAction Pause;
    public bool isPaused = false;

    void Start()
    {
        Pause = InputSystem.actions.FindAction("Pause");

    }
    void Update()
    {
        if (Pause.WasReleasedThisFrame() && !isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            PauseCanvas.gameObject.SetActive(true);
        } else if (Pause.WasReleasedThisFrame() && isPaused) {
            Time.timeScale = 1f;
            PauseCanvas.gameObject.SetActive(false);
            isPaused = false;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseCanvas.gameObject.SetActive(false);
        isPaused = false;
    }
    public void QuitGame() // reloads the scene
    {
        Time.timeScale = 1f;
        isPaused = false;
        PauseCanvas.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

}