using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
   
    public Rigidbody bombRb;
    private float throwForce = 10.0f;
    public ParticleSystem explosion;
    public GameObject bomb;
   
    // Start is called before the first frame update
    void Start()
    {
        bombRb = GetComponent<Rigidbody>();
        explosion = GetComponent<ParticleSystem>();
        explosion.Pause();
        Debug.Log("Partical Paused");
    }

    // Update is called once per frame
    void Update()
    {
        BombForce();
        StartCoroutine(BombTimeOut());
        Destroy(gameObject, 3.0f);
    }

    // Coroutine to apply Powerup Timer
    IEnumerator BombTimeOut()
    {
        yield return new WaitForSeconds(3);
        explosion.Play();
        Destroy(bomb);
    }

    // On Trigger Bomb Blast
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(bomb);
            explosion.Play();
        }
    }

    // Add Force to Bomb
    void BombForce()
    {
        bombRb.AddForce(transform.forward * throwForce * Time.deltaTime, ForceMode.Impulse);
    }
}
