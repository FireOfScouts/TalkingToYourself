using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleton : MonoBehaviour {

	public static Singleton singleton;

	public ExampleStreamingExp STT;
	public AIMLTestChat BOT;
	public ExampleTextToSpeech TTS;

	GameObject checkmark;
	public string STTurl, STTpassword, STTusername, TTSurl, TTSpassword, TTSusername;

	Text timeT , dateT;

	void Awake(){
		if (Singleton.singleton == null)
			Singleton.singleton = this;
		else
			Destroy (this);
		DontDestroyOnLoad (this);

		timeT = GameObject.Find ("TimeText").GetComponent<Text> ();
		dateT = GameObject.Find ("DateText").GetComponent<Text> ();
		checkmark = GameObject.Find ("Check");
		StartCoroutine (ShowCheck());

		STT = GameObject.Find ("STT").GetComponent<ExampleStreamingExp>();
		BOT = GameObject.Find ("BOT").GetComponent<AIMLTestChat> ();
		TTS = GameObject.Find ("TTS").GetComponent<ExampleTextToSpeech> ();
	}

	void Update(){
		string[] tA = System.DateTime.Now.ToString ().Split (new char[1]{' '});
		string[] tAD = tA[0].Split('/');
		timeT.text = tA[1];
		dateT.text = tAD [0] + "/" + tAD [1] + "/" + (int.Parse(tAD [2]) + 20).ToString();

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	public void InsertValues(){
		TTS._url = TTSurl;
		TTS._username = TTSusername;
		TTS._password = TTSpassword;
		STT._url = STTurl;
		STT._username = STTusername;
		STT._password = STTpassword;
		STT.StartSTT ();
		TTS.StartTTS ();
	}

	public void InputVoice(string text){
		if (text == null || text == "")
			return;
		StartCoroutine (ShowCheck());
		string res = BOT.GetAnswer (text);
		Debug.Log (res);
		TTS.Speak (res);
	}

	public IEnumerator ShowCheck(){
		checkmark.SetActive (true);
		yield return new WaitForSeconds (1.5f);
		checkmark.SetActive (false);
	}
}