using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Class for controlling the jumping ghost as the prompt*/
public class transformMonster : MonoBehaviour {
    private Vector3[] keyPositions = new Vector3[25];
    private int count = 0;
    private int[] littlelittleStar = new int[42];
    public static bool jumpFlag = false;
    private Vector3 targetPosition;
    private float noteTime;
    private float lapseTime;
    private float speedX, speedY, speedZ;
    private float highest;
    public Material normalMaterial;
    public Material rightMaterial;
    public Material wrongMaterial;

    private Renderer ghostRender;

    private bool startButton = false;
    private bool waitEnough = false;
    private bool startOnce = false;
    private Vector3 startPos;

    // Use this for initialization
    void Start () {
        //Get a hold of the ghost object
        ghostRender = transform.Find("MESH").Find("LV1").GetComponent<Renderer>();
        ghostRender.material = normalMaterial;

        //Initialize helper variables
        startPos = gameObject.transform.position;

        noteTime = 0.8f;
        lapseTime = noteTime / 4;
        speedY = 0.02f / (lapseTime / 2);


        float halfKeyWidth = 0.0116f;
        float firstOffset = 0.095f;
        float lastBlackOffset = 0.003f ;
        float blackVerticalOffset = -0.03f;
        float whiteVerticalOffset = 0.02f;

        //Set the key positions specific to our piano keyboard. 25 keys in total.
        transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        keyPositions[0] = new Vector3(gameObject.transform.position.x + firstOffset, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[1] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth* 1, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[2] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth* 2, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);                                                                         
        keyPositions[3] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth* 3 + lastBlackOffset, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[4] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth* 4, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[5] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth* 6, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[6] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth* 7, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[7] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth* 8, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[8] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth* 9, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[9] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth* 10, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[10] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 11 + lastBlackOffset, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[11] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 12, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);

        keyPositions[12] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 14, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[13] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 15, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[14] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 16, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[15] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 17 + lastBlackOffset, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[16] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 18, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[17] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 20, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[18] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 21, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[19] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 22, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[20] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 23, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[21] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 24, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[22] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 25 + lastBlackOffset, gameObject.transform.position.y, gameObject.transform.position.z + blackVerticalOffset);
        keyPositions[23] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 26, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);
        keyPositions[24] = new Vector3(gameObject.transform.position.x + firstOffset + halfKeyWidth * 28, gameObject.transform.position.y, gameObject.transform.position.z + whiteVerticalOffset);

        //Store the music notes in an array. The elements stored are the current note to play in the music 
        littlelittleStar[0] = 0; littlelittleStar[1] = 0; littlelittleStar[2] = 7; littlelittleStar[3] = 7; littlelittleStar[4] = 9; littlelittleStar[5] = 9; littlelittleStar[6] = 7;
        littlelittleStar[7] = 5; littlelittleStar[8] = 5; littlelittleStar[9] = 4; littlelittleStar[10] = 4; littlelittleStar[11] = 2; littlelittleStar[12] = 2; littlelittleStar[13] = 0;

        littlelittleStar[14] = 7; littlelittleStar[15] = 7; littlelittleStar[16] = 5; littlelittleStar[17] = 5; littlelittleStar[18] = 4; littlelittleStar[19] = 4; littlelittleStar[20] = 2;
        littlelittleStar[21] = 7; littlelittleStar[22] = 7; littlelittleStar[23] = 5; littlelittleStar[24] = 5; littlelittleStar[25] = 4; littlelittleStar[26] = 4; littlelittleStar[27] = 2;

        littlelittleStar[28] = 0; littlelittleStar[29] = 0; littlelittleStar[30] = 7; littlelittleStar[31] = 7; littlelittleStar[32] = 9; littlelittleStar[33] = 9; littlelittleStar[34] = 7;
        littlelittleStar[35] = 5; littlelittleStar[36] = 5; littlelittleStar[37] = 4; littlelittleStar[38] = 4; littlelittleStar[39] = 2; littlelittleStar[40] = 2; littlelittleStar[41] = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        startButton = gameSystem.state;

        if (!startButton)
        {
            //reset member variables
            startOnce = false;
            waitEnough = false;
            count = 0;
            transform.position = startPos;
        }
        else
        {
            //At the start of a song, wait for some time.
            if (!startOnce)
            {
                Invoke("getItEnough", 1.8f);
                startOnce = true;
            }

            //If a keyboard press is detected:  Main jumping ghost prompt logic.
            if (keyboardReceive.receiveFlag == true)
            {
                if (keyboardReceive.keyBoardPress == -1)
                {//If unexpected keys are pressed, do nothing.

                    ghostRender.material = normalMaterial;
                    keyboardReceive.receiveFlag = false;
                }
                else if (keyboardReceive.keyBoardPress == littlelittleStar[count - 1])
                { //Key press received is correct, turn the ghost to green to indicate correctness.

                    ghostRender.material = rightMaterial;
                    keyboardReceive.receiveFlag = false;
                }
                else
                {//Key press received is wrong, turn the ghost to purple to indicate correctness.
                    ghostRender.material = wrongMaterial;
                    keyboardReceive.receiveFlag = false;
                }


            }
            if (jumpFlag == true) // The ghost is "gradually" jumping to the next key.
            {
                if (transform.position.y > highest)
                {
                    transform.position = new Vector3(transform.position.x + speedX * Time.deltaTime, transform.position.y - speedY * Time.deltaTime, transform.position.z + speedZ * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + speedX * Time.deltaTime, transform.position.y + speedY * Time.deltaTime, transform.position.z + speedZ * Time.deltaTime);
                }

            }
        }
    }
    //At the start of a song, wait for some time. Then start the jumping ghost logic (and the music).
    void getItEnough()
    {
        waitEnough = true;
        Invoke("playMonster", 0);
    }

    //Main jumping ghost logic. Every note time let the ghost jump to the next key in the song.
    void playMonster()
    {
        if (startButton)
        {
            if (count < 42)
            {
                Invoke("moveJump", 0);
                if (count % 7 == 6)  
                {
                    Invoke("playMonster", noteTime * 2);
                }
                else
                {
                    Invoke("playMonster", noteTime);
                }
            }
        }
        
        
    }

    //Set the parameters controlling a jump of the ghost. The actually jump happens in FixedUpdate() using these parameters.
    void moveJump()
    {
        if (startButton)
        {
            if (count < 42)
            {
                jumpFlag = true;
                targetPosition = keyPositions[littlelittleStar[count]];
                speedX = (targetPosition.x - transform.position.x) / lapseTime;
                speedZ = (targetPosition.z - transform.position.z) / lapseTime;
                highest = transform.position.y - 0.02f;
                Invoke("stopJump", lapseTime);

            }
        }
        
    }
    // The ghost has finished a jump and let it go to its stable position (on top of the current note key)
    void stopJump()
    {
        count++;
        transform.position = targetPosition;
        jumpFlag = false;
    }
}
