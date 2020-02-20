using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour,IDamageable
{
    // Start is called before the first frame update
    public int diamonds;


    
    private Rigidbody2D _rigid;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float _jumpForce = 5.0f;
    private bool resetJump = false;
    private bool _grounded=false;
    private PlayerAnimation _PlayerAnim;
    private SpriteRenderer _PlayerSprite;
    private SpriteRenderer _SwordArcSprite;

    

    public int Health { get; set;}
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _PlayerAnim = GetComponent<PlayerAnimation>();
        _PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        _SwordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }


    void Update()
    {
        
        Movement();

       


        if (CrossPlatformInputManager.GetButtonDown("A_button") && IsGrounded())
        {
            _PlayerAnim.Attack();

        }

    }

    void Movement()
    {

        float move = CrossPlatformInputManager.GetAxis("Horizontal"); 
            //Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();

        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }

        
        if (CrossPlatformInputManager.GetButtonDown("B_button") && IsGrounded() == true) //Input.GetKeyDown(KeyCode.Space) for pc ||
        {
            
            _PlayerAnim.Jump(true);
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
             
        }
         
        _rigid.velocity = new Vector2(move * Speed, _rigid.velocity.y);
        _PlayerAnim.Move(move);

    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hitInfo.collider != null)
        {
            if (resetJump == false)
            {
                _PlayerAnim.Jump(false);
                return true;
            }
                
        }
        return false;
    }
    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _PlayerSprite.flipX = false;
            _SwordArcSprite.flipX = false;
            _SwordArcSprite.flipY = false;

            Vector3 newPos =_SwordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _SwordArcSprite.transform.localPosition = newPos; 
            
        }
        else if (faceRight == false)
        {
            _PlayerSprite.flipX = true;
            _SwordArcSprite.flipX = true;
            _SwordArcSprite.flipY = true;

            Vector3 newPos = _SwordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _SwordArcSprite.transform.localPosition = newPos;


        }
    }


    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }


    public void Damage() 
    {
        if(Health <1)
        {
            return;
        }

        Debug.Log("Player :: damage() called");
        //Ui display
        Health--;
        UImanager.Instance.UpdateLives(Health);
        if (Health <1)
        {
            _PlayerAnim.Death();
        }
        // check for dead and play dead animation
        

    }

  

    public void AddGems(int amount)
    {
        diamonds += amount;
        UImanager.Instance.UpdateGemcount(diamonds); 

    }

   
       

  



}
