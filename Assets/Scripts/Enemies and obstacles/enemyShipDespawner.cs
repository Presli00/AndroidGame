using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShipDespawner : MonoBehaviour
{
    private Vector2 bounds;
    private Camera mainCamera;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        bounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(transform.position.y).Equals(Mathf.Round(bounds.y / 1.5f)))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Vector3 dir = player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, angle-90), 2 * Time.deltaTime);
        }
        if (LineRendererScript.hit)
        {
            Collider2D collider = LineRendererScript.hit.transform.GetComponent<Collider2D>();
            if (collider == this.gameObject.GetComponent<Collider2D>())
            {
                Destroy(this.gameObject);
                Enemies.count--;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Enemies.count--;
        }
    }
}
