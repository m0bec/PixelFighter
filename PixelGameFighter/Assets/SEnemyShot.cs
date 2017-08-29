using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEnemyShot : MonoBehaviour {
	public const float BULLET_HEIGHT = -80.0f;
	GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	GameObject player_obj;
	public void SetPlayerObj(GameObject player_obj_){
		player_obj = player_obj_;
	}
	float width, height;
	float disp_width_l, disp_width_r;
	float disp_height_u, disp_height_d;
	public void SetGameDispSpace(float wl_, float wr_, float hu_, float hd_){
		disp_width_l = wl_; disp_width_r = wr_;
		disp_height_u = hu_; disp_height_d = hd_;
	}
	// Use this for initialization
	void Start () {
		width = this.GetComponent<SpriteRenderer>().bounds.size.x;
		height = this.GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	Vector3 this_pos;
	// Update is called once per frame
	void Update () {
		BulletMove();
	}
	public enum bullet_enum{
		straight_target
	}
	int bullet_pattern;
	public int BulletPattern{
		set{bullet_pattern = value;}
		get{return bullet_pattern;}
	}
	public Vector3 direction;
	float speed;
	public float Speed{
		set{speed = value;}
		get{return speed;}
	}

	bool one_time_cal = false;
	public float rad;
	void CalStraightTarget(){
		if(!one_time_cal){
			direction = player_obj.transform.position - this.transform.position;
			rad = Mathf.Atan2(direction.x, direction.y) - Mathf.PI/2;
			one_time_cal = true;
		}
	}
	void BulletMove(){
		switch(bullet_pattern){
			case (int)bullet_enum.straight_target:
				CalStraightTarget();
				this.transform.Translate(new Vector3(
				speed*Time.deltaTime*Mathf.Cos(rad),
				-speed*Time.deltaTime*Mathf.Sin(rad),0.0f
				)
				, Space.World);
				break;

		}
		CheckInField();
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Player") && !game_mode_data_keeper.PlayerDeathFlag){
			if(player_obj.GetComponent<PlayerFighter>().PlayerState == (int)PlayerFighter.player_state_name.normal){
				game_mode_data_keeper.PlayerDeathFlag = true;
				game_mode_data_keeper.DownPlayerHp();
			}
		}
	}

	void CheckInField(){
		if(this.transform.position.x > disp_width_r + width/2 ||
		this.transform.position.x < disp_width_l - width/2 ||
		this.transform.position.y > disp_height_u + height/2 ||
		this.transform.position.y < disp_height_d - height/2 ){
			Destroy(this.gameObject);		
		}
	}
}
