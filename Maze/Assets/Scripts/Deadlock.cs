using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadlock : MonoBehaviour
{
    [SerializeField] private int _counter = 0;
    [SerializeField] private GameManager GM;
    [SerializeField] private bool Visible;
    [SerializeField] private bool GoodTime = true;
    [SerializeField] private bool Checked = false;
    void OnBecameInvisible()
    {
        Visible = false;
        Checked = false;
    }
    void OnBecameVisible()
    {
        Visible = true;
    }
    private void Update()
    {
        if (!Physics.Linecast(Camera.main.transform.position, this.transform.position) && !Checked && Visible && GoodTime)
        {
            _counter++;
            Checked = true;
            StartCoroutine("Wait");
        }
        if (_counter >= 2)
        {
            Debug.Log("U lose!");
            GM.EndGame();
        }
    }
    IEnumerator Wait()
    {
        GoodTime = false;
        yield return new WaitForSeconds(2f);
        GoodTime = true;
    }
}
