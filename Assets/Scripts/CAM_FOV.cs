using UnityEngine;

/*********************************************************************************************
This code makes the camera move back when the user presses WASD keys.
However, it also "zooms in" when the user scrolls up or down on the control wheel, to a limit.

First, I'll just have you zooming in to perfectly match moving backwards. What's the math behind that?

Well we need to be zoomed in to a degree that when we are x times further away, we are also x times
more magnified.

EDIT: Turns out it's a linear relationship. That makes things easy.

Anyway, now I want to add 2 things. First, let the user control the level of zoom. Second, put a 
second camera that shows the distance between the camera and the special cube.
******************************************************************************************* */
public class CAM_FOV : MonoBehaviour {

	private Camera		mCam;
	private Rigidbody	mRigid;

	private float 		mStartDis;
	private float  		mStartFOV = 90f;

	private float 		mVel = -0.2f;

	[SerializeField]
	private DEBUG_DistanceTag		SpecialCube;

	// Use this for initialization
	void Start () {
		mCam = GetComponent<Camera>();	
		mRigid = GetComponent<Rigidbody>();

		// mCam.aspect = 1f;	

		mStartDis = Vector3.Distance(SpecialCube.transform.position, transform.position);
		Debug.Log("Distance to cube: " + mStartDis);
		
		// give us a velocity going forward.
		mRigid.velocity = transform.forward*mVel;
		mCam.fieldOfView = mStartFOV;
	}
	
	// Update is called once per frame
	void Update () {
		mVel*=1.01f;
		mRigid.velocity = transform.forward*mVel;
		// find the distance multiplier.
		float disMult = Vector3.Distance(SpecialCube.transform.position, transform.position) / mStartDis;
		// disMult *= disMult;
		float mNewFOV = mStartFOV/disMult;
		mCam.fieldOfView = mNewFOV;
		Debug.Log("FOV: " + mNewFOV);
	}
}
