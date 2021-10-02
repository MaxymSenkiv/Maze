using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Maze3D");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
