using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject tidePod; // Should just be a visual version w/ collider and gravity, not throwable!!!
    [SerializeField] private GameObject mainMenuUI; // Parent of this 
    private bool IsMuted;
    [SerializeField] private GameObject MuteTexture;

    //public PauseMenuManager pauseMenuManager;


    void Start()
    {
        //pauseMenuManager = FindAnyObjectByType<PauseMenuManager>();
        StartCoroutine(SpawnUIPods());
        DontDestroyOnLoad(gameObject);

    }

    IEnumerator SpawnUIPods()
    {
        Instantiate(tidePod, new Vector3(Random.Range(80f, -80f), 82f, 90f), Quaternion.identity, gameObject.transform);



        yield return new WaitForSeconds(2f);


        StartCoroutine(SpawnUIPods());
        // Is this how you do loops......? yes?
    }

    public void StartGame() // Will be called by the start button !!!!!!!
    {
        foreach (BoxCollider pod in GetComponentsInChildren<BoxCollider>())
        {
            Destroy(pod.gameObject); // Destroy any pods that were still falling because they would just stay otherwise
        }

        mainMenuUI.gameObject.SetActive(false);

        //if (pauseMenuManager != null) pauseMenuManager.isPaused = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);


    }

    public void QuitGame() // Quit Buttobn //nice
    {
        Application.Quit();
    }

    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void MuteVolume()
    {
        if (IsMuted)
        {
            // Unmute the game... IDK how tho lol
            AudioListener.volume = 1f;
            IsMuted = false;
            MuteTexture.SetActive(false);
        }
        else
        {
            // Mute the game
            AudioListener.volume = 0f;
            IsMuted = true;
            MuteTexture.SetActive(true);
        }
    }
}
