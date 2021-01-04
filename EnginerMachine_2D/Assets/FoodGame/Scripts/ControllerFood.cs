using Assets.FoodGame.Scripts;
using DataSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FoodGame
{
    public class ControllerFood : MonoBehaviour
    {

        public GameObject preView;
        public LevelData lvlData;
        public GameObject winPanel, losePanel;

        private List<GameObject> prefs = new List<GameObject>();

        //preview
        private GameObject toConstruct;
        private SpriteRenderer sr;
        private bool selected = false;

        // clock
        public Image clockImg;
        public Text clockText;
        public float ft = 6;
        public bool activeClock = false;
        private float dt = 0;

        //conditions
        private bool win = false;
        private bool preWin = false;
        private bool lose = false;

        // Start is called before the first frame update
        void Start()
        {
            sr = preView.GetComponent<SpriteRenderer>();
            preView.SetActive(false);

            if (StaticData.Getindex() != -1)
            {
                SceneManager.LoadScene(StaticData.GetLevelData(),LoadSceneMode.Additive);
                prefs = new List<GameObject>(StaticData.GetLevelData().foodList);
            }
            else
            {
                prefs = new List<GameObject>(lvlData.foodList);
            }
            Select(prefs[0]);

            foreach (var data in lvlData.platformList)
            {
                Instantiate(data.platform, data.position, Quaternion.Euler(data.rotation));
            }
        }

        private void Update()
        {
            UpdatePreviewPos();

            if (Input.GetMouseButtonDown(0))
            {
                if (selected)
                {
                    Instantiate(toConstruct, preView.transform.position, Quaternion.identity);
                    prefs.Remove(toConstruct);

                    if (prefs.Count > 0)
                    {
                        Select(prefs[0]);
                    }
                    else
                    {
                        Deselect();
                        activeClock = true;
                    }
                }
            }

            if(activeClock && !lose)
            {
                if (!preWin)
                {
                    preWin = true;
                    clockImg.gameObject.SetActive(true);
                }

                if (dt > ft && !win)
                {
                    win = true;
                    Win();
                }
                dt += Time.deltaTime;
                clockText.text = (int)dt + "";
                clockImg.fillAmount = dt / ft;
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if(!lose)
            {
                lose = true;
                Lose();
            }
        }

        public void Select(GameObject pref)
        {
            selected = true;
            toConstruct = pref;
            var srPref = pref.GetComponent<SpriteRenderer>();
            sr.sprite = srPref.sprite;
            sr.size = srPref.size;
            preView.SetActive(true);
        }

        public void Deselect()
        {
            selected = false;
            toConstruct = null;
            preView.SetActive(false);
        }

        public void NextLvl()
        {
            StaticData.SetNext();
        }

        private void Win()
        {
            winPanel.gameObject.SetActive(true);
            clockImg.gameObject.SetActive(false);
            
            var data = DataManager.Data;
            data.levelsOpen.Add(StaticData.GetNext().name); // chequear aqui si es el ultimo capitulo
            DataManager.Data = data;
        }

        private void Lose()
        {
            losePanel.gameObject.SetActive(true);
            clockImg.gameObject.SetActive(false);
            Deselect();
        }

        private void UpdatePreviewPos()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            var p = Camera.main.ScreenToWorldPoint(mousePos);
            preView.transform.position = new Vector3(p.x, p.y, 0);
        }

    }
}
