using UnityEngine;
using UnityEngine.UI;
public class ButtonTranslate : MonoBehaviour
{
    public string ID;
    public Text myText;
    private void Awake()
    {
        Debug.Log(LocalizationManager.Instance.gameObject);
        LocalizationManager.Instance.ChangeLanguage += ChangeLang;
    }

    void ChangeLang()
    {
        Debug.Log("ChangeLang");
      //if (myText != null) 
          myText.text = LocalizationManager.Instance.GetTranslate(ID);
    }
}
