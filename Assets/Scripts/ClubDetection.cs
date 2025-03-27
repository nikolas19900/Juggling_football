using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClubDetection : MonoBehaviour
{

    [SerializeField]
    private GameObject _scoreObject;
    private int home=0;
    private int away = 0;
    private bool homeCheck = false;
    private bool awayCHeck = false;

    // Start is called before the first frame update
    void Start()
    {
        print("ClubDetection");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator AwaySound()
    {
        awayCHeck = true;
        AudioClip swoosh;
        swoosh = Resources.Load("Sound FX/cant_Stop") as AudioClip;
        AudioSource.PlayClipAtPoint(swoosh, new Vector3(0, 0, 0));
        yield return new WaitForSeconds(0.5f);
        awayCHeck = false;
    }

    public IEnumerator HomeSound()
    {
        homeCheck = true;
        AudioClip swoosh;
        swoosh = Resources.Load("Sound FX/seven_nation") as AudioClip;
         AudioSource.PlayClipAtPoint(swoosh, new Vector3(0, 0, 0));
        yield return new WaitForSeconds(0.5f);
        homeCheck = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("trigger");
        print("trigger:"+collision.gameObject.tag.ToString());
        if(collision.gameObject.tag == "Home")
        {
            if (!homeCheck)
            {
                StartCoroutine(HomeSound());
            }
            home++;
            Destroy(GameObject.FindGameObjectWithTag("Home"));

            var prefabs = Resources.Load("Prefabs/Dadex");

            GameObject gameObj = (GameObject)prefabs;

            GameObject firstDeck = (GameObject)Instantiate(gameObj, new Vector3(850f, 450f, 0), Quaternion.identity);
            firstDeck.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            firstDeck.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);


            //var positionHome = GameObject.FindGameObjectWithTag("Home");
            //positionHome.GetComponent<Transform>().position = new Vector3(0, 0, 0);


            //positionHome.transform.position = positionHome.transform.position + new Vector3(0, 0, 0);

            //positionHome.transform.position = new Vector3(550f, 250f, 0f);
            //print(positionHome.transform.position.x);


        }
        if (collision.gameObject.tag == "Away")
        {
            if (!awayCHeck)
            {
                StartCoroutine(AwaySound());
            }
           
            away++;

            Destroy(GameObject.FindGameObjectWithTag("Away"));
            //var positionAway = GameObject.FindGameObjectWithTag("Away");

            //positionAway.transform.position = new Vector3(0f, 0f, 0f);

            var prefabs = Resources.Load("Prefabs/Gorstak");

            GameObject gameObj = (GameObject)prefabs;

            GameObject firstDeck = (GameObject)Instantiate(gameObj, new Vector3(900f, 450f, 0), Quaternion.identity);
            firstDeck.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            firstDeck.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);


        }

        _scoreObject.GetComponent<Text>().text = "" + home + ":" + away;
    }

    
}
