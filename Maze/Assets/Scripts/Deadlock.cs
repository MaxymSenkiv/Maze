using System.Collections;
using UnityEngine;

public class Deadlock : MonoBehaviour
{
    [SerializeField] private int _counter = 0;

    [SerializeField] private GameManager _gameManager;

    [SerializeField] private bool _goodTime = true;

    [SerializeField] private Renderer _renderer;

    [SerializeField] private GameObject _deadlockUI;

    private void Start()
    {
        _renderer = this.GetComponent<Renderer>();
    }

    private void Update()
    {
        SeeDeadlock();

        GetLost();
    }

    private void SeeDeadlock()
    {
        if (!Physics.Linecast(Camera.main.transform.position, this.transform.position) && _renderer.isVisible && _goodTime)
        {
            _counter++;

            if (_counter < 2)
            {
                StartCoroutine("DeadlockUI");

                StartCoroutine("Wait");
            }
        }
    }

    IEnumerator DeadlockUI()
    {
        _deadlockUI.SetActive(true);

        yield return new WaitForSeconds(2f);

        _deadlockUI.SetActive(false);
    }

    private void GetLost()
    {
        if (_counter >= 2)
        {
            _gameManager.LoseGame();
        }
    }

    IEnumerator Wait()
    {
        _goodTime = false;

        yield return new WaitForSeconds(3f);

        _goodTime = true;
    }
}
