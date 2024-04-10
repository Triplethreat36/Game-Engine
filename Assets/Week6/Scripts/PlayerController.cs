using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
    
{
     public Vector3 startingPosition;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    PlayerControlerMapping playerMappings;

     InputAction move;
    InputAction fire;
    InputAction jump;
    InputAction look;

    [SerializeField] float rotation = 5.0f;

    private float mouseDeltaX = 0f;
    private float mouseDeltaY = 0f;
    private float cameraRotX = 0f;
    private int rotDir = 0;
    private bool Grounded;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerMappings = new PlayerControlerMapping();
        move = playerMappings.Player.Move;
       

        fire = playerMappings.Player.Fire;
        fire.performed += Fire;

        jump = playerMappings.Player.Jump;
        jump.performed += Jump;

        look = playerMappings.Player.Look;
    }


    private void OnEnable()
    {
        move.Enable();

      
        fire.Enable();
        jump.Enable();
        look.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        jump.Disable();
        look.Disable();
    }

    private void Update()
    {
        HandleVerticalRotation();
        HandleHorizontalRotation();



    }
    void HandleHorizontalRotation()
    {
        mouseDeltaX = look.ReadValue<Vector2>().x;

        if (mouseDeltaX != 0)
        {
            rotDir = mouseDeltaX > 0 ? 1 : -1;

            transform.eulerAngles += new Vector3(0, rotation * Time.deltaTime * rotDir, 0);
        }
    }

    void HandleVerticalRotation()
    {
        mouseDeltaY = look.ReadValue<Vector2>().y;

        if (mouseDeltaY != 0)
        {
            rotDir = mouseDeltaY > 0 ? -1 : 1;

            cameraRotX += rotation * Time.deltaTime * rotDir;
            cameraRotX = Mathf.Clamp(cameraRotX, -45f, 45f);

            var targetRotation = Quaternion.Euler(Vector3.right * cameraRotX);

            if (Camera.main != null)
            {
                Debug.Log(Camera.main.transform.localRotation.x);
                Camera.main.transform.localRotation = targetRotation;
            }
            else
            {
               // Debug.LogWarning("Main camera is not found or not active.");
            }
            //Vector3 angle = new Vector3(rotation * Time.deltaTime * rotDir, 0, 0);

            //Debug.Log(Camera.main.transform.localRotation.x);

            //Camera.main.transform.localRotation = targetRotation;
            //Camera.main.transform.Rotate(angle, Space.Self);

        }
    }
    // Start is called before the first frame update
   private void Start()
    {
         
        startingPosition = transform.position;
        // Subscribe to the RestartEvent
        GameManager.AddRestartEventListener(RestartPosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();
        Vector3 direction = (input.x * transform.right) + (transform.forward * input.y);

        transform.position = transform.position + (direction * speed * Time.deltaTime);
    }

    void Fire(InputAction.CallbackContext context)
    {
        
    }
    void Jump(InputAction.CallbackContext context) 
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("player has enter trigger");
        if(other.transform.tag == "Buller") Damage();

    }
    public void Damage()
    {
        //Debug.Log("Player is damage");
    }
    private void RestartPosition()
    {
        // Set the player's position to the starting position
       transform.position = startingPosition;
    }
    private void OnDestroy()
    {
        // Unsubscribe from the RestartEvent
        GameManager.RemoveRestartEventListener(RestartPosition);
    }
}
