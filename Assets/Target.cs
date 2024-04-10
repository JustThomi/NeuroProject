using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    void Start() {
        float posX = Random.Range(-2, 8);
        float posZ = Random.Range(0, 4);

        transform.position = new Vector3(posX, -1f, posZ);
    }
}
