using UnityEngine;
using System.Collections;

public class Setup : MonoBehaviour {
	public Camera mainCam;
	public BoxCollider2D topWall;
	public BoxCollider2D botWall;
	public BoxCollider2D rightWall;
	public BoxCollider2D leftWall;
	// Use this for initialization
	void Start () {//the 1f and 0.5f things are there because the actual collider is given a width of 1f yay I understand now :P 
        //also screen.height in the ScreenToWorldPoint is from center I think so that's why we do *2f only when setting size up
		botWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3(Screen.width*2f, 0f, 0f)).x, 1f);
		botWall.offset = new Vector2 (0f,-mainCam.ScreenToWorldPoint (new Vector3(0f, Screen.height, 0f)).y + 0.5f);//+0.5f because width of collider is 1 and offset is from center

        topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width*2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y+0.5f);//+0.5f because width of collider is 1 and offset is from center

        leftWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height*2f, 0f)).y);
        leftWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x - 0.5f, 0f);//+0.5f because width of collider is 1 and offset is from center

        rightWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height*2f, 0f)).y);
        rightWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x+0.5f, 0f);//+0.5f because width of collider is 1 and offset is from center


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
