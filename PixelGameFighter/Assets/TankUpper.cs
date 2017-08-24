using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUpper : MonoBehaviour {
	GameObject obj;
	const float speed = 0.1f;
	Vector3 vec;
	// Use this for initialization
	void Start () {
		obj = GameObject.Find("PlayerFighter");
	}
	
	// Update is called once per frame
	void Update () {
		LookAt2D(obj);
	}

	Vector3 pos;
	float angle;
	Quaternion rotation;
	void LookAt2D(GameObject target)
	{
		// 指定オブジェクトと回転さすオブジェクトの位置の差分(ベクトル)
		pos = target.transform.position - transform.position;
		// ベクトルのX,Yを使い回転角を求める
		angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
		rotation = new Quaternion();
		// 回転角は右方向が0度なので-90しています
		rotation.eulerAngles = new Vector3(0, 0, angle - 90);
		// 回転
		transform.rotation = rotation;
	}
}
