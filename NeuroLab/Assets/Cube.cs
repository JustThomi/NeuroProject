using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    public Material blue;
    public Material yellow;
    public Material green;
    public Material red;
    new Renderer renderer;

    // quick and dirty color swap
    public void change_color() {
        int new_color = Random.Range(0, 4);
        switch (new_color){
            case 0:
                renderer.material = red;
                break;
            case 1:
                renderer.material = blue;
                break;
            case 2:
                renderer.material = green;
                break;
            case 3:
                renderer.material = yellow;
                break;
        }
    }

    // guess current color
    public bool guess(string attempt) {
        switch (attempt){
            case "yellow": 
                if(renderer.material == yellow){
                    change_color();
                    return true;
                }
                break;

            case "red": 
                if(renderer.material == red){
                    change_color();
                    return true;
                }
                break;

            case "green": 
                if(renderer.material == green){
                    change_color();
                    return true;
                }
                break;

            case "blue": 
                if(renderer.material == blue){
                    change_color();
                    return true;
                }
                break;
        }
        
        Debug.Log("Oof size LARGE");
        return false;
    }

    void Start() {
        renderer = GetComponent<Renderer>();
        change_color();
    }
}
