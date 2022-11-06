using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //Miscellaneous
    private Camera mainCamera;
    private Vector2 bounds;

    //Enemie ships
    public GameObject[] enemies;
    public GameObject[] bosses;
    public float speed = 2f;
    public float respawnTime = 0.5f;
    private Rigidbody2D rb;
    public static int count = 0;



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        bounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        if (enemies.Length > 0)
        {
            StartCoroutine(Spawner());
        }
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            GameObject obj = enemies[Random.Range(0, enemies.Length)];
            Spawn(obj);
        }
    }
    private void Spawn(GameObject obj)
    {
        if (count < 3)
        {
            count++;
            GameObject s = Instantiate(obj) as GameObject;
            s.transform.position = new Vector2(Random.Range(-bounds.x, bounds.x), bounds.y * 2);
            rb = s.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0f, -speed);
        }
    }

    private void Update()
    {
        if (Score.score % 2000 == 0)
        {
            StopCoroutine(Spawner());
            count = 0;
            if (count < 1)
            {
                count++;
                GameObject obj = bosses[Random.Range(0, enemies.Length)];
                obj.transform.position = new Vector2(Random.Range(-bounds.x, bounds.x), bounds.y * 2);
                rb = obj.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(0f, -speed);
                if (!obj.active) {
                    count = 0;
                    StartCoroutine(Spawner());
                }
            }
        }
    }
}

