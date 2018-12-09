using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class KeyboardContoller : MonoBehaviour {

    string word = null;
    int wordIndex = -1;
    public TMP_InputField mainLogin;
    public TMP_InputField mainPassword;
    public TMP_InputField rankLogin;
    public TMP_InputField rankPassword;
    public TMP_InputField rankMail;
    [SerializeField] private TMP_InputField activeInput = null;
    char[] nameChar = new char[30];
    string alpha = null;
    public GameObject upperCaseLetters;
    public GameObject lowerCaseLetters;
    public bool isShiftClicked = false;
    public GameObject keyboardCanvas;
    public GameObject Login;
    public GameObject Register;
    public GameObject Create;
    public GameObject Credits;
    public GameObject Return;

    private void Start()
    {
        keyboardCanvas.SetActive(false);
        lowerCaseLetters.SetActive(true);
        upperCaseLetters.SetActive(false);
    }

    private void Update()
    {
    if (isShiftClicked == true)
        {
            lowerCaseLetters.SetActive(false);
            upperCaseLetters.SetActive(true);
        }    else
        {
            lowerCaseLetters.SetActive(true);
            upperCaseLetters.SetActive(false);
        };
    }

    public void Alphabet(string alphabet)
    {
        wordIndex++;
        char[] keepchar = alphabet.ToCharArray();
        nameChar[wordIndex] = keepchar[0];
        alpha = nameChar[wordIndex].ToString();
        word = word + alpha;
        Debug.Log("Adding letter: " + alpha);
        activeInput.text = word;
        isShiftClicked = false;
    }

    public void Backspace(string alphabet)
    {
        alpha = null;
        Debug.Log("Deleting letter: " + alpha);
        if (wordIndex >=0)
        {
            wordIndex--;
            for(int i = 0; i < wordIndex + 1; i++)
            {
                alpha = alpha + nameChar[i].ToString();
            }
            word = alpha;
            activeInput.text = word;
        }
    }

    public void Shift()
    {
        if (isShiftClicked == false)
        {
            isShiftClicked = true;
        } else
        {
            isShiftClicked = false;
        }
    }

    public void MainLogin()
    {
        ButtonsOff();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = mainLogin;
    }

    public void MainPassword()
    {
        ButtonsOff();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = mainPassword;
    }

    public void RankLogin()
    {
        ButtonsOff();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = rankLogin;
    }

    public void RankPassword()
    {
        ButtonsOff();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = rankPassword;
    }

    public void RankMail()
    {
        ButtonsOff();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = rankMail;
    }

    public void ButtonsOff()
    {
    Login.SetActive(false);
    Register.SetActive(false);
    Create.SetActive(false);
    Credits.SetActive(false);
    Return.SetActive(false);
    }

    public void ButtonsOn()
    {
        Login.SetActive(true);
        Register.SetActive(true);
        Create.SetActive(true);
        Credits.SetActive(true);
        Return.SetActive(true);
    }

    public void KeyboardOff()
    {
        keyboardCanvas.SetActive(false);
        ButtonsOn();
    }
}
