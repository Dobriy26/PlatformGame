using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public Text text1;
    public string calc1;
    public string x1;

    public void On_Click_Button()
    {
        text1.text += calc1;
    }
    
    public void On_Click_C()
    {
        text1.text = "";
    }
    
    public void On_Click_Equal()
    {
        DataTable dt = new DataTable();
        x1 = (dt.Compute(text1.text, "")).ToString();
        text1.text = x1;
    }
}
