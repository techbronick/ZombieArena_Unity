//This script was created using Brackeys tutorials
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public PlayerStats playerStats;


    public float speed;
    public float moveSpeed = 12f;
    public float sprintSpeed = 24f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool onGround;


    void Update()
    {
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (onGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && z == 1)
        {
            playerStats.currentStamina -= Time.deltaTime * 10;
            speed = sprintSpeed;
            if (playerStats.currentStamina < 0)
            {
                playerStats.currentStamina = 0;
                speed = moveSpeed;
            }
        }
        else if (playerStats.currentStamina < playerStats.maxStamina)
        {
            playerStats.currentStamina += Time.deltaTime * 10;
            speed = moveSpeed;
        }






        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && onGround && playerStats.currentStamina >= 20)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            playerStats.currentStamina -= 20;
        }

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
}
