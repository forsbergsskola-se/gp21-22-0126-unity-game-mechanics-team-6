using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;

    [SerializeField] private float _fireRate = 0.2f;
    [SerializeField] private float _nextFire = 0.0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)              // cool down method for shooting
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
        _nextFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}

   
