using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    float inputX;
    float inputY;
    float normalFov;
    float sprintFov =70;

    public Transform Model;
    Animator Anim;
    Vector3 stickDirection;

    Camera mainCam;

    public float damp;

    [Range(1, 20)]
    public float rotationSpeed;

    [Range(1, 20)]
    public float strafeTurnSpeed;

    float maxSpeed;
    public KeyCode sprintBtn = KeyCode.LeftShift;
    public KeyCode walkBtn = KeyCode.C;

    public enum MovementType
    {
        Directional,
        Strafe
    }

    public MovementType MovementT;
    
    void Start()
    {
        Anim = GetComponent<Animator>();
        mainCam = Camera.main;
        normalFov = mainCam.fieldOfView;

    }

    private void LateUpdate()
    {
       
        InputMove();
        InputRotation();
        Movement();
    }
    void Movement() {

        if (MovementT == MovementType.Strafe)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");

            Anim.SetFloat("iX", inputX, damp, Time.deltaTime * 10);//input x deðerini ix olarak tanýmladýk.
            Anim.SetFloat("iY", inputY, damp, Time.deltaTime * 10);
           


            var isMoving = inputX != 0 || inputY != 0; //koþul saglanýyorsa hareket ediyor

            if (isMoving)
            {
                float yawCamera = mainCam.transform.rotation.eulerAngles.y; //bu açý kameramýzýn y eksenindeki hareketi
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,yawCamera,0),strafeTurnSpeed*Time.fixedDeltaTime);
                Anim.SetBool("strafeMoving", true);
            }
            else
            {
                Anim.SetBool("strafeMoving", false);
            }

        }
        if (MovementT == MovementType.Directional)
        {
            InputMove();
            InputRotation();

            stickDirection = new Vector3(inputX, 0, inputY);

            if (Input.GetKey(sprintBtn))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, sprintFov, Time.deltaTime * 2);

                maxSpeed = 2;
                inputX = 2 * Input.GetAxis("Horizontal");
                inputY = 2 * Input.GetAxis("Vertical");

            }
            else if (Input.GetKey(walkBtn))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 0.2f;
                inputX = Input.GetAxis("Horizontal");
                inputY = Input.GetAxis("Vertical");
            }
            else
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 1;
                inputX = Input.GetAxis("Horizontal");
                inputY = Input.GetAxis("Vertical");

            }


        }



      
    }

    void InputMove()
    {
        Anim.SetFloat("speed", Vector3.ClampMagnitude(stickDirection, maxSpeed).magnitude, damp, Time.deltaTime * 10);
    }

    void InputRotation()
    {

        Vector3 rotOfset = mainCam.transform.TransformDirection(stickDirection);
        rotOfset.y = 0;

        Model.forward = Vector3.Slerp(Model.forward, rotOfset, rotationSpeed * Time.deltaTime);


    }

}
