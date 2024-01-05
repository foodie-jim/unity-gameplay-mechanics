using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.enemyRb = GetComponent<Rigidbody>();
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (this.player.transform.position - this.transform.position).normalized;
        this.enemyRb.AddForce(lookDirection * this.speed);

        if (this.transform.position.y < -10) {
            Destroy(this.gameObject);
        }
    }
}
