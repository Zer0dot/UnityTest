using UnityEngine;
using System.Collections;
//TODO: MAKE THE LASER GO OUT OF EYES ALWAYS USING IDFK SOMETHING PROBABLY TRIG EUGH EWW ANYWAY WHATEVS GOOD RPOGRESS
public class UserControls : MonoBehaviour {
	// Use this for initialization
    static float zAngle;
    public Collider2D topWall;
    public Collider2D botWall;
    public Collider2D leftWall;
    public Collider2D rightWall;
    public GameObject laserPrefab;
    GameObject laserClone;

	void Start () {
		//rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
        float positionX = GetComponent<Transform>().position.x;
        float positionY = GetComponent<Transform>().position.y;
        float hyp = 0f;
        float adjacent = 0f;
        float opposite = 0f;


        zAngle = Mathf.Atan((GetComponent<Rigidbody2D>().velocity).y/(GetComponent<Rigidbody2D>().velocity).x);
        GetComponent<Transform>().eulerAngles = (new Vector3 (0, 0, 180*zAngle/Mathf.PI));
      
		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (-25, 0));
           GetComponent<SpriteRenderer>().flipX = true;
		} 
		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (25, 0));
            GetComponent<SpriteRenderer>().flipX = false;
		}
       if (Input.GetKey (KeyCode.UpArrow)) {
            GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 25));
        }
       if (Input.GetKey (KeyCode.DownArrow)) {
            GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, -25));
        }
       if (Input.GetKeyDown (KeyCode.Space)) {//Fire
           laserClone = Instantiate(laserPrefab, transform.position, Quaternion.identity, GetComponent<Transform>() ) as GameObject;
           Physics2D.IgnoreCollision(laserClone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
           Physics2D.IgnoreCollision(laserClone.GetComponent<Collider2D>(), topWall);
           Physics2D.IgnoreCollision(laserClone.GetComponent<Collider2D>(), botWall);
           Physics2D.IgnoreCollision(laserClone.GetComponent<Collider2D>(), leftWall);
           Physics2D.IgnoreCollision(laserClone.GetComponent<Collider2D>(), rightWall);

           



           hyp = laserClone.GetComponent<SpriteRenderer>().bounds.size.x;
           adjacent = hyp*Mathf.Cos(zAngle);
           opposite = hyp*Mathf.Sin(zAngle);
           //laserClone.GetComponent<Rigidbody2D>().position = new Vector3 (positionX + laserClone.GetComponent<SpriteRenderer>().bounds.size.x/2*0, positionY + 0.2f, 0f);
           laserClone.GetComponent<Transform>().eulerAngles = (new Vector3 (0, 0, 180*zAngle/Mathf.PI));


        }
       if (Input.GetKey (KeyCode.Space)) {
           hyp = laserClone.GetComponent<SpriteRenderer>().bounds.size.x;
           adjacent = hyp*Mathf.Cos(zAngle);
           opposite = hyp*Mathf.Sin(zAngle);

           if (GetComponent<SpriteRenderer>().flipX == true) {
                laserClone.GetComponent<Rigidbody2D>().position = new Vector3 (positionX - adjacent/2, positionY - opposite/2, 0f);
            }
           else {
                laserClone.GetComponent<Rigidbody2D>().position = new Vector3 (positionX + adjacent/2, positionY + opposite/2, 0f);
            }
           
           laserClone.GetComponent<Transform>().eulerAngles = (new Vector3 (0, 0, 180*zAngle/Mathf.PI));
           Debug.Log(adjacent + " " + opposite);
        }
       if (Input.GetKeyUp (KeyCode.Space)) {
            Destroy (laserClone);
        }
       
      
	}
}
