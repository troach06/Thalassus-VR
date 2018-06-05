using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UnityEngine.XR.InputTracking.Recenter();
        StartCoroutine(AnimText());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator AnimText()
    {
        iTween.ScaleBy(gameObject, new Vector3(3, 3, 3), 5);
        iTween.MoveBy(gameObject, new Vector3(0, 0, -5), 5);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("GreeceVideo");
    }
    }
