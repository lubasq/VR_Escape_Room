using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReceiver : MonoBehaviour
{
    [SerializeField] private bool locked;
    [SerializeField] private bool coinSlot;

    private Animator anim;

    public int keyVariable;
    public int keyWorth;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRayHit()
    {
        if (Input.GetButtonDown("Fire1") && !anim.GetBool("isOpen") && locked && GameVariables.keyCount == keyVariable) {
            anim.SetBool("isOpen", true);
        }
        else if (Input.GetButtonDown("Fire1") && anim.GetBool("isOpen") && locked && GameVariables.keyCount == keyVariable) {
            anim.SetBool("isOpen", false);
        }
        else if (Input.GetButtonDown("Fire1") && !anim.GetBool("isOpen") && !locked ) {
            anim.SetBool("isOpen", true);
        }
        else if (Input.GetButtonDown("Fire1") && anim.GetBool("isOpen") && !locked ) {
            anim.SetBool("isOpen", false);
        }
        else if (Input.GetButtonDown("Fire1") && coinSlot && GameVariables.gotCoin > 0) {
            anim.enabled = true;
            coinSlot = false;
        }
    }

    public void AddKey()
    {
        if (Input.GetButtonDown("Fire1")){
            GameVariables.keyCount += keyWorth;
            Destroy(gameObject);
        }
    }



}


