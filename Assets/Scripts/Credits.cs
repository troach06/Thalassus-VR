using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        UnityEngine.XR.InputTracking.Recenter();
        StartCoroutine(AnimText());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator AnimText()
    {
        
        iTween.MoveBy(gameObject, iTween.Hash("easetype", iTween.EaseType.linear, "amount", new Vector3(0, 250, 0), "time", 10));
        yield return new WaitForSeconds(11);
        SceneManager.LoadScene("Title");
    }
}
