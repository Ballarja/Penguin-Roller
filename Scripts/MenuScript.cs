using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject thepanel;
    public void taptoplay()
    {
        thepanel.SetActive(false);
        Application.LoadLevel("GamePlayScene");
    }
}
