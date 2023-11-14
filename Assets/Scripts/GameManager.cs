using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GameManager : MonoBehaviour
{
    private InputMaster inputMaster;
    private Vector2 playerDirection;
    private GameObject player;
    private GameObject camera;
    private Rigidbody2D rigidbody;

    private void OnEnable()
    {
        inputMaster = new InputMaster();
        inputMaster.Balade.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Balade.Disable();
    }


    private void Awake()
    {
        // [...] Code d'initialisation du Singleton

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
        playerDirection = inputMaster.Balade.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        //player.transform.position += 0.1f * (Vector3)playerDirection;
        rigidbody.MovePosition(new Vector2(player.transform.position.x, player.transform.position.y) + 0.1f * playerDirection);
        camera.transform.position += 0.1f * (Vector3)playerDirection;
    }

}
