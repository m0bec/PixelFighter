using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankBase : MonoBehaviour {
	public List<SEnemyShot> enemy_shot = new List<SEnemyShot>();
	GameObject player_obj;
	public void SetPlayerObj(GameObject player_obj_){
		player_obj = player_obj_;
	}
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
		player_obj = GameObject.Find("PlayerFighter");
	}
	
	// Update is called once per frame
	public virtual void Update () {
		ShootShot();
	}
	
	bool in_field;
	public bool InField{
		set{in_field = value;}
	}
	public GameObject explosion_effect;
	public void OnTriggerEnter2D(Collider2D col){
		if(in_field){
			if(col.gameObject.CompareTag("Bullet")){
				Damage(col.gameObject.GetComponent<Shot>().Damage);
				Destroy(col.gameObject);
				if(hp <= 0){
					game_mode_data_keeper.Score = game_mode_data_keeper.Score + score;
					Instantiate(explosion_effect, this.transform.position, Quaternion.identity);
					Destroy(this.gameObject);
				}
			}
		}
	}

	public GameObject yellow_big_bullet;

	int shot_type;
	public int ShotType{
		set{shot_type  =value;}
	}
	public enum enum_shot_type{
		target_straight
	}
	float shot_speed;
	public float ShotSpeed{
		set{shot_speed = value;}
	}
	GameObject str_shot_obj;
	SEnemyShot str_enemy_shot;
	public GameFrame game_frame;
	public void SetGameFrame(GameFrame game_frame_){
		game_frame = game_frame_;
	}
	public float time_counter = 0.0f;
	void ShootShot(){
		switch(shot_type){
			case (int)enum_shot_type.target_straight:
				time_counter += Time.deltaTime;
				if(time_counter > 1.0f){
					str_shot_obj = Instantiate(yellow_big_bullet,
					new Vector3(this.transform.position.x,
					this.transform.position.y,
					SEnemyShot.BULLET_HEIGHT),
					Quaternion.identity);
					str_enemy_shot = str_shot_obj.GetComponent<SEnemyShot>();
					str_enemy_shot.SetPlayerObj(player_obj);
					str_enemy_shot.Speed = shot_speed;
					str_enemy_shot.BulletPattern = (int)SEnemyShot.bullet_enum.straight_target;
					str_enemy_shot.SetGameDispSpace(game_frame.GameDispWidthL,game_frame.GameDispWidthR,
					game_frame.GameDispHeightU, game_frame.GameDispHeightD);
					time_counter = 0.0f;
				}
				break;
		}
	}
}
