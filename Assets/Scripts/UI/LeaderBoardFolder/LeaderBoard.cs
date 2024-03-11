using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LeaderBoard
{
    public const int EntryCount = 10;

    public struct ScoreEntry 
    { 
        public string name; 
        public int Score; 

        public ScoreEntry(string name, int score)
        {
            this.name = name;
            this.Score = score;
        }
    }

    private static List<ScoreEntry> _s_Entries;

    private static List<ScoreEntry> Entries 
    {  
        get 
        { 
            if( _s_Entries == null)
            {
                _s_Entries = new List<ScoreEntry>();
                LoadScores();
            }      
        } 
    }

    private const string PlayerPrefsBaseKey = "leaderBoard";

    private static void SortScores()
    {
        _s_Entries.Sort((a, b) => b.Score.CompareTo(a.Score));
    }

    private static void LoadScores()
    {
        _s_Entries.Clear();

        for(int i = 0; i < EntryCount; i++)
        {
            ScoreEntry _entry;
            _entry.name = PlayerPrefs.GetString(PlayerPrefsBaseKey + "[" + i + "].name", "");
            _entry.score = PlayerPrefs.GetInt(PlayerPrefsBaseKey + "[" + i + "].score", 0);
            _s_Entries.Add(_entry);
        }
    }
}
