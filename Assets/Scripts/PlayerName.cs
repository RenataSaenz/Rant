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
       SaveGame.instance.gameData.collectPointInt = PointsContoller.totalScore;
       PointsContoller.playerName = nameOfPlayer;
       SaveGame.instance.gameData.name = PointsContoller.playerName;
       SaveGame.instance.Save();
       HighScore.instance.LoadScores();
       setNameCanvas.SetActive(false);
   }
}
