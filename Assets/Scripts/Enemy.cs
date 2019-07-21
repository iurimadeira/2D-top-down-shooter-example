using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  private Rigidbody2D body;
  public int health = 100;
  public int damage = 10;

  public GameObject player;
  private Rigidbody2D playerBody;

  public Vector2 direction;
  public float movementSpeed = 5.0f;

  // Start is called before the first frame update
  void Start()
  {
    body = GetComponent<Rigidbody2D>();
    playerBody = player.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    Move();
  }

  void Move()
  {
    float step = movementSpeed * Time.deltaTime;
    transform.position = Vector2.MoveTowards(transform.position, playerBody.position, step);
  }

  void TakeDamage(int amount)
  {
    health -= amount;

    if (health <= 0)
    {
      Die();
    }
  }

  void Die()
  {
    Destroy(gameObject);
  }

  // Callbacks

  void OnTriggerEnter2D(Collider2D collider)
  {
    Debug.Log(collider.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    if (collider.gameObject.CompareTag("Projectile"))
    {
      GameObject projectile = collider.gameObject;
      Projectile projectileScript = projectile.GetComponent<Projectile>();
      Debug.Log("Projectile damage: " + projectileScript.damage);
      TakeDamage(projectileScript.damage);
      Destroy(projectile);
    }
  }
}
