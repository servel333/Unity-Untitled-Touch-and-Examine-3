using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    private Queue<string> paragraphs;

    public Text bodyText;
    public Text titleText;

    void Start()
    {
        paragraphs = new Queue<string>();

        if (bodyText)
        {
            bodyText.gameObject.SetActive(false);
        }

        if (titleText)
        {
            titleText.gameObject.SetActive(false);
        }
    }
}
