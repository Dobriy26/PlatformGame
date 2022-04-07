using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DefaultNamespace
{
    public enum StatesButton
    {
        percent,
        plus,
        minus,
        increase,
        decrease,
        ravno,
        
        
    }

    public enum StatesInput
    {
        param1,
        param2,
        rezult
    }
    public class calculatorManager: MonoBehaviour
    {
        public Button Delete;
        public Button[] numsBtns;
        public Button Plus;
        public Button Minus;
        public Button Increase;
        public Button Decrease;
        public Button Percent;
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
            Minus.onClick.AddListener((() => onClickMinus()));
            Increase.onClick.AddListener((() => onClickIncr()));
            Decrease.onClick.AddListener((() => onClickDeincr()));
            Delete.onClick.AddListener((() => OnClickDel()));
            Percent.onClick.AddListener((() => onClickPerc()));
            Delete.onClick.AddListener((() => OnClickDel()));
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
        
        void onClickMinus()
        {
            Znak = StatesButton.minus;
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
        void onClickIncr()
        {
            Znak = StatesButton.increase;
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
        void onClickDeincr()
        {
            Znak = StatesButton.decrease;
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
        
        void onClickPerc()
        {
            Znak = StatesButton.percent;
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
        
        public void OnClickDel()
        {
            pervyPar = null;
            vtoroyPar = null;
            Disp.text = "";
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
                    var m1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToDouble(pervyPar);
                    var m2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToDouble(vtoroyPar);
                    Disp.text = (m1 - m2).ToString();
                    break;
                case StatesButton.increase:
                    Znak = StatesButton.ravno;
                    InputState = StatesInput.rezult;
                    var i1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToDouble(pervyPar);
                    var i2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToDouble(vtoroyPar);
                    Disp.text = (i1 * i2).ToString();
                    break;
                case StatesButton.decrease:
                    Znak = StatesButton.ravno;
                    InputState = StatesInput.rezult;
                    var d1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToDouble(pervyPar);
                    var d2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToDouble(vtoroyPar);
                    Disp.text = (d1 / d2).ToString("F");
                    break;
                case StatesButton.percent:
                    Znak = StatesButton.ravno;
                    InputState = StatesInput.rezult;
                    var s1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToDouble(pervyPar);
                    var s2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToDouble(vtoroyPar);
                    Disp.text = ((s2 * 100) / s1).ToString("P")+ "%";
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