using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public GameObject smoke;
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private bool isBreakable;
	private int timesHit;
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
			Debug.Log(breakableCount);
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		timesHit=0;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		AudioSource.PlayClipAtPoint(crack,transform.position,0.8f);
		if(isBreakable){
			
			HandleHits();
			
		}
		
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length +1;
		if(timesHit >= maxHits){
			breakableCount--;
			PuffSmoke();
			levelManager.BrickDestroyed();
			Destroy(gameObject,0.1f);
		}else{
			LoadSprites();
		}
		
	}
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position,Quaternion.identity) as GameObject;
		//smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

    }
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError("Sprite missing from Brick");
		}
		
	}
}
