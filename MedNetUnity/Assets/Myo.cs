using UnityEngine;
using System.Collections;

public class Myo : MonoBehaviour {

	public GameObject myo;
	public GameObject brain;
	private int speed = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (myo.GetComponent<ThalmicMyo> ().pose == Thalmic.Myo.Pose.Fist && (Vector3.zero - brain.transform.localScale).sqrMagnitude < 40) {
			brain.transform.localScale += Vector3.one * 0.05f;
		} else if (myo.GetComponent<ThalmicMyo> ().pose == Thalmic.Myo.Pose.FingersSpread && (Vector3.zero - brain.transform.localScale).sqrMagnitude > 1)
			brain.transform.localScale -= Vector3.one * 0.05f;
		else if (myo.GetComponent<ThalmicMyo> ().pose == Thalmic.Myo.Pose.WaveIn)
			brain.transform.Rotate (Vector3.up * 50 * Time.deltaTime);
		else if (myo.GetComponent<ThalmicMyo> ().pose == Thalmic.Myo.Pose.WaveOut)
			brain.transform.Rotate (Vector3.down * 50 * Time.deltaTime);
	}
}
