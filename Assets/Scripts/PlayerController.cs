using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public int health = 100;

  public float BASE_MOVEMENT_SPEED = 5.0f;
  public float movementSpeed;
  public Vector2 movementDirection;

  public Rigidbody2D body;

  // Start is called before the first frame update
  void Start()
  {
    body = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    ProcessInputs();
  }

  void FixedUpdate()
  {
    Move();
  }

  void ProcessInputs()
  {
    movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
    movementDirection.Normalize();
  }

  void Move()
  {
    body.velocity = movementDirection * movementSpeed * BASE_MOVEMENT_SPEED;
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
    Application.LoadLevel(Application.loadedLevel);
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    Debug.Log(collider.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    if (collider.gameObject.CompareTag("Enemy"))
    {
      GameObject enemy = collider.gameObject;
      Enemy enemyScript = enemy.GetComponent<Enemy>();
      Debug.Log("Enemy damage: " + enemyScript.damage);
      TakeDamage(enemyScript.damage);
      Destroy(enemy);
    }
  }
}
