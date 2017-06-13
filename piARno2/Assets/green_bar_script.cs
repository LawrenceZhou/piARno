using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Class for controlling the green progress bar over music sheet*/
public class green_bar_script : MonoBehaviour {
	

	static private float dx_note = 0.026f;
	static private int num_Notes = 16 + 1;
	static private float dt_note = 0.8f;
	static private float t = (float)(num_Notes*dt_note);

	private float tLeftForNext = 0.0f;
	public Rigidbody rb;
	private Vector3 startPos;
	private Vector3 endPos;
	private Vector3 speed;
	private bool startButton = false;
	int counter = 0;
	private bool waitEnough = false;
    private bool startOnce = false;




	// Initialize start position and speed of the green bar
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
		startPos = gameObject.transform.position;
		rb = GetComponent<Rigidbody> ();
		speed = new Vector3(dx_note/dt_note, 0, 0);
		endPos = new Vector3 (-startPos.x + speed.x * t, startPos.y, startPos.z);
		

	}
	

	//At the start of a song, wait for 2 seconds
	void getItEnough () {
		waitEnough = true;
	}

		

	void FixedUpdate () {

        startButton = gameSystem.state;


        if (!startButton) {
            //When startButton is false, reset member variables
                startOnce = false;
                waitEnough = false;
				counter = 0;
				tLeftForNext = 0.0f;
				rb.position = startPos;
				gameObject.GetComponent<Renderer> ().material.color = Color.white;


			} else {
            if (!startOnce)
            {
                Invoke("getItEnough", 1.2f);
                startOnce = true;
            }
            //Main moving green bar logic. 
            if (waitEnough) 
            {
            	//Set the green bar to green
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                //Rewind the green bar to start position
                if (tLeftForNext <= 0)
                { 
                    tLeftForNext = t;
                    rb.position = startPos;

                    counter++;
                    //If all music sheets have been finished, stop green bar and reset variables
                    if (counter > 3)  
                    {
                        startButton = false;
                        counter = 0;
                        return;
                    }

                }
                //start moving the green bar 
                rb.MovePosition(rb.position + speed * Time.deltaTime);
                tLeftForNext -= Time.deltaTime;
            }
			}
		
	}

}
