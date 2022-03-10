using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Calculatore
{
    public enum StatesButton
{
    incr,
    div,
    minus,
    plus,
    ravno
        
}

public enum StatesInput
{
    param1,
    param2,
    rezult
}

public class Calculate : MonoBehaviour
{
    
    public Button[] numsBtns;
    public Button Plus;
    public Button Ravno;
    public Text Disp;
    public StatesInput InputState;
    public StatesButton Znak;
    public string pervyPar;
    public string vtoroyPar;
    void Start()
    {
        for (int i = 0; i < numsBtns.Length; i++)
        {
            var i1 = i;
            numsBtns[i].onClick.AddListener( () => onClickNum(i1));
        }
        Plus.onClick.AddListener(()=> onClickPlus());
        Ravno.onClick.AddListener(()=>onClickRavno());
    }

    void onClickPlus()
    {
        Znak = StatesButton.plus;
        switch (InputState)
        {
            case StatesInput.param1:
                InputState = StatesInput.param2;
                break;
            case StatesInput.param2:
                pervyPar = vtoroyPar;
                break;
            case StatesInput.rezult:
                pervyPar = Disp.text;
                InputState = StatesInput.param2;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    void onClickRavno()
    {
        switch (Znak)
        {
            case StatesButton.plus:
                Znak = StatesButton.ravno;
                InputState = StatesInput.rezult;
                var p1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToDouble(pervyPar);
                var p2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToDouble(vtoroyPar);
                Disp.text = (p1 + p2).ToString();
                break;
            case StatesButton.minus:
                Znak = StatesButton.ravno;
                InputState = StatesInput.rezult;
                 p1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToDouble(pervyPar);
                 p2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToDouble(vtoroyPar);
                Disp.text = (p1 - p2).ToString();
                break;
            case StatesButton.div:
                Znak = StatesButton.ravno;
                InputState = StatesInput.rezult;
                p1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToDouble(pervyPar);
                p2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToDouble(vtoroyPar);
                Disp.text = (p1 / p2).ToString();
                break;
            case StatesButton.incr:
                Znak = StatesButton.ravno;
                InputState = StatesInput.rezult;
                p1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToDouble(pervyPar);
                p2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToDouble(vtoroyPar);
                Disp.text = (p1 * p2).ToString();
                break;
            case StatesButton.ravno:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void onClickNum(int Numb)
    {
        switch (InputState)
        {
            case StatesInput.param1:
                pervyPar += Numb;
                Disp.text = pervyPar;
                break;
            case StatesInput.param2:
                vtoroyPar += Numb;
                Disp.text = vtoroyPar;
                break;
            case StatesInput.rezult:
                InputState = StatesInput.param1;
                pervyPar += Numb;
                Disp.text = pervyPar;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

}
