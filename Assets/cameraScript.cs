using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 targetPos;
    public float zoom;
    private Camera cameraComp;
    void Start()
    {
        cameraComp = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
        cameraComp.orthographicSize = zoom;

    }
}
