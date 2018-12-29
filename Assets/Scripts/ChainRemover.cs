/*using TMPro;
using UnityEngine;

public class ChainRemover : MonoBehaviour {

    private Animator anim;
    public TMP_InputField userInput;

    void Start () {
        anim = GetComponent<Animator>();
        anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(PinPadController.codeString == (userInput.text));
        Debug.Log(PinPadController.codeString.Equals(userInput.text));
        if (userInput.text.Equals(PinPadController.codeString)) {
            anim.enabled = true ;
        }
		
	}
} */
