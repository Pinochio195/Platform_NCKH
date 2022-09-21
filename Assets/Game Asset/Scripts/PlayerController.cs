using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyPlayer;
    private float Player_MoveX;

    private void Start()
    {
        Get_InputMovePlayer();
    }

    private void Update()
    {
        Check_InputMovePlayer();
    }

    private void FixedUpdate()
    {
    }

    private void Get_InputMovePlayer()
    {
        Player_MoveX = Input.GetAxis("Horizontal");
    }

    private void Check_InputMovePlayer()
    {
        rigidbodyPlayer.velocity = new Vector2(Player_MoveX * 15, rigidbodyPlayer.velocity.y);
    }
}