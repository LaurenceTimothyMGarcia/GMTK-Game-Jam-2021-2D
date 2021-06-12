using UnityEngine;

public class Character2D : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;
    public Animator anim;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
   private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            //FindObjectOfType<AudioManager>().Play("PlayerWalking");
        }

        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            anim.SetBool("isJumping", true);
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJumping", false);
        }
        else
        {
            //anim.SetBool("isJumping", false);
        }
        anim.SetFloat("speed", Input.GetAxis("Horizontal"));
    }
}
