using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyPlayer;
    [SerializeField] private Animator animatorPLayer;
    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private BoxCollider2D boxColliderPlayer;
    private float DistanceRadius = .3f;
    private float DistanceRadiusLeft;
    [SerializeField] private Transform Trans_GroundCheckJump;
    private bool isCheckGround;
    public bool check;

    //
    private float Player_MoveX;

    public float PlayerJump;
    public float PlayerSpeed;

    //
    private int NumberJump = 2;

    private int NumberJumpLeft;

    private void Start()
    {
        NumberJumpLeft = NumberJump;
        DistanceRadiusLeft = DistanceRadius;
    }

    private void Update()
    {
        Get_InputMovePlayer();
        Player_Flip();
        Player_Jump();
        Player_AnimationsMove();
    }

    private void FixedUpdate()
    {
        Check_InputMovePlayer();
    }

    private void Get_InputMovePlayer()
    {
        Player_MoveX = Input.GetAxisRaw("Horizontal");
    }

    private void Check_InputMovePlayer()
    {
        rigidbodyPlayer.velocity = new Vector2(Player_MoveX * PlayerSpeed, rigidbodyPlayer.velocity.y);
    }

    private void Player_Flip()
    {
        if (!Mathf.Approximately(Player_MoveX, 0))
        {
            transform.rotation = Player_MoveX < 0 ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity;
        }
    }

    private void Player_Jump()
    {
        Player_CheckGroundJump();

        if (Input.GetKeyDown(KeyCode.Space) && NumberJumpLeft > 0)
        {
            rigidbodyPlayer.velocity = new Vector2(rigidbodyPlayer.velocity.x, PlayerJump);
            NumberJumpLeft--;
            animatorPLayer.SetFloat("Jump", rigidbodyPlayer.velocity.y);
        }
        if (isCheckGround && rigidbodyPlayer.velocity.y <= 0)
        {
            NumberJumpLeft = NumberJump;
        }
    }

    private void Player_AnimationsMove()
    {
        if (Player_MoveX != 0)
        {
            animatorPLayer.SetBool("RunPlayer", true);
        }
        else
        {
            animatorPLayer.SetBool("RunPlayer", false);
        }
        animatorPLayer.SetBool("isGroundJump", isCheckGround);
        animatorPLayer.SetFloat("Jump", rigidbodyPlayer.velocity.y);
    }

    private void Player_CheckGroundJump()
    {
        //isCheckGround = Physics2D.OverlapCircle(Trans_GroundCheckJump.position, DistanceRadiusLeft, WhatIsGround);
        isCheckGround = boxColliderPlayer.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Trans_GroundCheckJump.position, DistanceRadiusLeft);
    }
}