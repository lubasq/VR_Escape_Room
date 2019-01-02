using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReceiver : MonoBehaviour
{
    [SerializeField] private bool locked;
    [SerializeField] private bool coinSlot;
    private bool errorRemover = true;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if(coinSlot) {
            anim.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRayHit()
    {   
        if (Input.GetButtonDown("Fire1") && coinSlot && GameVariables.gotCoin > 0) {
            anim.enabled = true;
            GameVariables.gotCoin -= 1;
            coinSlot = false;
            errorRemover = false;
        }
        if (errorRemover && !coinSlot) { 
            if (Input.GetButtonDown("Fire1") && !anim.GetBool("isOpen") && locked && GameVariables.gotKey) {
                anim.SetBool("isOpen", true);
            }
            else if (Input.GetButtonDown("Fire1") && anim.GetBool("isOpen") && locked && GameVariables.gotKey) {
                anim.SetBool("isOpen", false);
            }
            else if (Input.GetButtonDown("Fire1") && !anim.GetBool("isOpen") && !locked) {
                anim.SetBool("isOpen", true);
            }
            else if (Input.GetButtonDown("Fire1") && anim.GetBool("isOpen") && !locked) {
                anim.SetBool("isOpen", false);
            }
        }

    }

    public void AddKey()
    {
        if (Input.GetButtonDown("Fire1")){
            GameVariables.gotKey = true;
            Destroy(gameObject);
        }
    }



}


