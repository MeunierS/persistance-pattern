using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction move;
    private InputAction shoot;
    [SerializeField] private float speed;
    private CharacterController characterController;
    [SerializeField] private Camera cam;
    [SerializeField]private float cooldown = 2f;
    private Rigidbody body;
    [SerializeField] private int life=5;
    private bool isInvicible=false;
    [HideInInspector]public UnityEvent<int> onLifeLost;
    [SerializeField] BulletBehavior bullet;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        shoot = playerInput.actions["Shoot"];
        shoot.performed += ctx => {OnShoot(ctx);};
        characterController = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();
        onLifeLost?.Invoke(life);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = move.ReadValue<Vector2>();
        characterController.Move(new Vector3(movement.x, movement.y, 0) * Time.deltaTime * speed);
        PlayerMovementLimit();
    }
    void OnTriggerEnter(Collider hit){
        hit.GetComponent<CubeMovement>().Die();
        LoseLife();
        StartCoroutine(InvulnerabilityFrame());
    }
    void PlayerMovementLimit()
    {
    Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
    screenPos.x = Mathf.Clamp01(screenPos.x);
    screenPos.y = Mathf.Clamp01(screenPos.y);
    transform.position = Camera.main.ViewportToWorldPoint(screenPos);
    }
    private IEnumerator InvulnerabilityFrame(){
        isInvicible=true;
        this.GetComponentInChildren<Renderer>().enabled = false;
        yield return new WaitForSeconds(cooldown);
        this.GetComponentInChildren<Renderer>().enabled = true;
        isInvicible=false;
    }
    private void LoseLife(){
        if (!isInvicible){
            life--;
        }
        onLifeLost?.Invoke(life);
    }
    public void OnShoot(InputAction.CallbackContext ctx){
        bullet.Initialize();
        bullet.transform.Translate(bullet.speed, 0, 0);
    }
}
