using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody _rigidbody;

    [SerializeField] private GameManager _gameManager;

    [SerializeField] private Transform _camera;

    private float X;
    private float Z;

    [SerializeField] private float _speed = 10f;

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

        TargetDirection = _camera.forward * Z + _camera.right * X;
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
            _gameManager.EndGame();
        }    
    }
}
