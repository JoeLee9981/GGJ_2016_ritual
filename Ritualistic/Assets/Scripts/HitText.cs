using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class HitText
{
    private string text;
    private int displayTime;
    private Stopwatch stopwatch;
    public bool Display;
    private float xPos;
    private float yPos;

    public HitText() {
        stopwatch = new Stopwatch();
    }

    public void Update() {
        if(Display) {
            if(stopwatch.ElapsedMilliseconds >= displayTime) {
                stopwatch.Stop();
                stopwatch.Reset();
                Display = false;
            }
            else {
                yPos--;
            }
        }
    }

    public void OnGUI() {
        if (Display) {
            GUI.Label(new Rect(xPos, yPos, 100, 100), text);
        }
    }

    public void ShowText(string text, int length, float xPos, float yPos) {
        this.text = text;
        this.displayTime = length;
        this.Display = true;
        this.xPos = xPos;
        this.yPos = yPos;
        stopwatch.Start();
    }
}

