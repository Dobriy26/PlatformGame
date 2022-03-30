using System.Collections;
using System.Collections.Generic;
using Runner3D.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class RunnerMainMenuController : UIView
{
    [SerializeField]
    private Button PlayButton;
    [SerializeField]
    private Button SettingButton;
    [SerializeField]
    private Button ExitButton;
    [SerializeField] 
    private Text _textLevel;


    public override string ViewName { get; }
}
