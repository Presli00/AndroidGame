using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 pos, dir;
    private Vector2 bounds;
    private float objWidth, objHeight;
    private Rigidbody2D rb;
    public float moveSpeed;
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objWidth = transform.GetComponent<CapsuleCollider2D>().bounds.size.x / 2;
        objHeight = transform.GetComponent<CapsuleCollider2D>().bounds.size.y / 2;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            pos = Camera.main.ScreenToWorldPoint(touch.position);
            pos.z = 0;
            dir = (pos - transform.position);
            rb.velocity = new Vector2(dir.x, dir.y) * moveSpeed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bounds.x * -1 + objWidth, bounds.x - objWidth), Mathf.Clamp(transform.position.y, bounds.y * -1 + objHeight, bounds.y - objHeight), transform.position.z);
            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
        healthBar.GetComponent<Transform>().position = new Vector2(transform.position.x - 0.4f, transform.position.y);
        if (currentHealth == 0)
        {
            this.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
        }
    }



    //Work in progress
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        AsteroidSpawner.count--;
        TakeDamage(20);
    }
    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
