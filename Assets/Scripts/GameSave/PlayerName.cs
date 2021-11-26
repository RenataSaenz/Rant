using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{ 
    public GameObject setNameCanvas;
    public string nameOfPlayer;

    public Text inputText;
    public TextMeshProUGUI score;

   private void Start()
   {
       setNameCanvas.SetActive(true);
       score.text = PointsContoller.totalScore.ToString();
   }

   private void Update()
   {
       if (inputText!=null) nameOfPlayer = inputText.text;
   }

   public void SetName()
   {
       PointsContoller.playerName = nameOfPlayer;
       SaveGame.instance.scoreListData.list.Add(new UserDetails{name = PointsContoller.playerName, score = PointsContoller.totalScore});
       SaveGame.instance.Save();
       setNameCanvas.SetActive(false);
       HighScore.instance.LoadScores();
   }
}
