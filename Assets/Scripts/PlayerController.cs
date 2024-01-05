using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;

    public float speed = 5.0f;
    public bool hasPowerup;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        this.playerRb = GetComponent<Rigidbody>();
        this.focalPoint = GameObject.Find("Focal Point");
        this.hasPowerup = false;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        this.playerRb.AddForce(this.focalPoint.transform.forward * this.speed * forwardInput);
        this.powerupIndicator.transform.position = this.transform.position - new Vector3(0, 0.5f, 0);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Powerup")) {
            this.hasPowerup = true;
            this.powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(this.PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine() {

        yield return new WaitForSeconds(7);
        this.hasPowerup = false;
        this.powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)  {

        if (collision.gameObject.CompareTag("Enemy") && this.hasPowerup) {
            Rigidbody enemyRigdbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position);

            enemyRigdbody.AddForce(awayFromPlayer * 15.0f, ForceMode.Impulse);
        }
    }
}
