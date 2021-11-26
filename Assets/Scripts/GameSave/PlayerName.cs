using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{ 
    public GameObject setNameCanvas;
    public string nameOfPlayer;

    public Text inputText;
    public TextMeshProUGUI score;
    public HighScore _highScore;

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
       SaveGame.instance.recentPlayersData.list.Add(new UserDetails{name =PointsContoller.playerName, score = PointsContoller.totalScore});
       SaveGame.instance.Save();
       setNameCanvas.SetActive(false);
       _highScore.LoadScores();
   }
}
