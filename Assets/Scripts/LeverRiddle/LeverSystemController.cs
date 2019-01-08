using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public class LeverSystemController : MonoBehaviour
{

    public List<GameObject> lightCandles = new List<GameObject>();
    public List<GameObject> putOutCandles = new List<GameObject>();

    private Animator anim;
    [SerializeField] private int whichLever;
    [SerializeField] private bool lowState;
    [SerializeField] private bool upState;

    void Start()
    {
        anim = GetComponent<Animator>();
        whichLever -= 1 ;
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("isOpen"))
        {
            GameVariables.correctLeverState[whichLever] = upState;
            foreach (var lights in lightCandles)
                lights.SetActive(true);
            foreach (var lights in putOutCandles)
                lights.SetActive(false);
        }
        else
        {
            GameVariables.correctLeverState[whichLever] = lowState;
            foreach (var lights in lightCandles)
                lights.SetActive(false);
            foreach (var lights in putOutCandles)
                lights.SetActive(true);
        }  
    }
}