﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
  public GameObject bullet;
  private Transform playerPos;

  // Start is called before the first frame update
  void Start()
  {
    playerPos = GetComponent<Transform>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Instantiate(bullet, playerPos.position, Quaternion.identity);
    }
  }
}
