using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody _rigidbody;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameManager GM;
    [SerializeField] private Transform Camera;
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
        Vector3 TargetDirection = new Vector3(X, 0f, Z);
        TargetDirection = Camera.forward * Z + Camera.right * X;
        TargetDirection.y = 0.0f;
        _rigidbody.velocity = TargetDirection * _speed * Time.fixedDeltaTime;
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
            GM.EndGame();
        }    
    }
}
