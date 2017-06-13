using UnityEngine;
using System;
using System.IO;

#if !UNITY_EDITOR && UNITY_METRO
using System.Collections.Generic;
using Windows.Networking.Sockets;
#endif

public class keyboardReceive : MonoBehaviour
{
#if !UNITY_EDITOR && UNITY_METRO
     Windows.Networking.Sockets.DatagramSocket socket;
#endif
    public static int keyBoardPress;
	public static bool receiveFlag = false;
    // use this for initialization
#if UNITY_EDITOR
        void Start()
        {
#endif

#if !UNITY_EDITOR && UNITY_METRO
    async void Start()
    {
        Debug.Log("Waiting for a connection...");

        socket = new  Windows.Networking.Sockets.DatagramSocket();
        socket.MessageReceived += Socket_MessageReceived;

        try
        {
            await socket.BindEndpointAsync(null, "12345");
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            Debug.Log(SocketError.GetStatus(e.HResult).ToString());
            return;
        }

        Debug.Log("exit start");
#endif
    }


    // Update is called once per frame
    void Update()
    {

}

#if !UNITY_EDITOR && UNITY_METRO
    private async void  Socket_MessageReceived( Windows.Networking.Sockets.DatagramSocket sender,
         Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
    {
        //Read the message that was received from the UDP echo client.
        Stream streamIn = args.GetDataStream().AsStreamForRead();
        StreamReader reader = new StreamReader(streamIn);
        string message = await reader.ReadLineAsync();

		// attempt to parse the value using the TryParse functionality of the integer type
		int.TryParse(message, out keyBoardPress);
		receiveFlag = true;
		
        Debug.Log("MESSAGE: " + message);
}
#endif
}
