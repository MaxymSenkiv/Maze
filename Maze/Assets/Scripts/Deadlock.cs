using System.Collections;
using UnityEngine;

public class Deadlock : MonoBehaviour
{
    [SerializeField] private int _counter = 0;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private bool _goodTime = true;
    [SerializeField] private Renderer _renderer;

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
            StartCoroutine("Wait");
        }
    }

    private void GetLost()
    {
        if (_counter >= 2)
        {
            Debug.Log("U lose!");
            _gameManager.EndGame();
        }
    }

    IEnumerator Wait()
    {
        _goodTime = false;
        yield return new WaitForSeconds(2f);
        _goodTime = true;
    }
}
