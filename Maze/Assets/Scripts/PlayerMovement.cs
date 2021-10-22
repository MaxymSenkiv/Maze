using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private GameManager _gameManager;

    [SerializeField] private Transform _camera;

    private float X;
    private float Z;

    public bool CanMove = true;

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
        if (CanMove)
        {
            Vector3 targetDirection = new Vector3(X, 0f, Z);

            targetDirection = _camera.forward * Z + _camera.right * X;
            targetDirection.y = 0.0f;
            _rigidbody.velocity = targetDirection * _speed * Time.fixedDeltaTime;
        }
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
            _gameManager.WinGame();
        }    
    }
}
