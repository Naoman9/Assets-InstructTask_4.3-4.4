using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2 : MonoBehaviour
{

    public Rigidbody bombRb;
    private float throwForce = 10.0f;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        bombRb = GetComponent<Rigidbody>();
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
      
        Destroy(bomb);
    }

    // On Trigger Bomb Blast
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(bomb);
        }
    }

    // Add Force to Bomb
    void BombForce()
    {
        bombRb.AddForce(transform.forward * throwForce * Time.deltaTime, ForceMode.Impulse);
    }
}
