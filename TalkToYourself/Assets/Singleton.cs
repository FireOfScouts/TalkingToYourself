using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

	public static Singleton singleton;

	public ExampleStreamingExp STT;
	public AIMLTestChat BOT;
	public ExampleTextToSpeech TTS;

	void Awake(){
		if (Singleton.singleton == null)
			Singleton.singleton = this;
		else
			Destroy (this);
		DontDestroyOnLoad (this);

		STT = GameObject.Find ("STT").GetComponent<ExampleStreamingExp>();
		BOT = GameObject.Find ("BOT").GetComponent<AIMLTestChat> ();
		TTS = GameObject.Find ("TTS").GetComponent<ExampleTextToSpeech> ();

	}

	public void InputVoice(string text){
		if (text == null || text == "")
			return;
		string res = BOT.GetAnswer (text);
		Debug.Log (res);
		TTS.Speak (res);
	}

}
