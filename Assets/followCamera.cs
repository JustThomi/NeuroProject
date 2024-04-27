using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform follow;
    public Transform camera;
    public float yOffset = 8.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camera.position = new Vector3(follow.position.x, follow.position.y + yOffset, follow.position.z);
    }
}
