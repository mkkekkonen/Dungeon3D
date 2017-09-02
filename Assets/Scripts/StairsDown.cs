using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class StairsDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            MapManager.Instance.CurrentMapIndex--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
