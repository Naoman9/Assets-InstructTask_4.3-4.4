using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animation playerAnimation;
    public CharacterController playerController;
    public GameObject bombPrefab;

    public float playerSpeed = 10.0f;
    public float playerGravity;

    private Vector3 velocity;
   
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Bomb();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        // Moving Player
        moveDirection = horizontalInput * Vector3.right + verticalInput * Vector3.forward;
        playerController.Move(moveDirection);
        playerAnimation.GetComponents<Animation>();

        // Rotating Player in the moving direction
        if (moveDirection.magnitude > 0f)
        {
            Quaternion charactorLookDirection = Quaternion.LookRotation(moveDirection);
            playerController.transform.rotation = charactorLookDirection;
        }

        // Gravity Application
        velocity.y -= playerGravity * Time.deltaTime;
        playerController.Move(velocity);
    }

    void Bomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           Instantiate(bombPrefab, playerController.transform.position + new Vector3(0, 2.0f, 0), playerController.transform.rotation);
        }
    }

}
