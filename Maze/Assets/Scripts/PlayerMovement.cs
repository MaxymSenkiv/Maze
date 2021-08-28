using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody _rigidbody;
    [SerializeField] private float _speed = 10f;
    private float X;
    private float Z;
    void Update()
    {
        InputCheck();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.AddForce(new Vector3(X, 0f, Z) * _speed);
    }

    private void InputCheck()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EndPoint")
        {
            _rigidbody.velocity = Vector3.zero;
            Debug.Log("U win!");
            EndGame();
        }    
    }
    private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
