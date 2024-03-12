using System.Collections.Generic;
using UnityEngine;

public static class LeaderBoard
{
    public const int EntryCount = 10;

    public struct ScoreEntry 
    { 
        public string name; 
        public int score; 

        public ScoreEntry(string name, int score)
        {
            this.name = name;
            this.score = score;
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

            return _s_Entries;
        } 
    }

    private const string PlayerPrefsBaseKey = "leaderBoard";

    private static void SortScores()
    {
        _s_Entries.Sort((a, b) => b.score.CompareTo(a.score));
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
        SortScores();
    }

    private static void SaveScores()
    {
        for(int i = 0;i < EntryCount; i++)
        {
            var _entry = _s_Entries[i];
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].name", _entry.name);
            PlayerPrefs.SetInt(PlayerPrefsBaseKey + "[" + i + "].name", _entry.score);
        }
    }

    public static ScoreEntry GetEntry(int index)
    {
        return Entries[index];
    }

    public static void Record(string name, int score)
    {
        Entries.Add(new ScoreEntry(name, score));
        SortScores();
        Entries.RemoveAt(Entries.Count - 1);
        SaveScores();
    }
}
