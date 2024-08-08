using Newtonsoft.Json;
using UnityEngine;

namespace LeaderBoard
{
    public class LeaderBoardView : MonoBehaviour
    {
        //[SerializeField] private NetworkLeaderBoard networkLeaderBoard;
        [SerializeField] private LocalLeaderBoard localLeaderBoard;

        public void Show()
        {
            // Debug.Log(JsonConvert.SerializeObject(await localLeaderBoard.Leaders()));
        }
    }
}
