using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemies : MonoBehaviour
{
    public GameObject Explosion;
    bool isExploding = false;

    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp == 0 && !isExploding)
        {
            isExploding = true;
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }

    void Die()
    {
        GameObject fire = Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(fire, 1f);
        Destroy(gameObject);
    }
}
