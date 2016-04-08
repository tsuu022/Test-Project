using UnityEngine;
using System.Collections;

public class MapDynamics : MonoBehaviour {

	public float minGlossiness = 0.0f;
	public float maxGlossiness = 0.9f;
	public float glossinessSpeed = 0.5f;

	public float smallStarsMoveSpeed = 0.25f;

	//MOVE
	private static float smallStarsMoveCount = 5.0f;
	private static float smallStarsScaleCount = 200.0f + 5.0f; //200 - def. value
	private Vector3 smallStarsPos1 = new Vector3(-smallStarsMoveCount, 200.0f, -smallStarsMoveCount);
	private Vector3 smallStarsPos2 = new Vector3(smallStarsMoveCount, smallStarsScaleCount, smallStarsMoveCount);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform child in transform)
		{
			if (child.name == "SmallStarsPlane") {
				child.GetComponent<Renderer> ().material.SetFloat ("_Glossiness", minGlossiness + Mathf.PingPong (Time.time * glossinessSpeed, maxGlossiness));
				child.transform.position = Vector3.Lerp (smallStarsPos1, smallStarsPos2, Mathf.PingPong(Time.time * smallStarsMoveSpeed,  1.0f));
			}
			if (child.name == "BigStarsPlane") {
				child.GetComponent<Renderer> ().material.SetFloat ("_Glossiness", minGlossiness + Mathf.PingPong (Time.time * glossinessSpeed, maxGlossiness));
			}
		}
	}
}
