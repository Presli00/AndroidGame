using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed = 10f;
    public float planetSpeed = 2.0f;
    private MeshRenderer renderer;
    private float scroll;

    public GameObject[] planets;
    public float respawnTime = 1.0f;
    private Vector2 bounds;
    private Camera mainCamera;
    private Rigidbody2D rb;
    public static int count = 0;
    private void Start()
    {
        mainCamera = Camera.main;
        bounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        if (planets.Length > 0)
        {
            StartCoroutine(planetSpawn());
        }
    }
    private void Spawn(GameObject obj) //need to calculate the distance to set a size
    {
        if (count != 2)
        {
            count++;
            GameObject s = Instantiate(obj) as GameObject;
            s.transform.position = new Vector3(Random.Range(-bounds.x, bounds.x), bounds.y * 2, Random.Range(10, 110));
            rb = s.GetComponent<Rigidbody2D>();
            string n = obj.name;
            SpriteRenderer sr = s.GetComponent<SpriteRenderer>();
            float parallaxSpeed = 1 - Mathf.Abs(transform.position.z / s.transform.position.z);
            float alterSize = Mathf.Abs(transform.position.z - s.transform.position.z);
            if (obj.name == "Galaxy")
            {
                rb.velocity = new Vector2(0f, parallaxSpeed);
                sr.size = new Vector2(5 + sr.size.x, 5 + sr.size.y);
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.7f);
            }
            else
            {
                rb.velocity = new Vector2(0f, -planetSpeed * -parallaxSpeed);
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alterSize * 0.5f);
                sr.size = new Vector2(5 + Mathf.Abs(alterSize / sr.size.x), 5 + Mathf.Abs(alterSize / sr.size.y));
            }
        }
    }
    IEnumerator planetSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            GameObject obj = planets[Random.Range(0, planets.Length)];
            Spawn(obj);
        }
    }
    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        scroll = Time.time * speed;
        Vector2 offset = new Vector2(0, scroll);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
