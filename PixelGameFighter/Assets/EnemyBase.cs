using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {
	float hp{
		get{return hp;}
		set{hp = value;}
	}
	void Damage(float damage_){
		hp -= damage_;
	}

	int score{
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
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("BulletOne")){
			Damage(col.gameObject.GetComponent<ShotOne>().Damage);
			Destroy(col.gameObject);
			if(hp <= 0){
				game_mode_data_keeper.Score = game_mode_data_keeper.Score + score;
				Destroy(this.gameObject);
			}
		}
	}
}
