using UnityEngine;

public class LeaderBoardGUI : MonoBehaviour
{
    private string _nameInput = "";
    private string _scoreInput = "0";

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        for(int i = 0; i < LeaderBoard.EntryCount; i++)
        {
            var _entry = LeaderBoard.GetEntry(i);
            GUILayout.Label("Name: " + _entry.name + ", Score: " + _entry.score);
        }

        GUILayout.Space(10);

        _nameInput = GUILayout.TextField(_nameInput);
        _scoreInput = GUILayout.TextField(_scoreInput);

        if (GUILayout.Button("Record"))
        {
            int score;
            int.TryParse(_scoreInput, out score );

            LeaderBoard.Record(_nameInput, score);

            _nameInput = "";
            _scoreInput= "0";
        }

        GUILayout.EndArea();
    }
}
