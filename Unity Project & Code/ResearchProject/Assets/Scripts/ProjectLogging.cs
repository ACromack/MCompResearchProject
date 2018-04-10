using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

public class ProjectLogging : MonoBehaviour {

    public Stopwatch timer;

    string path = "Assets/LogFile.txt";

    // Write text to the LogFile.txt
    StreamWriter writer;

    // Use this for initialization
    void Start () {
        writer = new StreamWriter(path, true);
        timer = new Stopwatch();
        timer.Start();
        //WriteLog();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void endTimer(string level, int resetNo, int jumpCount)
    {
        timer.Stop();
        writer.WriteLine(level + " | Runtime(ms): " + timer.ElapsedMilliseconds + " | Times Jumped : " + jumpCount + " | " + level + " Reset Increment + " + resetNo);
        writer.Close();
    }

    // Use this for writing to the log file
    //static void WriteLog()
    //{
        
    //    writer.WriteLine("Test 1");
    //    writer.Close();
    //}
}
