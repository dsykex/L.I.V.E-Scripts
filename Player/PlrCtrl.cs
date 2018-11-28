using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

using UnitySampleAssets.CrossPlatformInput;
using EZCameraShake;

public class PlrCtrl : MonoBehaviour {
    public FixedJoystick leftJoystick;
    
    public FixedTouchField touchPad;
    public GameObject plrCamera;
    
    public float cameraAngleY;
    public float cameraAngleSpeed = 2f;
    public float cameraPosY;
    public float cameraAngleX;
    public float cameraPosSpeed = 0.1f;
    public float movementSpeed = 7f;

    public float yOffset = 5f;
    public float zOffset = 4f;

    private Animator anim;
    private Rigidbody rb;
    private GameManager gameMgr;
    private Vector3 mousePos;
    private Vector3 currentCamVelocity;

    private PlrStatus status;
	// Use this for initialization
	void Start () {
        currentCamVelocity = Vector3.zero;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
        status = GetComponent<PlrStatus>();
	}
   
    
    // Update is called once per frame
    void Update() {

        
        PlayerMovement();
        
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            mousePos = Input.mousePosition;
        }

        UpdateMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), touchPad.TouchDist.x);
        
    }

    void UpdateMovement(float x, float y, float cameraAngle)
    {
        float movementX = x;
        float movementY = y;

        //slower speed when moving backwards
        if (movementY < 0)
            movementY *= 0.5f;

     
        //Slower speed when straffing
        if (movementX != 0 && movementY != 0)
            movementY *= 0.6f;
        
        
        Vector3 movement = new Vector3(movementX * 0.8f, 0, movementY);

        //plrCamera.GetComponentInChildren<PlrCamera>().volume.profile.TryGetSettings(out chromaticAberration);
        //chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, movementY, 3f * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 50f);
        }

        cameraAngleY += cameraAngle * cameraAngleSpeed;
        
        var vel = Quaternion.AngleAxis(cameraAngleY + 180, Vector3.up) * movement * movementSpeed;

        anim.SetFloat("VelX", movementX);
        anim.SetFloat("VelY", movementY);

        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);

        transform.rotation = Quaternion.AngleAxis(cameraAngleY+180, Vector3.up);

        plrCamera.transform.position = Vector3.SmoothDamp(plrCamera.transform.position, transform.position + Quaternion.AngleAxis(cameraAngleY, Vector3.up) * new Vector3(0, yOffset, zOffset), ref currentCamVelocity, 0.17f) ;
        plrCamera.transform.rotation = Quaternion.LookRotation(transform.position + 2f * Vector3.up - plrCamera.transform.position, Vector3.up);

    }

}
