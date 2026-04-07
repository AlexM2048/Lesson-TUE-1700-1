using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;
    [SerializeField] float gravity = 50;
    [SerializeField] float jumpForce = 40;
    private Vector3 direction;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;

            if (Input.GetKey(KeyCode.Space)) 
            {
                direction.y = jumpForce;
            }
        }
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

    }
}
