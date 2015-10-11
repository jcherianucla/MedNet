using UnityEngine;
using System.Collections;

public class Myo : MonoBehaviour {

	public GameObject myo;
	public GameObject brain;
	private int speed = 15;
	GameObject closestObject = null;

	GameObject highlight = null;
	GameObject selected = null;
	public GameObject txt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (myo.GetComponent<ThalmicMyo> ().pose == Thalmic.Myo.Pose.Fist && (this.transform.position - brain.transform.position).sqrMagnitude > 9000) {
			//brain.transform.localScale += Vector3.one * 0.05f;
			brain.transform.localPosition -= Vector3.forward * speed;
			txt.transform.localScale += Vector3.one;
		} 
		else if (myo.GetComponent<ThalmicMyo> ().pose == Thalmic.Myo.Pose.FingersSpread && (this.transform.position - brain.transform.position).sqrMagnitude < 30000) {
			//brain.transform.localScale -= Vector3.one * 0.05f;
			brain.transform.localPosition += Vector3.forward * speed;
			txt.transform.localScale -= Vector3.one;
		}
		else if (myo.GetComponent<ThalmicMyo> ().pose == Thalmic.Myo.Pose.WaveIn)
			brain.transform.Rotate (Vector3.up * 50 * Time.deltaTime);
		else if (myo.GetComponent<ThalmicMyo> ().pose == Thalmic.Myo.Pose.WaveOut)
			brain.transform.Rotate (Vector3.down * 50 * Time.deltaTime);

		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		Debug.DrawLine (transform.position, transform.position + fwd * 1000);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, fwd, out hit, 1000)) {
			if(highlight != null && highlight != hit.transform.gameObject && selected != hit.transform.gameObject){
				highlight.GetComponent<Renderer>().material.color -= Color.gray / 2;
				highlight = hit.transform.gameObject;
				highlight.GetComponent<Renderer>().material.color += Color.gray / 2;
			}
			else if(highlight == null){
				highlight = hit.transform.gameObject;
				highlight.GetComponent<Renderer>().material.color += Color.gray / 2;
			}

		}


		
		if (myo.GetComponent<ThalmicMyo> ().pose == Thalmic.Myo.Pose.DoubleTap) {
			if(selected != null && selected != hit.transform.gameObject){
				selected.GetComponent<Renderer>().material.color -= Color.gray * 2;
				selected.transform.localScale -= Vector3.one * 0.07f;
				selected = hit.transform.gameObject;
				selected.GetComponent<Renderer>().material.color += Color.gray * 2;
				selected.transform.localScale += Vector3.one * 0.07f;
			}
			else if(selected == null){
				selected = hit.transform.gameObject;
				selected.GetComponent<Renderer>().material.color += Color.gray * 2;
				selected.transform.localScale += Vector3.one * 0.07f;
			}
			//GameObject [] parts = new GameObject [59];
			/*GameObject [] parts = GameObject.FindGameObjectsWithTag("Part");
			float closest = 100000000f;
			for (int i = 0; i < parts.Length; i++){
				if((parts[i].transform.position - transform.position).sqrMagnitude < closest){
					closest = (parts[i].transform.position - transform.position).sqrMagnitude;
					Debug.Log(closest);
					closestObject = parts[i];
				}
			}*/
			//Debug.Log(closestObject.name);
			//closestObject.GetComponentInChildren<Renderer>().material.color = Color.white;
		}
	}
}
