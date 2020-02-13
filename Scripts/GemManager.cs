using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GemManager : MonoBehaviour
{

    public Text m_text;
    private int m_gem;

    void Start()
    {
        m_gem = PlayerPrefs.GetInt("Gem Score");
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = "Gem : " + m_gem.ToString();
    }

    void OnTriggerEnter(Collider cool)
    {
        if (cool.gameObject.tag == "pickup")
        {
            cool.gameObject.SetActive(false);
            m_gem += 2;
            PlayerPrefs.SetInt("Gem Score",m_gem);
        }
    }
}
