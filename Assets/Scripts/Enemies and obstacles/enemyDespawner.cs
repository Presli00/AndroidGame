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
        if (LineRendererScript.hit)
        {
            Collider2D collider = LineRendererScript.hit.transform.GetComponent<Collider2D>();
            if (collider == this.gameObject.GetComponent<Collider2D>())
            {
                Destroy(this.gameObject);
                AsteroidSpawner.count--;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            AsteroidSpawner.count--;
        }
    }
}
