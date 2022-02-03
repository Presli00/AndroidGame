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
    private void Start()
    {
        mainCamera = Camera.main;
        bounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        StartCoroutine(planetSpawn());
    }
    private void Spawn(GameObject obj)
    {
        GameObject s = Instantiate(obj) as GameObject;
        s.transform.position = new Vector3(Random.Range(-bounds.x, bounds.x), bounds.y * 2, Random.Range(10, 110));
        rb = s.GetComponent<Rigidbody2D>();
        float parallaxSpeed = 1 - Mathf.Abs(transform.position.z / s.transform.position.z);
        rb.velocity = new Vector2(0f, -planetSpeed * -parallaxSpeed);
    }
    IEnumerator planetSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            foreach (GameObject obj in planets)
            {
                Spawn(obj);
            }
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
        foreach (GameObject obj in planets) {
            if (obj.gameObject.transform.position.y < bounds.y * (-2))
            {
                Destroy(obj.gameObject);
            }
        }
    }

    void Scroll()
    {
        scroll = Time.time * speed;
        Vector2 offset = new Vector2(0, scroll);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
