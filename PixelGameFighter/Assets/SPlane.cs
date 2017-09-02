using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlane : MonoBehaviour {
	public Vector3 size;
	public Vector3 Size{
		get{return size;}
	}
	Quaternion rotate;
	public Quaternion Rotate{
		get{return rotate;}
	}
	public float width, height;
	public float Width{
		get{return width;}
	}
	public float Height{
		get{return height;}
	}
	float move_speed = 5.0f;
	public float MoveSpeed{
		set{move_speed = value;}
		get{return move_speed;}
	}
	// Use this for initialization
	public virtual void Start () {
		size = this.transform.position;
		width = this.GetComponent<Renderer>().bounds.size.x;
		height = this.GetComponent<Renderer>().bounds.size.y;
		rotate = this.transform.rotation;
	}
	
	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	public bool CheckStop(){
		return game_mode_data_keeper.Stop;
	}

	// Update is called once per frame
	public virtual void Update () {
		transform.position -= new Vector3(0.0f, move_speed, 0.0f);
	}
}
