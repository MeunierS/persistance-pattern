using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction move;
    [SerializeField] private float speed;

    private Vector3 forward, right;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = move.ReadValue<Vector2>();
        characterController.Move(new Vector3(movement.x, movement.y, 0) * Time.deltaTime * speed);
    }
    void OnControllerColliderHit(ControllerColliderHit hit){
        Debug.Log("touché");
    }
}
