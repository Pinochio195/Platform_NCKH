using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyPlayer;
    [SerializeField] private Animator animatorPLayer;
    private float Player_MoveX;
    public float Jump;
    public float MoveDistance;

    private void Start()
    {
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
        Player_MoveX = Input.GetAxis("Horizontal");
    }

    private void Check_InputMovePlayer()
    {
        rigidbodyPlayer.velocity = new Vector2(Player_MoveX * MoveDistance, rigidbodyPlayer.velocity.y);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbodyPlayer.velocity = new Vector2(rigidbodyPlayer.velocity.x, Jump);
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
    }
}