using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

public class ProjectLogging : MonoBehaviour {

    // Public timer object
    public Stopwatch timer;

    // Path for where the log file will be situated
    string path = "Assets/LogFile.txt";

    // Write text to the LogFile.txt
    StreamWriter writer;

    // Use this for initialization
    void Start () {
        // Assign the StreamWriter and begin the timer
        writer = new StreamWriter(path, true);
        timer = new Stopwatch();
        timer.Start();
        //WriteLog();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Function for handling when the timer is stopped
    // Takes in variables to discern what level it's on, the amount of times the player has reset, how many times they have jumped and how much they use both up/down deformation
    public void endTimer(string level, int resetNo, int jumpCount, int upDeformUse, int downDeformUse)
    {
        // Stop the timer, output the logged information to a new line in the log file and then close the StreamWriter
        timer.Stop();
        writer.WriteLine(level + " | Runtime(ms): " + timer.ElapsedMilliseconds + " | Times Jumped : " + jumpCount + " | " + level + " Reset Increment + " + resetNo + " | Upwards Deformation Usage: " + upDeformUse + " | Downwards Deformation Usage: " + downDeformUse);
        writer.Close();
    }

    // Use this for writing to the log file (Initial Logging Test)
    //static void WriteLog()
    //{
        
    //    writer.WriteLine("Test 1");
    //    writer.Close();
    //}
}
