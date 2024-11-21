using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckPassword : MonoBehaviour
{
    private InputField inputTextField;

    private void Start()
    {
        inputTextField = GetComponent<InputField>();
    }

    public void CheckPasswordAndLoadScene()
    {
        if (inputTextField.text == "11:11")
        {

        }
    }
}
