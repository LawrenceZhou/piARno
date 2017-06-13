using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Class for controlling the music sheet 
 */
public class sheet_plane_script : MonoBehaviour {
	static private int num_Notes = 16 + 1;
	static private float dt_note = 0.8f;
	static private float t = (float)(num_Notes*dt_note);
	private float tLeftForNext = 0.0f;
	private bool startButton = false;
	int counter = 0;
	private bool waitEnough = false;
    private bool startOnce = false;


    // Use this for initialization
    void Start () {
		//At start, set the music sheet to display an empty sheet
		Material mat = Resources.Load("Materials/empty_sheet", typeof(Material)) as Material;
		GetComponent<Renderer>().material =  mat;
		Invoke ("getItEnough", 1.2f);
	}

    //At the start of each song, wait for some time before start playing.
	void getItEnough () {
		waitEnough = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        //here check if start is pressed.
        startButton = gameSystem.state;

        if (!startButton)
        {
            //If startButton is false, reset member variables
            startOnce = false;
            waitEnough = false;
            counter = 0;
            tLeftForNext = 0.0f;

        }
        else
        {
            //At the start of each song, wait for some time before start playing.
            if (!startOnce)
            {
                Invoke("getItEnough", 1.2f);
                startOnce = true;
            }

            //Main music sheet logic.
            if (waitEnough)
            {

                if (tLeftForNext <= 0)
                {
                tLeftForNext = t;
                Material mat = null;

                counter++;

                //If all 3 sheets have been finished, reset variables and display the empty sheet.
                if (counter > 3)
                {
                    startButton = false;
                    gameSystem.state = false;
                    counter = 0;
                    mat = Resources.Load("Materials/empty_sheet", typeof(Material)) as Material;
                    GetComponent<Renderer>().material = mat;
                    return;
                }
                //Change the music sheet accordingly, for our demo song, there are 3 sheets to displays
                switch (counter)  
                {

                    case 1:
                        mat = Resources.Load("Materials/star1_new", typeof(Material)) as Material;
                        GetComponent<Renderer>().material = mat;
                        break;
                    case 2:
                        mat = Resources.Load("Materials/star2_new", typeof(Material)) as Material;
                        GetComponent<Renderer>().material = mat;
                        break;
                    case 3:
                        mat = Resources.Load("Materials/star3_new", typeof(Material)) as Material;
                        GetComponent<Renderer>().material = mat;
                        break;
                }
                //counter++;

            }
            tLeftForNext -= Time.deltaTime;
        }
			}
		
	}
}
