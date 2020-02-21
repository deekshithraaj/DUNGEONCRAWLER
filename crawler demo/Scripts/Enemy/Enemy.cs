using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
   
    public GameObject DiamondPrefab; 
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator _Eanim;
    protected SpriteRenderer _Esprite;

    protected bool isHit = false;
    protected Player player;

    protected bool isDead = false;

    public virtual void Init()
    {
        _Eanim = GetComponentInChildren<Animator>();
        _Esprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (_Eanim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && _Eanim.GetBool("InCombat") == false )
        {
            return;
        }


        if(isDead==false)
            Movement();


    }


    public virtual void Movement()
    {
        // Debug.Log("Base attack called");
        if (currentTarget == pointA.position)
        {
            _Esprite.flipX = true;
        }
        else
        {
            _Esprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            _Eanim.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            _Eanim.SetTrigger("Idle");

        }

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if (distance > 2.0f)
        {
            isHit = false;
            _Eanim.SetBool("InCombat", false);
        }
       

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && _Eanim.GetBool("InCombat") == true)
        {
            _Esprite.flipX = false;
        }
        else if (direction.x < 0 && _Eanim.GetBool("InCombat") == true)
        {
            _Esprite.flipX = true;

        }
    }
}
