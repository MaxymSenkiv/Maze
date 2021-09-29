using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject _winGameUI;

    [SerializeField] private GameObject _loseGameUI;

    private void EndGame()
    {
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        EndGame();

        StartCoroutine("Lose");
    }

    IEnumerator Lose()
    {
        _loseGameUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinGame()
    {
        EndGame();

        StartCoroutine("Win");
    }

    IEnumerator Win()
    {
        _winGameUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Menu");
    }
}
