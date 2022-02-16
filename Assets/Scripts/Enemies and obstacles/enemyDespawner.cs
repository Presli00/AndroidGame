using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDespawner : MonoBehaviour
{
    private Vector2 bounds;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        bounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bounds.y * (-2))
        {
            AsteroidSpawner.count--;
            Destroy(this.gameObject);
        }
    }
}
