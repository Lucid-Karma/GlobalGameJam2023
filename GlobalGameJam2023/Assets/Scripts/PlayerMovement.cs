using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public enum ExecutingState
{
    WANDER,
    EMBUS
}
public class PlayerMovement : MonoBehaviour
{
    #region FSM
        PlayerStates currentState;

        public WanderState wanderState = new WanderState();
        public EmbusState embusState = new EmbusState();


        public ExecutingState executingState;
    #endregion

    public CharacterController controller;

    public float speed = 12f, gravity = -9.81f, groundDistance = 0.4f, jumpHeight = 3f, sceneNumber;

    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded,isDoor = false;

    [SerializeField] private GameObject switchObject,flashLight,doorObject;

    void Start()
    {
        executingState = ExecutingState.WANDER;
        currentState = wanderState;
        currentState.EnterState(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("car"))
        {
            executingState = ExecutingState.EMBUS;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("car"))
        {
            executingState = ExecutingState.WANDER;
        }
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (switchObject.activeInHierarchy)
            {
                switchObject.SetActive(false);
            }
            else
            {
                switchObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (flashLight.activeInHierarchy)
            {
                flashLight.SetActive(false);
            }
            else
            {
                flashLight.SetActive(true);
            }
        }

        velocity.y += (gravity * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);
    }

    public void SwitchState(PlayerStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
