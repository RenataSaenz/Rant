using UnityEngine;
using UnityEngine.UI;
public class Translator : MonoBehaviour
{
    public string ID;
    public Text myText;
    private void Awake()
    {
        LocalizationManager.Instance.ChangeLanguage += ChangeLang;
    }

    void ChangeLang()
    {
      //if (myText != null) 
          myText.text = LocalizationManager.Instance.GetTranslate(ID);
    }
}
