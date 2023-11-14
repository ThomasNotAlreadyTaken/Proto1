using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GameManager : MonoBehaviour
{
    public PlayerInput GetPlayerInput { get; private set; }
    private Vector2 playerDirection;
    private GameObject player;
    private GameObject camera;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        // [...] Code d'initialisation du Singleton
        GetPlayerInput = GetComponent<PlayerInput>();
        GetPlayerInput.actions["move"].performed += MoveAxis;

        player = GameObject.FindGameObjectWithTag("player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        player.transform.position += 0.1f * (Vector3)GetPlayerInput.actions["move"].ReadValue<Vector2>();
        //rigidbody.MovePosition(new Vector2(player.transform.position.x, player.transform.position.y) + 0.1f * GetPlayerInput.actions["move"].ReadValue<Vector2>());
        camera.transform.position += 0.1f * (Vector3)GetPlayerInput.actions["move"].ReadValue<Vector2>();
    }

    public void MoveAxis(CallbackContext callbackAxis)
    {
        playerDirection = callbackAxis.ReadValue<Vector2>();
    }
}
