using Assets.FoodGame.Scripts;
using DataSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvLDataLoader : MonoBehaviour
{
    // debug area
    public bool allUnlock = false;

    public Transform buttonParent;
    public Button buttonPref;

    private List<string> levels;

    private List<Button> lvlLBttons = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        // load scenes in resources and store his names
        StaticData.levels = levels = Resources.LoadAll<SceneAsset>("Data").Select(p => p.name).ToList();

        //intance buttons to open lvls
        for (int i = 0; i < levels.Count; i++)
        {
            var b = Instantiate(buttonPref, buttonParent).GetComponent<Button>();
            var num = b.GetComponentsInChildren<Text>()[0];
            num.text = (i + 1) + "";
            lvlLBttons.Add(b);
        }

        // Load volatile data
        var data = DataManager.Data;

        // if fist time opened, unlock the first lvl
        if (data.levelsOpen.Count == 0) {
            data.levelsOpen.Add(levels[0]);
        }

        
        for (int i = 0; i < levels.Count; i++)
        {
            var lvl = lvlLBttons[i];
            if(!allUnlock){
                // lock or unlock the butons of lvls
                lvl.interactable = data.levelsOpen.Contains(levels[i]);
            }
                
            // set event to open lvl
            int n = i;
            lvl.onClick.AddListener(() => { StartLevel(n); });
        }

    }

    public void StartLevel(int n)
    {
        StaticData.index = n;
        StaticData.levelData = levels[n];
        SceneManager.LoadScene("GameScene");
    }


}
