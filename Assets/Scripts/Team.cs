using UnityEngine;

public class Team
{
    #region CONSTANTS
    public const uint TEAMS_COUNT = 8;
    #endregion

    #region STATIC PROPERTIES
    public static Team neutralTeam { get; private set; }
    public static Team playerTeam { get; private set; }
    public static Team[] teams { get; private set; }
    #endregion

    #region INDIVIDUAL MEMBERS
    public Color color { get; private set; }
    public int resources = 100;
    #endregion

    #region CONSTRUCTOR
    static Team()
    {
        teams = new Team[TEAMS_COUNT];

        neutralTeam = teams[0] = new Team();
        neutralTeam.color = Color.yellow;

        playerTeam = teams[1] = new Team();
        playerTeam.color = Color.green;

        for (int i = 2; i < TEAMS_COUNT; ++i)
        {
            teams[i] = new Team();
            teams[i].color = Random.ColorHSV();
        }
    }
    #endregion
}