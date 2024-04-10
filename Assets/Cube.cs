using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cube : MonoBehaviour {
    public float moveSpeed = 20f;
    public TextMesh victoryText;
    
    public float leftRight = 0;
    public float upDown = 0;
    
    public void moveCube(string attempt) {

        switch (attempt){
            case "left": 
                upDown = 0;
                leftRight = -1;
                break;

            case "right": 
                upDown = 0;
                leftRight = 1;
                break;

            case "up": 
                upDown = 1;
                leftRight = 0;
                break;

            case "down":
                upDown = -1;
                leftRight = 0;
                break;
        }
    }


    void Update() {
        // Move cube
        Vector3 movement = new Vector3(leftRight, 0f, upDown) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        // reset for easier gameplay
        leftRight = 0;
        upDown = 0;
    }
    void OnTriggerEnter(Collider other) {
        Debug.Log("Rigidbody entered: " + other.gameObject.name);
        StartCoroutine(ResetSceneAfterDelay(2f));
    }

    IEnumerator ResetSceneAfterDelay(float delay) {
        victoryText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
