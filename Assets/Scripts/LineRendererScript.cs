using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public GameObject ship;
    public static RaycastHit2D hit;
    float screenHeight;
    private void Start()
    {
        screenHeight = cam.orthographicSize;
        lineRenderer.transform.rotation = firePoint.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        updateLaser();
    }

    void updateLaser()
    {
        Vector2 topBound = new Vector2(firePoint.position.x, screenHeight);
        lineRenderer.SetPosition(0, firePoint.transform.position);
        lineRenderer.SetPosition(1, topBound);
        Vector2 direction = topBound - (Vector2)transform.position;
        hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude);
        /*if (hit)
        {
            Collider2D asteroid = hit.transform.GetComponent<Collider2D>();
            if (asteroid != null)
            {
                Destroy(asteroid.gameObject);
                AsteroidSpawner.count--;
            }
            Collider2D enemy = hit.transform.GetComponent<Collider2D>();
            if (enemy != null)
            {
                Destroy(enemy.gameObject);
                Enemies.count--;
            }
            lineRenderer.SetPosition(1, hit.point);
        }*/
    }
}
