using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullets : MonoBehaviour
{

    [SerializeField] private float _laserSpeed = 10f;


    void Start()
    {

    }


    void Update()
    {
        transform.Translate(Vector3.right * _laserSpeed * Time.deltaTime);

        if (transform.position.x > 20)
        {
            if (gameObject.transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }


}