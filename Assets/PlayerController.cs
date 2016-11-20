using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Text callout;
	public Text invDesc;

	public Transform box;

	private ArrayList inventory = new ArrayList();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) )
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) {
				var other = hit.transform.gameObject;
				var tag = other.tag;

				if (tag == "Box") {
					inventory.Add ("a box");
					UpdateInventoryDesc ();
					Destroy (other);	
				}

				callout.text = "That's a " + tag+ "...";
			} else {
				callout.text = "That's the sky mate...";
			}
		}

		if (Input.GetMouseButtonDown (1)) {

			if (inventory.Count > 0) {

				Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 100)) {
					Instantiate (box, new Vector3 (hit.point.x, hit.point.y + 2, hit.point.z), Quaternion.identity);
					inventory.RemoveAt (0);
					UpdateInventoryDesc ();
				}
			}
		}
	}

	void UpdateInventoryDesc () {
		invDesc.text = "You have " + inventory.Count + " box" +(inventory.Count != 1 ? "es." : ".");	
	}
}
