using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadProfile : MonoBehaviour {

	public int profileNumber;
	public InputField theInputField;
	public InputField newPersonField;
	private string nothing;
	private string comparator;
	public GameObject makeNew;
	public GameObject newPersonAlert;
	public Text newPersonAlertText;
	private Person newPerson;
	void Start(){
		profileNumber = 0;
		nothing = "{\"detail\":\"Not found.\"}";
	}
	public void GameLoad() {
		if (theInputField.text != "") {
			string theText = theInputField.text;
			profileNumber = int.Parse (theInputField.text);
			WWW request = new WWW ("http://127.0.0.1:8000/game/person/" + theInputField.text + "/?format=json");
			StartCoroutine (OnResponse (request));
			if (nothing.Equals(comparator)) {
				makeNew.SetActive(true);
			} else {
				GameStart (profileNumber);
			}
			//SceneManager.LoadScene ("SampleScene");
		} else {
			profileNumber = 0;
		}
			
	}

	public void newProfile(){
		Person person = new Person ();
		person.health = Constants.PERSON_BASE_HEALTH;
		person.level = Constants.PERSON_BASE_LEVEL;
		person.name = newPersonField.text;
		string myData = JsonUtility.ToJson (person);
		newPerson = new Person ();
		StartCoroutine (waitFor(myData));
		//GameStart(profileNumber);
		gameObject.SetActive(false);
		Debug.Log (newPerson.id);
		Debug.Log (newPerson.name);
		newPersonAlertText.text = "new ID: " + newPerson.id.ToString();
		newPersonAlert.SetActive (true);
	}

	private IEnumerator waitFor(string myData){
		//int waitboy = 0;

		var uwr = new UnityWebRequest(Constants.BASE_URL + "person/", "POST");
		byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(myData);
		uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
		uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		uwr.SetRequestHeader("Content-Type", "application/json");

		//Send the request then wait here until it returns
		uwr.SendWebRequest();

		int waitboy = 0;
		while (!uwr.isDone) {
			waitboy = 1;
		}
		if (uwr.isDone) {
			Debug.Log (uwr.downloadHandler.text);
			newPerson = JsonUtility.FromJson<Person>( uwr.downloadHandler.text);
		}
		//Debug.Log ("aldkjakjwn");
		yield return uwr;



		//Debug.Log(myData);
		//UnityWebRequest www = UnityWebRequest.Post (Constants.BASE_URL + "person/",myData);
		//www.SetRequestHeader ("Content-Type","application/json");
		//yield return www.SendWebRequest ();
		//Debug.Log (www.error);

	}

	public void GameStart(int id) {
		//Constants.PERSON_ID = id;
		SceneManager.LoadScene ("SampleScene");
	}


	private IEnumerator OnResponse(WWW req){

		int waitboy = 0;
		while (!req.isDone) {
			waitboy = 1;
		}
		if (req.isDone) {
			comparator = req.text;
		}
		yield return req;

	}
}
