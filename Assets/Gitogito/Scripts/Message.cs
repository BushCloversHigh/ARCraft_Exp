using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{

    private Image img;
    private Text text;

    private void Awake ()
    {
        img = transform.Find ("Message").GetComponent<Image> ();
        text = img.GetComponentInChildren<Text> ();
        img.gameObject.SetActive (false);
    }

    private IEnumerator cor;
    public void Show (string message)
    {
        text.text = message;
        if (cor != null)
        {
            StopCoroutine (cor);
        }
        cor = Showning (message);
        StartCoroutine (cor);
    }

    private IEnumerator Showning (string message)
    {
        img.gameObject.SetActive (true);
        float a = text.color.a;
        while (a <= 1f)
        {
            a += Time.deltaTime * 5f;
            ChangeAlpha (a);
            yield return null;
        }
        yield return new WaitForSeconds (2.5f);
        while (a >= 0f)
        {
            a -= Time.deltaTime * 5f;
            ChangeAlpha (a);
            yield return null;
        }
        cor = null;
        img.gameObject.SetActive (false);

    }

    private void ChangeAlpha (float a)
    {
        Color color = img.color;
        color.a = a * 0.8f;
        img.color = color;

        color = text.color;
        color.a = a;
        text.color = color;
    }
}
