using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayJsonParser : MonoBehaviour {

	public static T[] ParseArray<T>(string[] temp) {
		List<T> returnThis = new List<T>();
		string kek;
		for (int i = 0; i < temp.Length; i++) {
			kek = temp [i];
			if (i % 2 == 0) {
				kek = kek + "}";
			} else {
				kek = "{" + kek;
			}
			returnThis.Add (JsonUtility.FromJson<T>(kek));
		}
		return returnThis.ToArray ();
	}
}
