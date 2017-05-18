using UnityEngine;
using System.Collections;

public class PlayerResearch : MonoBehaviour {

    bool isResearhing;

    public string researchPublic;
    public float timePublic;
    public string descriptionPublic;

    // Use this for initialization
    void Start () {

        isResearhing = false;

        StartCoroutine(Research("Gun", 5, "it goes boom"));
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isResearhing == true)
        {
            timePublic -= Time.unscaledDeltaTime;
        }else 
        {
            timePublic = 0;
        }

        if (timePublic == 0 || timePublic <= 0)
            timePublic = 0;

        
	
	}

    public IEnumerator Research(string research, int time, string description)
    {
        Debug.Log(research + time + description);
        
        researchPublic = research;
        timePublic = time;
        descriptionPublic = description;
        isResearhing = true;
        yield return new WaitForSecondsRealtime(time);
        isResearhing = false;
        research = "";
        time = 0;
        description = "";
    }
}
