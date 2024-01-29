using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] float health;
    [SerializeField] float movementSpeed;

    private static Vector3 direction;

    public static Vector3 Direction { get { return direction; } private set { direction = value; } }

    Camera mainCam;
    Animator animator;
    CharacterController characterController;

    void Start()
    {
        mainCam = Camera.main;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Movement();
        Attack();
    }

    void LateUpdate()
    {
        LookAtCursor();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float speed = (Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)) * 2;

        Vector3 horizontalTranslation = verticalInput * movementSpeed * Time.deltaTime * transform.forward;
        Vector3 verticalTranslation = horizontalInput * movementSpeed * Time.deltaTime * transform.right;

        animator.SetFloat("Speed_f", speed);

        characterController.Move(horizontalTranslation + verticalTranslation);
    }

    void LookAtCursor()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        float distanceFromCamera = 19f;

        Ray ray = mainCam.ScreenPointToRay(mousePosition);
        Vector3 cursorWorldPosition = ray.GetPoint(distanceFromCamera);
        cursorWorldPosition.Scale(new Vector3(1, 0, 1));
        transform.forward = transform.position.DirectionToTarget(cursorWorldPosition); // Alt could use transform.LookAt(worldPosition)
        Direction = transform.forward;
    }

    void Attack()
    {
        float fireInput = Input.GetAxis("Fire1");

        if (fireInput == 1 && !weapon.InUse)
        {
            animator.Play("Character_Handgun_Shoot");
            weapon.Attack();
        }
    }
}
