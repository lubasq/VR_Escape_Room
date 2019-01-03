using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightManager : MonoBehaviour {

    public GameObject firstSack;
    public GameObject secondSack;
    public GameObject thirdSack;
    public GameObject fourthSack;

    private Vector3 firstSackPosition;
    private Vector3 secondSackPosition;
    private Vector3 thirdSackPosition;
    private Vector3 fourthSackPosition;

    void Start () {
        firstSackPosition = firstSack.transform.position;
        secondSackPosition = secondSack.transform.position;
        thirdSackPosition = thirdSack.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("1" + firstSackPosition);
        Debug.Log("2" + secondSackPosition);
        Debug.Log("3" + thirdSackPosition);
        Debug.Log("4" + fourthSackPosition);
    }
}
