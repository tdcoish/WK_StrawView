using UnityEngine;

/**********************************************************************************
Camera free movement. Camera moves around with traditional 3D cam. If they press e they go 
up, if they press q they go down.
******************************************************************************** */
public class CAM_Freemove : MonoBehaviour {
    
    [SerializeField]
    private float       _LookSpeed = 2f;

    [SerializeField]
    private float       _TumbleSpeed = 1f;

    [SerializeField]
    private float       _HorizontalMovementSpeed = 10f;

    [SerializeField]
    private float       _VerticalMovementSpeed = 4f;

    [SerializeField]
    private bool        _FreezeRoll = true;

    private bool        _Sprint = false;

	[SerializeField]
	private float 		_FlySpeed = 4f;

	private Camera		mCam;
    
	private void Start(){
		mCam = GetComponent<Camera>();
		Cursor.visible = false; 	
	}

    // attach a camera to whatever object you put this in.
    private void Update(){
        CameraRotations();
        MoveCamera();
        Orient();
    }
    
    private void Orient(){
        if(_FreezeRoll){
            Vector3 rot = transform.rotation.eulerAngles;
            rot.z = 0;

            transform.rotation = Quaternion.Euler(rot);
        }
    }

    private void MoveCamera(){

		Vector3 vel = new Vector3();

		// handle forwards and backwards.
		if(Input.GetKey(KeyCode.W)){
			vel = transform.forward * _FlySpeed;
		}
		if(Input.GetKey(KeyCode.S)){
			vel = transform.forward * -_FlySpeed;
		}

		// now we handle going to the side.
		if(Input.GetKey(KeyCode.A)){
			vel += transform.right * -_FlySpeed;
		}
		if(Input.GetKey(KeyCode.D)){
			vel += transform.right * _FlySpeed;
		}

		// now add going up or down
		if(Input.GetKey(KeyCode.E)){
			vel += transform.up * _VerticalMovementSpeed;
		}
		if(Input.GetKey(KeyCode.Q)){
			vel += transform.up * -_VerticalMovementSpeed;
		}

		transform.position += vel * Time.deltaTime;
	}
    private void CameraRotations()
    {
        /// Rotates player according to mouse movement

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mouseX * _LookSpeed, 0);
        transform.Rotate(-mouseY * _LookSpeed, 0, 0);
        transform.Rotate(0, 0, -mouseX * _TumbleSpeed);// Only valid if _FreezeRoll is true
    }
}



