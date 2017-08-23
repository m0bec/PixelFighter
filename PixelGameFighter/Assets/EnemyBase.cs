using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {
	public float hp;
	public float Hp{
		get{return hp;}
		set{hp = value;}
	}
	void Damage(float damage_){
		hp -= damage_;
	}

	int score;
	public int Score{
		get{return score;}
		set{score = value;}
	}

	GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	// Use this for initialization
	public virtual void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}
	
	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Bullet")){
			Damage(col.gameObject.GetComponent<Shot>().Damage);
			Destroy(col.gameObject);
			if(hp <= 0){
				game_mode_data_keeper.Score = game_mode_data_keeper.Score + score;
				Destroy(this.gameObject);
			}
		}
	}
}
