using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Text callout;
	private Text invDesc;

	public Transform box;

	private ArrayList inventory = new ArrayList();

	// Use this for initialization
	void Start () {
		callout = GameObject.Find ("Callout").GetComponent<Text>();
		invDesc = GameObject.Find ("InvDesc").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetKeyDown("e") )
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 4)) {
				var other = hit.transform.gameObject;
				var tag = other.tag;

				if (tag == "Box" || tag == "Tinderbox" || tag == "Key") {
					inventory.Add (tag);
					UpdateInventoryDesc ();

					callout.text = "Picked up a " + tag+ "...";
					Destroy (other);	
				}
			} else {
				callout.text = "Nothing to pick up in reach...";
			}
		}

		if ( Input.GetMouseButtonDown(0) )
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 4)) {
				var other = hit.transform.gameObject;
				var tag = other.tag;

				if (tag == "Torch") {
					if (inventory.Contains ("Tinderbox")) {
						var torch = other.GetComponent<Torch> ();
						torch.Ignite ();
					} else {
						callout.text = "The torch is out...";
					}
				}
			} else {
				callout.text = "Can't reach that far...";
			}
		}
	}

	void UpdateInventoryDesc () {
		invDesc.text = "You have " + inventory.Count + " box" +(inventory.Count != 1 ? "es." : ".");	
	}
}
