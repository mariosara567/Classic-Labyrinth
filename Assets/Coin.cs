using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1;
   [SerializeField, Range(0,10)] float rotationSpeed = 1;

    public int Value { get => value;}

    public void Collected()
    {
        GetComponent<Collider>().enabled = false;
        rotationSpeed *= 10;
        this.transform.DOJump(
            this.transform.position,
            1.5f,
            1,
            0.4f
        ).onComplete = SelfDestruct;
    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Rotate(0,360*rotationSpeed*Time.deltaTime,0);
    }
    
    // [SerializeField] Transform visual;
    // [SerializeField] CoinData coinData;
    // [SerializeField] BaseAnimation baseAnimation;

    // public int Value { get => coinData.value; }

    // private void Start()
    // {
    //     visual.GetComponent<Renderer>().material = coinData.material;
    //     if(baseAnimation != null)
    //         baseAnimation.Animate(visual);
        
    // }

    // public void Collected()
    // {
    //     GetComponent<Collider>().enabled = false;
        
    // }
}
