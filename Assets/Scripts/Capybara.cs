using UnityEngine;

public class Capybara : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _force = 4.0f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Vector3 _lastMovementDirection;

    public static Capybara Instance { get; private set; }

    private void Start () 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void ResetLocation ()
    {
        transform.position = Vector3.zero;
    }

    private void Update ()
    {
        Vector3 newDir = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            newDir += Vector3.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            newDir += Vector3.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            newDir += Vector3.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            newDir += Vector3.right;
        }

        transform.Translate(newDir * _speed * Time.deltaTime);

        if(newDir != Vector3.zero) {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Rigidbody2D fruit = collision.rigidbody;
        if(fruit != null)
        {
            fruit.AddForce(_lastMovementDirection * _force, ForceMode2D.Impulse);
        }
    }
}
