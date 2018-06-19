using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamiloCredentials : MonoBehaviour {

	Singleton s;
	void Start(){
		s = Singleton.singleton;
		s.STTurl = "https://stream.watsonplatform.net/speech-to-text/api";
		s.STTpassword = "HXZaCSKMZIKc";
		s.STTusername = "0bab0e61-62c7-438b-ae18-93a8118cff82";
		s.TTSurl = "https://stream.watsonplatform.net/text-to-speech/api";
		s.TTSpassword = "7NUh44AWpbQI";
		s.TTSusername = "7debb570-2fe2-45bb-a27e-41978179169c";
		s.InsertValues ();
	}
}
