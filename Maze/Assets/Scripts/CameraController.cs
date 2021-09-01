using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] public float speed = 2.0f;

    private float x = 0.0f;
    private float y = 0.0f;

    void Update()
    {
        x += speed * Input.GetAxis("Mouse X");
        y -= speed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(y, x, 0.0f);

        transform.position = _target.transform.position + _offset;
        //transform.LookAt(_target);
    }
}
