using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	public GameObject particleSystem;
	public GameObject light;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Ignite () {
		particleSystem.SetActive (true);
		light.SetActive (true);
	}
}
