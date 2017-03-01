using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DrawGM : MonoBehaviour {

	public GameObject baseDot;
	public GameObject square;
	public GameObject triangle;
	public GameObject Zsign;
	public GameObject Circle;

	public static int quest;
	public static int result;

	public Transform baseDot2;
	public KeyCode mouseLeft;
	public static int Score;
	public static float TimeLeft;
	public static int Lvl;
	public Text ScoreText;
	public Text TimeText;

	// Use this for initialization
	void Start () {
		Score = 0;
		Lvl = 1;
		TimeLeft = 10f;
		result = 0;
		NewQuest();
		NewImage();
	}

	public static int NewQuest()
	{
		quest = Random.Range(0, 4);
		Debug.ClearDeveloperConsole();
		Debug.Log("Quest= " + quest);
		return quest;
	}

	public void NewImage()
	{
		square.SetActive(false);
		triangle.SetActive(false);
		Zsign.SetActive(false);
		Circle.SetActive(false);
		switch (quest)
		{
		case 0:
			square.SetActive(true);
			break;
		case 1:
			triangle.SetActive(true);
			break;
		case 2:
			Circle.SetActive(true);
			break;
		case 3:
			Zsign.SetActive(true);
			break;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(result==1)
		{
			result = 0;
			NewQuest();
			NewImage();
		}
		ScoreText.text = "Score: " + Score.ToString();
		TimeLeft -= Time.deltaTime;
		TimeText.text = " " + TimeLeft.ToString();
		if(TimeLeft<0)
		{
			Application.LoadLevel(2);
		}
		Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

		if (Input.GetKey(mouseLeft))
		{

			Object.Destroy(Instantiate(baseDot, objPosition, baseDot2.rotation), 0.5f);
		}
	}
}