using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(CharacterController))]
public class FPSControls : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    [SerializeField] float runSpeed=12;
    [SerializeField] float jumpPower=7;
    [SerializeField] float gravity=10;

    [SerializeField] float lookSpeed = 2;
    [SerializeField] float lookXlimit = 45;

    private Vector3 moveDirection=Vector3.zero;
    float rotationX=0;

    public bool canMove = true;

    [Header("Shooting")]
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private float rayMaxDistance=100;
    public LayerMask targetMask;
    [SerializeField] private GameObject destructionParticle;
    private LineRenderer line;
    [SerializeField] private AnimationCurve lineWidthCurve;
    [SerializeField] private float lineWidthTimer=1;

    private AudioSource audioSrc;

    private CharacterController characterController;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        audioSrc = GetComponent<AudioSource>();
        line = GetComponent<LineRenderer>();
        LevelController.Instance.OnLevelEnd.AddListener(LevelEnd);
    }
    private void LevelEnd()
    {
        canMove = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (canMove)
        {
            Move();
            RotateCam();
        }


        if(Input.GetButtonDown("Fire1") && canMove)
        {
            RaycastHit hit = RaycastDetect();
            Shoot(hit);
        }
    }
    private void Shoot(RaycastHit hit)
    {
        audioSrc.Play();
        if (hit.transform != null)
        {
            //hit
            DrawShotLine(hit.transform.position);
            var part = Instantiate(destructionParticle, hit.transform.position, Quaternion.identity);
            part.transform.rotation = hit.transform.rotation;
            Destroy(hit.transform.gameObject);
        } else
        {
            DrawShotLine(rayOrigin.forward*rayMaxDistance);
        }
    }

    private void DrawShotLine(Vector3 endPos)
    {
        // draw line 
        line.widthMultiplier = 1;
        line.SetPosition(0, rayOrigin.position);
        line.SetPosition(1, endPos);
        StartCoroutine(ShotLineShrink(lineWidthTimer));
    }

    RaycastHit RaycastDetect()
    {
        RaycastHit hit;

        float screenX = Screen.width / 2;
        float screenY = Screen.height / 2;

        Ray ray = playerCam.ScreenPointToRay(new Vector3(screenX, screenY));
        Physics.Raycast(ray, out hit,rayMaxDistance,targetMask);

        return hit;
    }

    private void RotateCam()
    {
        //rotating
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXlimit, lookXlimit);
        playerCam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
    private void Move()
    {
        // movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = runSpeed * Input.GetAxis("Vertical");
        float curSpeedY = runSpeed * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        // jumping
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private IEnumerator ShotLineShrink(float time)
    {
        float journey = 0f;
        while (journey <= time)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / time);
            float curvePercent = lineWidthCurve.Evaluate(percent);
            line.widthMultiplier = curvePercent;
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Respawn"))
        {
            LevelController.Instance.Restartlevel();
        }
    }
}
