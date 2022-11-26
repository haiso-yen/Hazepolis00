using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : MonoBehaviour
{

    //Singleton Mode
    public static Dan instance;

    private SkeletonAnimation skeletonAnimation;
    private string previousState, currentState;
    private Rigidbody2D rigid2D;
    private CircleCollider2D collider2D;
    private CapsuleCollider2D capcollider2D;
    private float jumpForce = 1000.0f;
    private float climbingSpeed = 3f;
    private float walkForce = 20.0f;
    private float maxWalkForce = 4.0f;
    private bool isJumping = false;
    public bool isClimbling = false;
    public int horizontalKey;
    public int verticalKey;

    bool inputEnabled = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<CircleCollider2D>();
        capcollider2D = GetComponent<CapsuleCollider2D>();
        skeletonAnimation.state.SetAnimation(0, "idle", false);
        currentState = "idle";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box")
        {
            isJumping = false;
            skeletonAnimation.state.SetAnimation(0, currentState, true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inputEnabled == true)
        {
            Move();
        }
    }

    private void Move()
    {
        horizontalKey = 0;
        verticalKey = 0;

        //climb
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, 20, 1 << LayerMask.NameToLayer("ladder"));
        if (hitInfo.collider != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                verticalKey = 1;
                isClimbling = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                verticalKey = -1;
                isClimbling = true;
            }
            else
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    isClimbling = false;
                }
            }
        }
        else
        {
            isClimbling = false;
        }
        if (isClimbling == true && hitInfo.collider != null)
        {
            currentState = verticalKey == 0 ? "ladderidle" : "ladder";
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, verticalKey * climbingSpeed);
            rigid2D.gravityScale = 0;
            Physics2D.IgnoreLayerCollision(9, 10, true);
        }
        else
        {
            rigid2D.gravityScale = 2;
            Physics2D.IgnoreLayerCollision(9, 10, false);
        }
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
            rigid2D.AddForce(transform.up * jumpForce);
            skeletonAnimation.state.SetAnimation(0, "jump", false);
        }
        //basic movement
        if (Input.GetKey(KeyCode.A))
        {
            horizontalKey = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalKey = 1;
        }
        //Crouch or Standing
        if (isClimbling == false)
        {
            if (Input.GetKey(KeyCode.S))
            {
                currentState = horizontalKey == 0 ? "crouchidle" : "crouchwalk";
                maxWalkForce = 3.0f;
                collider2D.enabled = false;
            }
            else
            {
                currentState = horizontalKey == 0 ? "idle" : "walk";
                maxWalkForce = 6.0f;
                collider2D.enabled = true;
            }
        }
            
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if (speedx < maxWalkForce)
        {
            rigid2D.AddForce(transform.right * horizontalKey * walkForce);

        }
        if (previousState != currentState)
        {
            skeletonAnimation.state.SetAnimation(0, currentState, true);
        }
        previousState = currentState;

        if (horizontalKey != 0)
        {
            skeletonAnimation.Skeleton.ScaleX = horizontalKey > 0 ? -1f : 1f;
        }
    }

    private void Magic()
    {
        skeletonAnimation.state.SetAnimation(0, "magic", false);
    }

    public void Activate()
    {
        inputEnabled = true;
        gameObject.GetComponent<FollowingPlayer>().enabled = true;
    }

    public void Deactivate()
    {
        inputEnabled = false;
        gameObject.GetComponent<FollowingPlayer>().enabled = false;
        gameObject.GetComponent<FollowingPlayer>().positionList.Clear();
    }
}
