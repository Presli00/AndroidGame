using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //Camera and other shared parameters
    private Camera mainCamera;
    private Vector2 bounds;

    //Asteroids
    public GameObject[] asteroids;
    public float speed = 2.0f;
    public float respawnTime = 1.0f;
    private Rigidbody2D rb;
    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        bounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        if (asteroids.Length > 0)
        {
            StartCoroutine(Spawner());
        }
    }
    private void Spawn(GameObject obj) //need to calculate the distance to set a size
    {
        if (count < 4)
        {
            count++;
            GameObject s = Instantiate(obj) as GameObject;
            s.transform.position = new Vector2(Random.Range(-bounds.x, bounds.x), bounds.y * 2);
            rb = s.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0f, -speed);
        }
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            GameObject obj = asteroids[Random.Range(0, asteroids.Length)];
            Spawn(obj);
        }
    }
}
