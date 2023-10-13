using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HelpText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;

    List<string> textsToWrite = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(writeText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static HelpText GetHelpText()
    {
        return GameObject.Find("HelpText").GetComponent<HelpText>();
    }

    public void writeUIText(string text)
    {
        textsToWrite.Add(text);
    }

    IEnumerator writeText()
    {
        if (textsToWrite.Count > 0)
        {
            string text = textsToWrite[0];
            while(text.Length > 0)
            {
                uiText.text += text.Substring(0, 1);
                text = text.Substring(1, text.Length - 1);
                yield return new WaitForSeconds(0.01f);
            }

            if(text.Split(' ').Length > 9)
            {
                yield return new WaitForSeconds(7f);
            }
            else if (text.Split(' ').Length > 6)
            {
                yield return new WaitForSeconds(5f);
            }
            else
            {
                yield return new WaitForSeconds(3f);
            }

            uiText.text = "";
            textsToWrite.RemoveAt(0);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }

        StartCoroutine(writeText());
    }
}
