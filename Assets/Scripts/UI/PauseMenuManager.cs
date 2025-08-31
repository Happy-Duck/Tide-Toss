using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;
    InputAction Pause;

    void Start()
    {
        Pause = InputSystem.actions.FindAction("Pause");
    }
    void Update()
    {
        if (Pause.WasReleasedThisFrame())
        {
            Time.timeScale = 0f;
            PauseCanvas.gameObject.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseCanvas.gameObject.SetActive(false);
    }
    public void QuitGame() // reloads the scene
    {
        SceneManager.LoadScene(0);
    }

}