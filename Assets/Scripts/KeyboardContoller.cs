using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyboardContoller : MonoBehaviour {

    [SerializeField] string word = null;
    [SerializeField] int wordIndex = -1;
    [SerializeField] private TMP_InputField mainLogin;
    [SerializeField] private TMP_InputField mainPassword;
    [SerializeField] private TMP_InputField rankLogin;
    [SerializeField] private TMP_InputField rankPassword;
    [SerializeField] private TMP_InputField rankMail;
    [SerializeField] private TMP_InputField activeInput = null;
    [SerializeField] char[] nameChar = new char[30];
    [SerializeField] string alpha = null;
    [SerializeField] private GameObject upperCaseLetters;
    [SerializeField] private GameObject lowerCaseLetters;
    [SerializeField] private bool isShiftClicked = false;
    [SerializeField] private GameObject keyboardCanvas;
    [SerializeField] private GameObject Login;
    [SerializeField] private GameObject Register;
    [SerializeField] private GameObject Create;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Return;
    [SerializeField] private bool showButtons=true;

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

    private void Alphabet(string alphabet)
    {
        wordIndex++;
        char[] keepchar = alphabet.ToCharArray();
        nameChar[wordIndex] = keepchar[0];
        alpha = nameChar[wordIndex].ToString();
        word = word + alpha;
        Debug.Log("Adding letter: " + alpha);
        activeInput.text = word;
        isShiftClicked = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void Backspace(string alphabet)
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

    private void Shift()
    {
        if (isShiftClicked == false)
        {
            isShiftClicked = true;
        } else
        {
            isShiftClicked = false;
        }
    }

    private void MainLogin()
    {
        if (showButtons == false) { showButtons = !showButtons; };
        Buttons();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = mainLogin;
    }

    private void MainPassword()
    {
        if (showButtons == false) { showButtons = !showButtons; };
        Buttons();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = mainPassword;
    }

    private void RankLogin()
    {
        if (showButtons == false) { showButtons = !showButtons; };
        Buttons();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = rankLogin;
    }

    private void RankPassword()
    {
        if (showButtons == false) { showButtons = !showButtons; };
        Buttons();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = rankPassword;
    }

    private void RankMail()
    {
        if (showButtons == false) { showButtons = !showButtons; };
        Buttons();
        keyboardCanvas.SetActive(true);
        word = null;
        activeInput = rankMail;
    }

    private void Buttons()
    {
        Debug.Log("Current state: " + showButtons);
        showButtons = !showButtons;
        Debug.Log("Changing state to: " + showButtons);
        Login.SetActive(showButtons);
        Register.SetActive(showButtons);
        Create.SetActive(showButtons);
        Credits.SetActive(showButtons);
        Return.SetActive(showButtons);
    }

    private void KeyboardOff()
    {
        keyboardCanvas.SetActive(false);
        Buttons();
    }
}
