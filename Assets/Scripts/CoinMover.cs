using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMover : MonoBehaviour
{
    [SerializeField] float speed;

    private void Start()
    {
        speed = Random.RandomRange(5, 10);  //Setting random speed for each coin.
    }
    void Update()
    {
        transform.Rotate(new Vector3(0,30,0) * speed * Time.deltaTime); //Rotation of coin.
        
    }
}
