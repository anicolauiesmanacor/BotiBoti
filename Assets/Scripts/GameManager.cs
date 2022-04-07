using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager: MonoBehaviour {
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject lossTextObject;

    private GameObject audio;
    public bool isGameOver;
    public bool isWinner;
    
    public int count;

    public bool level1Clear;
    private GameObject wallsL1;
    public bool level2Clear;
    /*
    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
		if (objs.Length > 1) {
			Destroy(this.gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(this.gameObject);
    }
*/

    void Start() {
        //Inicialització d'estats a false
        isWinner = isGameOver = false;
        level1Clear = level2Clear = false;
        
        //Murs Level1
        wallsL1 = GameObject.Find("WallsL1");
        
        //HUD info
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        lossTextObject.SetActive(false);

        //Audio
        audio = GameObject.Find("_SoundManager");
        audio.GetComponent<SoundManager>().playGameMusic();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (level1Clear) 
            if (wallsL1.transform.position.y > -1.75)
                wallsL1.transform.Translate(new Vector3(0,-0.3f * Time.fixedDeltaTime,0));
        
        if (isGameOver) {
            lossTextObject.SetActive(true);
            Time.timeScale = 0;
            audio.GetComponent<SoundManager>().Play(4);
        }
    }

    public void SetCountText() {
        countText.text = "Count: " + count.ToString();

        if (count == 8)
            level1Clear = true;
        else if (count == 14)
            level2Clear = true;
        else if (count > 14)
            youAreTheWinner();
    }
    
    void youAreTheWinner() {
        isWinner = true;
        winTextObject.SetActive(true);
        Time.timeScale = 0;
        audio.GetComponent<SoundManager>().Play(3);
    }
}