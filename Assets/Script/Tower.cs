using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public GameObject _upgrade = null;
    private GameObject upgrade { get { return _upgrade; } }

    private float fireRate { get; set; } = 0.1f;
    private float currentFireRate { get; set; } = 0.0f;

    private List<Enemie> enemies { get; set; } = null;





    private void Start()
    {
        enemies = new List<Enemie>();
    }

    private void Update()
    {
        
    }

    public void Upgrade()
    {
        if (upgrade == null)
        {
            return;
        }
        Instantiate(upgrade, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemie enemie = other.GetComponent<Enemie>();
        if(enemie != null)
        {
            enemies.Add(enemie);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemie enemie = other.GetComponent<Enemie>();
        if (enemie != null)
        {
            enemies.Remove(enemie);
        }
    }
}
