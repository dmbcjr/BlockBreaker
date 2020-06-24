using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	private Ball ball;
	public float minX,maxX;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		}else{
			GameAutoPlay();
		}
	}
	
	void MoveWithMouse(){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (mousePosInBlocks, this.transform.position.y, 0f);
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,minX,maxX);
		
		this.transform.position = paddlePos;
	
	}
	void GameAutoPlay(){
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, minX,maxX);
		this.transform.position = paddlePos;
	}
}
