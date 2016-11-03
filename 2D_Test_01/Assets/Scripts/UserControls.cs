using UnityEngine;
using System.Collections;

public class UserControls : MonoBehaviour {
	//public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (-25, 0));
		} 
		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (25, 0));
		}
       if (Input.GetKey (KeyCode.UpArrow)) {
            GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 25));
        }
       if (Input.GetKey (KeyCode.DownArrow)) {
            GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, -25));
        }
	}
}
