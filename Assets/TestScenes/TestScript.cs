using System;
using System.Collections;
using System.Collections.Generic;
using Core.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Core.Services;

public class model
{
    public string v1;
    public int v2;
}
public class TestScript : MonoBehaviour
{
    private ISaveService SaveService;
    public InputField textInput;
    public InputField numberInput;
    public Button btn;
    
    void Start()
    {
        SaveService = new SaveService();
        var model = SaveService.Load<model>("model");
        if(model != null){ 
            textInput.text = model.v1;
            numberInput.text = model.v2.ToString();
            
        }
       
        btn.onClick.AddListener((() =>
        {
            
            SaveService.Write(new model(){v1 = textInput.text, v2 =Convert.ToInt32(numberInput.text)}, "model");
            SaveService.Save();
        }));
    }
    
    
}
