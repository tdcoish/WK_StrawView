using UnityEngine;


/*********************************************************************
Raycasts from the camera out to the first cube it intersects. Then makes
that cube "selectable".

Working, although the camera doesn't move with the mouse, so it can be a 
little confusing. 
******************************************************************* */
public class INT_ClickController : MonoBehaviour {

	[SerializeField]
	private GE_Event			mClickedEvent;

	private Camera				mCam;

	private void Start(){
		mCam = GetComponent<Camera>();
	}

	private void Update()
	{
		// here's where we select an object to click on.
		if(Input.GetMouseButtonDown(0)){
			// now do something.
			mClickedEvent.Raise(null);

			// now we raycast to find the cube that's gonna be the active guy.
			RaycastHit hit;
			if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)){
				if(hit.transform.GetComponent<INT_ClickableCube>()){
					Debug.Log("Hit Cube with Collider");
				}
			}
		}
	}
}
