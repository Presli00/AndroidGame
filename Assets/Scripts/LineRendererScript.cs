using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public GameObject ship;
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

        Vector2 direction = topBound - (Vector2) transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude);
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}
