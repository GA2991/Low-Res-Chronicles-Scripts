using UnityEngine;
using System.Collections;

public class CameraLookWithZoom : MonoBehaviour {

	public GameObject objectToTrack;
	bool camEnabled = true;
	public bool autoZoomEnabled = false;

	public float minzoomdistance = 40;
	public float maxzoomdistance = 100;
	[Range(1, 179)]
	public float minzoomfov = 60;
	[Range(1, 179)]
	public float maxzoomfov = 20;

	[Range(0.001f, 1f)]
	public float zoomLerpSpeed = 0.2f;

	public bool debugMode = false;

	[Range(0.001f, 0.5f)]
	public float speed = 0.03f;
	public bool autoSpeedIfObjectOutOfView = true;
	[Range(1, 10)]
	public float speedMultiplyer = 2;

	float localspeed;
	float fov;

	[Range(0, 1)]
	public float sensivity = 0.5f;

	Camera thiscamera;
	Vector3 desiredLook;

	public bool enableObjectData;
	public bool canSee = false;
	public float objectDistance = 0;
	public float seenLast = 0;

	// Use this for initialization
	void Start () {
		thiscamera = this.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (camEnabled) {
			//Object to track checking
			if (!objectToTrack) {
				if (debugMode) {
					Debug.LogError("Camera " + thiscamera.name + " has no object to track!");
				}
				camEnabled = false;
				return;
			}
			Quaternion rot = Quaternion.LookRotation (desiredLook);

			Vector3 viewpos = thiscamera.WorldToViewportPoint (objectToTrack.transform.position);

			localspeed = speed;

			if (viewpos.x > 1 || viewpos.y > 1 || viewpos.x < 0 || viewpos.y < 0) {
				localspeed = speed * speedMultiplyer;
			}

			transform.rotation = Quaternion.Lerp (transform.rotation, rot, localspeed);

			if (viewpos.x >  sensivity/2 + 0.5f || viewpos.y >  sensivity/2 + 0.5f) {
				desiredLook = objectToTrack.transform.position - transform.position;
			}

			if (viewpos.x < 0.5f - sensivity/2 || viewpos.y < 0.5f - sensivity/2 ) {
				desiredLook = objectToTrack.transform.position - transform.position;
			}
			//Debug.Log (viewpos);
			if (autoZoomEnabled) {

				float dist = viewpos.z;
				if (dist > minzoomdistance) {
					if (dist < maxzoomdistance) {
						float percent = dist/(maxzoomdistance);


						float fovrange = (1 - percent) * (minzoomfov + maxzoomfov);
						

						if (fovrange < maxzoomfov) {
							fovrange = maxzoomfov;
						}

						fov = fovrange;

						//Debug.Log (fovrange);
					} else {
						if (debugMode) {
							Debug.Log("Locked Upper FOV");
						}
						fov = maxzoomfov;
					}
				} else {
					if (debugMode) {
						Debug.Log("Locked Lower FOV");
					}
					fov = minzoomfov;
				}
				thiscamera.fieldOfView = Mathf.Lerp (thiscamera.fieldOfView, fov, zoomLerpSpeed);
			}
			if (enableObjectData) {

				Ray ray = new Ray (thiscamera.transform.position, objectToTrack.transform.position - thiscamera.transform.position);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					if (hit.transform.position != objectToTrack.transform.position) {
						canSee = false;
						seenLast += Time.deltaTime;
					} else {
						canSee = true;
						seenLast = 0;
					}
					if (debugMode) {
						Debug.DrawLine (ray.origin, hit.point);
					}

				}
				objectDistance = viewpos.z;
			}
		}
        if (Time.timeScale == 0) // Si el juego está pausado
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
