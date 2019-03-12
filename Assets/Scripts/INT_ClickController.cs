using UnityEngine;


/*********************************************************************
Raycasts from the camera out to the first cube it intersects. Then makes
that cube "selectable".
******************************************************************* */
public class INT_ClickController : MonoBehaviour {

	[SerializeField]
	private GE_Event			mClickedEvent;

	private void Update()
	{
		// here's where we select an object to click on.
		if(Input.GetMouseButton(0)){
			// now do something.
			mClickedEvent.Raise(null);
		}
	}
}
