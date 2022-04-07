using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerRB : MonoBehaviour {
    private Rigidbody rb;
    private GameObject game;
    private GameObject audio;
    
    public float moveSpeed = 5f;
    public float rotateSpeed = 60f;
    public float jumpSpeed = 250.0f;
    [SerializeField]
    private bool isGrounded;
    
    private float hInput, vInput;
    
    // Start is called before the first frame update
    void Start() {
        isGrounded = true;
        rb = GetComponent<Rigidbody>();
        game = GameObject.Find("_GameManager");
        audio = GameObject.Find("_SoundManager");
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update() {
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;
    }

    void FixedUpdate() {
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);
        
        if (Input.GetKey(KeyCode.Space)) {
            if (isGrounded) {
                rb.AddForce(Vector3.up * jumpSpeed);
                isGrounded = false;
            }
        }
        
        if (this.gameObject.transform.position.y < -50) {
            GameObject.Find("_GameManager").GetComponent<GameManager>().isGameOver = true;
        }
    }

    private void OnGUI() {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = 25;
        if (GameObject.Find("_GameManager").GetComponent<GameManager>().isGameOver || GameObject.Find("_GameManager").GetComponent<GameManager>().isWinner) {
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 16, Screen.height / 2 - Screen.height / 16, Screen.width / 8, Screen.height / 8), "REPLAY", myButtonStyle)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }   
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            game.GetComponent<GameManager>().count++;
            audio.GetComponent<SoundManager>().Play(1);
            game.GetComponent<GameManager>().SetCountText();
        }
    }
}