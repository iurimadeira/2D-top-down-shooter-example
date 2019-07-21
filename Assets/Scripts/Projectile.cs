using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public Rigidbody2D body;

  private Vector2 target;
  private Vector2 direction;
  public float projectileSpeed = 10.0f;

  public int damage = 30;

  // Start is called before the first frame update
  void Start()
  {
    body = GetComponent<Rigidbody2D>();
    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    direction = target - (Vector2)transform.position;
    direction.Normalize();
    Destroy(gameObject, 5);
  }

  // Update is called once per frame
  void Update()
  {
    body.velocity = direction * projectileSpeed;
  }
}
