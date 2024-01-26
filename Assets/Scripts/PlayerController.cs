using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] GameObject projectivePrefab;
    [SerializeField] float shootSpeed;

    Camera mainCam;
    Animator animator;


    void Start()
    {
        mainCam = Camera.main;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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

        float speed = Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);

        animator.SetFloat("Speed_f", speed);

        transform.Translate(verticalInput * movementSpeed * Time.deltaTime * Vector3.forward);
        transform.Translate(horizontalInput * movementSpeed * Time.deltaTime * Vector3.right);
    }

    void LookAtCursor()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        float distanceFromCamera = 19f;

        Ray ray = mainCam.ScreenPointToRay(mousePosition);
        Vector3 cursorWorldPosition = ray.GetPoint(distanceFromCamera);
        cursorWorldPosition.Scale(new Vector3(1, 0, 1));
        transform.forward = transform.position.DirectionToTarget(cursorWorldPosition); // Alt could use transform.LookAt(worldPosition)
    }

    void Attack()
    {
        float fireInput = Input.GetAxis("Fire1");
    }
}
